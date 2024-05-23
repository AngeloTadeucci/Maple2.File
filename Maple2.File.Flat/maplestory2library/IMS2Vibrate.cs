using System.Numerics;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2Vibrate : IMapEntity {
        string ModelName => "MS2Vibrate";
        float amp => 2;
        float frequency => 12;
        float duration => 0.3f;
        float damping => 1;
        float dampingstarttime => 0;
        bool Enabled => false;
        Vector3 ShapeDimensions => new Vector3(150, 150, 150);
        int SoundMaterial => 1;
        string XmlFilePath => "";
        bool useDefaultGlobalDropBox => true;
        string additionGlobalDropBoxId => "";
        string individualDropBoxId => "";
        string materialTag => "";
        int brokenDefence => 1;
        int brokenTick => 11000;
        Vector3 VisualizerOffset => new Vector3(0, 0, 75);
        float brokenForceScale => 1;
        bool SkillPauseControllFeedback => true;
        int resetTimer => 0;
        int hideGroupId => 0;
    }
}
