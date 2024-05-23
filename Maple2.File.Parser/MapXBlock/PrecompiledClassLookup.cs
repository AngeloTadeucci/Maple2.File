using System;
using System.Collections.Generic;
using System.Reflection;
using Maple2.File.Parser.Flat;

namespace Maple2.File.Parser.MapXBlock;

// This requires Maple2.File.Flat.Precompiled assembly to be imported.
public class PrecompiledClassLookup : ClassLookup {
    private readonly Dictionary<string, Type> cache;
    private readonly RuntimeClassLookup runtime;

    public PrecompiledClassLookup(FlatTypeIndex index) : base(index) {
        runtime = new RuntimeClassLookup(index);

        cache = new Dictionary<string, Type>();
        foreach (Type type in Assembly.Load("Maple2.File.Flat.Precompiled").GetTypes()) {
            cache[type.Name] = type;
            IndexType(type);
        }
    }

    public override Type GetClass(string modelName) {
        if (cache.TryGetValue(NormalizeClass(modelName), out Type classType)) {
            return classType;
        }

        classType = runtime.GetClass(modelName);
        if (classType != null) {
            return classType;
        }

        throw new UnknownModelTypeException(modelName);
    }
}
