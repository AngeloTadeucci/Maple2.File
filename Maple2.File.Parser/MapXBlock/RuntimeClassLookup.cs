using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Maple2.File.Parser.Flat;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.MapXBlock;

// RuntimeClassLookup generates the assembly at runtime
public sealed class RuntimeClassLookup : ClassLookup {
    private const string RUNTIME_ASSEMBLY = "Maple2.File.Flat.Runtime";

    private readonly Dictionary<string, Type> cache;
    private readonly ModuleBuilder moduleBuilder;

    public RuntimeClassLookup(FlatTypeIndex index) : base(index) {
        cache = new Dictionary<string, Type>();

        // Create a dynamic assembly and module.
        var assemblyName = new AssemblyName(RUNTIME_ASSEMBLY);
        if (string.IsNullOrEmpty(assemblyName.Name)) {
            throw new ArgumentException($"{RUNTIME_ASSEMBLY} assembly not defined.");
        }

        moduleBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndCollect)
            .DefineDynamicModule(assemblyName.Name);

        // Manual index overrides
        var proxyNifAsset = new FlatProperty { Name = "ProxyNifAsset", Type = "AssetID", Value = "" };
        var interval = new FlatProperty { Name = "Interval", Type = "SInt32", Value = 0 };
        var friendly = new FlatProperty { Name = "friendly", Type = "SInt32", Value = 0 };
        var dropID = new FlatProperty { Name = "dropID", Type = "SInt32", Value = 0 };
        var npcList = new FlatProperty { Name = "NpcList", Type = "AssocString", Value = new Dictionary<string, string>() };
        var spawnPointID = new FlatProperty { Name = "SpawnPointID", Type = "SInt32", Value = 0 };
        var spawnRadius = new FlatProperty { Name = "SpawnRadius", Type = "Float32", Value = 0f };
        var npcCount = new FlatProperty { Name = "NpcCount", Type = "UInt32", Value = (uint) 0 };
        var reactableSequenceName = new FlatProperty { Name = "reactableSequenceName", Type = "String", Value = "" };

        FlatType ms2CubeProp = index.GetType("MS2CubeProp");
        ms2CubeProp.Properties.Add(proxyNifAsset.Name, proxyNifAsset);
        ms2CubeProp.Properties.Add(interval.Name, interval);
        ms2CubeProp.Properties.Add(friendly.Name, friendly);
        FlatType eventSpawnPointItem = index.GetType("EventSpawnPointItem");
        eventSpawnPointItem.Properties.Add(dropID.Name, dropID);
        FlatType ms2Actor = index.GetType("MS2Actor");
        ms2Actor.Properties.Add(npcList.Name, npcList);
        ms2Actor.Properties.Add(spawnPointID.Name, spawnPointID);
        ms2Actor.Properties.Add(proxyNifAsset.Name, proxyNifAsset);
        ms2Actor.Properties.Add(spawnRadius.Name, spawnRadius);
        ms2Actor.Properties.Add(npcCount.Name, npcCount);
        ms2Actor.Properties.Add(reactableSequenceName.Name, reactableSequenceName);

