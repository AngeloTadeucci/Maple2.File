namespace Maple2.File.Parser.Flat;

public class FlatType {
    private static readonly Dictionary<string, Guid> BuiltIn = new() {
        // StandardModelLibrary
        {"2DProxy".ToLower(), Guid.Parse("5d1ec3c3-e5b9-415b-9f21-30f19b55e8ad")},
        {"3DProxy".ToLower(), Guid.Parse("5944388d-0863-42e5-a5da-c3f119c2de70")},
        {"Actor".ToLower(), Guid.Parse("bc8153af-f680-46ac-9de7-f99106dee084")},
        {"AmbientLight".ToLower(), Guid.Parse("f7bcdebc-4639-4873-a6ff-452ded8d98e9")},
        {"Bakeable".ToLower(), Guid.Parse("d3ed731f-997d-43ee-affd-d32df693850d")},
        {"BaseEntity".ToLower(), Guid.Parse("627cb1ec-e7b8-446f-aefa-8dc635329a27")},
        {"Camera".ToLower(), Guid.Parse("d0d2c06f-6099-4da2-9430-ddea270bef70")},
        {"DirectionalLight".ToLower(), Guid.Parse("41b2a3c8-bb9e-47e2-8e54-b4fea9b954fe")},
        {"Environment".ToLower(), Guid.Parse("0a2ecc8d-b423-40cf-9fca-b0b8382cda97")},
        {"InputHandler".ToLower(), Guid.Parse("6fd25663-b822-49f7-a666-35e471d9b160")},
        {"Light".ToLower(), Guid.Parse("c2a81bfe-f2b2-4b96-8431-a30739726860")},
        {"Lightable".ToLower(), Guid.Parse("e803dfb5-8811-4ace-82aa-a3f3f62d3b83")},
        {"Mesh".ToLower(), Guid.Parse("769224cc-5c68-4af1-b1c8-85bc9879d9a9")},
        {"Nameable".ToLower(), Guid.Parse("152bd766-7933-47a3-8df1-00aca1e697ff")},
        {"ParallelSplitShadowConfig".ToLower(), Guid.Parse("fe0efed6-0e42-4a4f-80ef-335aa7891467")},
        {"PCLActor".ToLower(), Guid.Parse("a05b40bc-8637-4c58-9964-93dee0881c4b")},
        {"PCLDirectionalLight".ToLower(), Guid.Parse("f5cb8077-2672-457e-8f26-16df67a87b94")},
        {"PCLMesh".ToLower(), Guid.Parse("4d0e55ec-fdc6-45d6-934e-e85c04c53e2b")},
        {"PCLPointLight".ToLower(), Guid.Parse("8f3499f3-3a38-428b-8e5f-0a3a9190153c")},
        {"PCLSpotLight".ToLower(), Guid.Parse("bfcee047-ed4f-4482-84f4-0e7571f4f942")},
        {"Placeable".ToLower(), Guid.Parse("2696199a-98a7-410b-a3e3-28abeeae752a")},
        {"PointLight".ToLower(), Guid.Parse("70bf971f-e738-4a47-92d9-2a267cf49ab3")},
        {"PrecomputedLightConfig".ToLower(), Guid.Parse("67d1b6f6-53f9-4669-85d7-c74114dac43f")},
        {"PrecomputedLighting".ToLower(), Guid.Parse("b14f108a-3f7a-4527-a6ff-93550b1af555")},
        {"PrecomputedLightReceiver".ToLower(), Guid.Parse("88c2bbb6-ecce-433b-b7da-3e0a5fa98f92")},
        {"Preloadable".ToLower(), Guid.Parse("65fbc8cc-fe62-4bc2-9ad6-5c72dbfb3a46")},
        {"Proxy".ToLower(), Guid.Parse("e579223d-1f2e-419c-9214-c77d5e6c4eba")},
        {"PSSMDirectionalLight".ToLower(), Guid.Parse("6121b8d3-7cda-42c2-8fdd-0c08dd8d04af")},
        {"Renderable".ToLower(), Guid.Parse("0129ba0a-d3e2-4ff1-8a8a-31520cbcd183")},
        {"Shadowable".ToLower(), Guid.Parse("856ac922-dbe5-4fb1-a2ed-998f6112a031")},
        {"ShadowGenerator".ToLower(), Guid.Parse("cdc0f85e-5fc8-4b5d-a38b-e07e58553887")},
        {"SpotLight".ToLower(), Guid.Parse("3a968412-6fb9-481c-b55d-a79da6062c1e")},
        {"Terrain".ToLower(), Guid.Parse("3bee69a7-c94f-4849-bc79-082f81e77ef9")},
        {"TimeOfDay".ToLower(), Guid.Parse("46d216af-1ffa-4ff4-9fb5-32110d581106")},
        {"TimeOfDayEditable".ToLower(), Guid.Parse("00e2bdb9-fde1-47c4-b6e8-c71da4b234dd")},
        {"Whitebox".ToLower(), Guid.Parse("01b445d0-3956-49cf-9ba4-7096b8b8ff51")},
        // PhysXModelLibrary
        {"PhysXBox".ToLower(), Guid.Parse("7862ceac-902b-455e-85d9-1890a2700730")},
        {"PhysXBoxTrigger".ToLower(), Guid.Parse("ea70451b-9e33-4d51-96f7-ea0230eb21b0")},
        {"PhysXCapsule".ToLower(), Guid.Parse("4ac3082c-8e64-43a7-a212-35789bb9338d")},
        {"PhysXCapsuleTrigger".ToLower(), Guid.Parse("70a8190c-6a60-41a5-916f-d5e170c4c9d8")},
        {"PhysXProp".ToLower(), Guid.Parse("46c50bb9-fa71-4f68-8a6e-81a49088feef")},
        {"PhysXRagdoll".ToLower(), Guid.Parse("fa8a844a-302b-4ba0-9b5e-43ca1470539b")},
        {"PhysXScene".ToLower(), Guid.Parse("d8a858bb-65d3-4886-8590-3cc9371b227c")},
        {"PhysXShape".ToLower(), Guid.Parse("5daef827-0159-4c97-8928-40243ffcb671")},
        {"PhysXSphere".ToLower(), Guid.Parse("7bc3fcc6-f9d6-445f-9eef-38e47c6e9fc4")},
        {"PhysXSphereTrigger".ToLower(), Guid.Parse("4f1854af-8a54-454d-b07a-2ab1ccfe3cb2")},
        {"PhysXTerrain".ToLower(), Guid.Parse("71994823-4511-426b-8e9b-b20303d34fd3")},
        {"PhysXTrigger".ToLower(), Guid.Parse("fff6e58e-8953-4afa-85a9-bce932cd6d06")},
        {"PhysXWhitebox".ToLower(), Guid.Parse("37ab77e8-af35-4ea9-8b11-7f3807156d6b")},
        {"PhysXWhiteboxTrigger".ToLower(), Guid.Parse("87de5465-a1b8-4409-b6df-9eb7ea82bd66")},
    };

