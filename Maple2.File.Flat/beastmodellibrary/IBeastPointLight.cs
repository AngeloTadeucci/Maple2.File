using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.beastmodellibrary {
    public interface IBeastPointLight : IPCLPointLight, IBeastLight {
        string ModelName => "BeastPointLight";
        float ilbShadowRadius => 0;
    }
}