        // Generate classes for all model types. This is very quick and allows parallelism without conflicts.
        foreach (FlatType type in index.GetAllTypes()) {
            try {
                GetClass(type.Name);
            } catch { /* ignored */ }
        }
    }

    public override Type GetClass(string modelName) {
        FlatType entityType = index.GetType(modelName);
        if (entityType == null) {
            throw new UnknownModelTypeException(modelName);
        }
        Type mixinType = GetMixinType(modelName);
        if (cache.TryGetValue(mixinType.Name, out Type classType)) {
            return classType;
        }

        TypeBuilder classBuilder = moduleBuilder.DefineType(
            mixinType.Name[1..], // Remove "I" prefix from interface
            TypeAttributes.Class | TypeAttributes.Public,
            typeof(object),
            new[] { mixinType }
        );

        var backingFields = new List<(FlatProperty, FieldInfo)>();
        (string, string)[] baseProps = {
            ("ModelName", modelName),
            ("EntityId", string.Empty),
            ("EntityName", string.Empty),
        };
        foreach ((string name, string value) in baseProps) {
            var property = new FlatProperty {
                Name = name,
                Type = "String",
                Value = value,
            };
            FieldInfo backing = CreateBacking(classBuilder, property);
            OverrideGetter(classBuilder, backing, mixinType, property);
            backingFields.Add((property, backing));
        }

        // Define class with property values
        foreach (FlatProperty property in entityType.GetAllProperties()) {
            if (GetMethod(mixinType, $"get_{property.Name}") == null) {
                // No such getter exists
                Console.WriteLine($"Ignored unknown getter {property.Name} on {mixinType.Name}");
                continue;
            }

            FieldInfo backing = CreateBacking(classBuilder, property);
            OverrideGetter(classBuilder, backing, mixinType, property);
            backingFields.Add((property, backing));
        }

        CreateConstructor(classBuilder, backingFields);

        Type createdType = classBuilder.CreateType();
        if (createdType == null) {
            throw new InvalidOperationException($"Failed to generate class for {modelName}.");
        }

        IndexType(createdType);
        cache[mixinType.Name] = createdType;
        return createdType;
    }

    private ConstructorInfo CreateConstructor(TypeBuilder classBuilder, IEnumerable<(FlatProperty, FieldInfo)> fields) {
        ConstructorBuilder ctorBuilder = classBuilder.DefineConstructor(MethodAttributes.Public,
            CallingConventions.Standard, Type.EmptyTypes);
        ILGenerator ilGenerator = ctorBuilder.GetILGenerator();
        if (ilGenerator == null) {
            throw new InvalidOperationException($"Could not create ILGenerator for constructor.");
        }

        foreach ((FlatProperty property, FieldInfo field) in fields) {
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.EmitValue(property.Value);
            ilGenerator.Emit(OpCodes.Stfld, field);
        }

        ilGenerator.Emit(OpCodes.Ldarg_0);
        ilGenerator.Emit(OpCodes.Call, typeof(object).GetConstructor(Type.EmptyTypes));
        ilGenerator.Emit(OpCodes.Ret);
        return ctorBuilder;
    }

    private FieldInfo CreateBacking(TypeBuilder classBuilder, FlatProperty property) {
        FieldBuilder fieldBuilder = classBuilder.DefineField(
            property.Name,
            property.Value.GetType(),
            FieldAttributes.Public
        );
        if (fieldBuilder == null) {
            throw new InvalidOperationException($"{property.Name} could not create FieldBuilder.");
        }

        return fieldBuilder;
    }

    private MethodInfo OverrideGetter(TypeBuilder classBuilder, FieldInfo backing, Type mixinType, FlatProperty property) {
        string methodName = $"get_{property.Name}";
        MethodInfo methodInfo = GetMethod(mixinType, methodName);
        if (methodInfo == null) {
            throw new UnknownPropertyException(mixinType, methodName);
        }

        MethodBuilder methodBuilder = classBuilder.DefineMethod(
            methodName,
            MethodAttributes.Public | MethodAttributes.Virtual,
            methodInfo.ReturnType,
            Type.EmptyTypes
        );
        if (methodBuilder == null) {
            throw new InvalidOperationException($"{mixinType.Name} could not create MethodBuilder.");
        }

        ILGenerator ilGenerator = methodBuilder.GetILGenerator();
        if (ilGenerator == null) {
            throw new InvalidOperationException($"{mixinType.Name} could not create ILGenerator.");
        }

        ilGenerator.Emit(OpCodes.Ldarg_0);
        ilGenerator.Emit(OpCodes.Ldfld, backing);
        ilGenerator.Emit(OpCodes.Ret);

        classBuilder.DefineMethodOverride(methodBuilder, methodInfo);
        return methodBuilder;
    }
}