    public string Path;

    public readonly string Name;
    public readonly uint Id;
    public readonly List<string> Trait;
    public readonly List<FlatType> Mixin;
    public readonly Dictionary<string, FlatProperty> Properties;
    public readonly Dictionary<string, FlatBehavior> Behaviors;

    public FlatType(string name, uint id) {
        Name = name;
        Id = id;
        Trait = new List<string>();
        Mixin = new List<FlatType>();
        Properties = new Dictionary<string, FlatProperty>();
        Behaviors = new Dictionary<string, FlatBehavior>();
    }

    public FlatProperty GetProperty(string name) {
        if (Properties.ContainsKey(name)) {
            return Properties[name];
        }

        for (int i = Mixin.Count - 1; i >= 0; i--) {
            FlatProperty prop = Mixin[i].GetProperty(name);
            if (prop != null) {
                return prop;
            }
        }

        return null;
    }

    public FlatBehavior GetBehavior(string name) {
        if (Behaviors.ContainsKey(name)) {
            return Behaviors[name];
        }

        for (int i = Mixin.Count - 1; i >= 0; i--) {
            FlatBehavior behavior = Mixin[i].GetBehavior(name);
            if (behavior != null) {
                return behavior;
            }
        }

        return null;
    }

    public IEnumerable<FlatProperty> GetProperties() {
        return Properties.Values;
    }

