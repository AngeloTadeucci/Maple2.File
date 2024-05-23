using System.Numerics;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2Breakable : IMapEntity {
        string ModelName => "MS2Breakable";
        int hideTimer => 3000;
        int resetTimer => 40000;
        string reactionSequenceName => "Dead_A";
        string reactionEffectXml => "";
        Vector3 ShapeDimensions => default;
        bool useDefaultGlobalDropBox => true;
        string additionGlobalDropBoxId => "";
        string individualDropBoxId => "";
        int SoundMaterial => 0;
        bool Enabled => true;
        bool reactionEnter => false;
        bool reactionArrow => true;
        bool NxCollision => true;
        int privateRoomID => 0;
        bool MinimapInVisible => true;
        ushort PropCollisionGroup => 0;
        bool SkillPauseControllFeedback => true;
        bool isMoving => true;
    }
}
