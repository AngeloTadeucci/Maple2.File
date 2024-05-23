using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2ClientEvent : I3DProxy {
        string ModelName => "MS2ClientEvent";
        float CylinderRadius => 0;
        float CylinderHeight => 0;
        int UIscriptID => 0;
        string EnterEffectXml => "";
        string LeaveEffectXml => "";
        int EventState => 0;
    }
}