    public IEnumerable<FlatProperty> GetInheritedProperties() {
        HashSet<string> added = new HashSet<string>(Properties.Keys);
        List<FlatProperty> props = new List<FlatProperty>();
        for (int i = Mixin.Count - 1; i >= 0; i--) {
            foreach (FlatProperty prop in Mixin[i].GetAllProperties()) {
                if (added.Contains(prop.Name)) {
                    continue;
                }

                added.Add(prop.Name);
                props.Add(prop);
            }
        }

        return props;
    }

    public IEnumerable<FlatProperty> GetNewProperties() {
        var props = new Dictionary<string, FlatProperty>(Properties);
        for (int i = Mixin.Count - 1; i >= 0; i--) {
            foreach (FlatProperty prop in Mixin[i].GetAllProperties()) {
                props.Remove(prop.Name);
            }
        }

        return props.Values;
    }

    public IEnumerable<FlatProperty> GetAllProperties() {
        Dictionary<string, FlatProperty> props = new Dictionary<string, FlatProperty>(Properties);
        for (int i = Mixin.Count - 1; i >= 0; i--) {
            foreach (FlatProperty prop in Mixin[i].GetAllProperties()) {
                props.TryAdd(prop.Name, prop);
            }
        }

        return props.Values;
    }

    public IEnumerable<FlatBehavior> GetNewBehaviors() {
        var behaviors = new Dictionary<string, FlatBehavior>(Behaviors);
        for (int i = Mixin.Count - 1; i >= 0; i--) {
            foreach (FlatBehavior behavior in Mixin[i].GetAllBehaviors()) {
                behaviors.Remove(behavior.Name);
            }
        }

        return behaviors.Values;
    }

    public IEnumerable<FlatBehavior> GetAllBehaviors() {
        var behaviors = new Dictionary<string, FlatBehavior>(Behaviors);
        for (int i = Mixin.Count - 1; i >= 0; i--) {
            foreach (FlatBehavior behavior in Mixin[i].GetAllBehaviors()) {
                behaviors.TryAdd(behavior.Name, behavior);
            }
        }

        return behaviors.Values;
    }

    public bool IsRedundantMixin(FlatType type) {
        foreach (FlatType mixinType in Mixin) {
            if (mixinType.Equals(type)) {
                continue;
            }

            if (mixinType.Mixin.Contains(type)) {
                return true;
            }

            if (mixinType.IsRedundantMixin(type)) {
                return true;
            }
        }

        return false;
    }

    // Removes any mixins that are already satisfied by another.
    public IEnumerable<FlatType> RequiredMixin() {
        return Mixin.Where(mixin => !IsRedundantMixin(mixin));
    }

    // Generates a deterministic random Guid from Id.
    public Guid ToGuid() {
        // Must get Guid from builtin libraries so they match.
        if (BuiltIn.TryGetValue(Name.ToLower(), out Guid guid)) {
            return guid;
        }

        byte[] rand = new byte[16];
        new Random(unchecked((int) Id)).NextBytes(rand);
        return new Guid(rand);
    }

    protected bool Equals(FlatType other) {
        if (Name != other.Name || Properties.Count != other.Properties.Count) {
            return false;
        }

        foreach ((string key, FlatProperty value) in Properties) {
            if (!other.Properties.TryGetValue(key, out FlatProperty otherValue)) {
                return false;
            }
            if (!value.Equals(otherValue)) {
                return false;
            }
        }

        return true;
    }

    public override bool Equals(object obj) {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((FlatType) obj);
    }

    public override int GetHashCode() {
        return HashCode.Combine(Name, Properties);
    }

    public override string ToString() {
        return $"{Name} : {string.Join(',', Mixin.Select(type => type.Name))}";
    }
}
