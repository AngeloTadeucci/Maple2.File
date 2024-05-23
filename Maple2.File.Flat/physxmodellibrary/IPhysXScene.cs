using System.Numerics;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.physxmodellibrary {
    public interface IPhysXScene : IBaseEntity {
        string ModelName => "PhysXScene";
        Vector3 Gravity => new Vector3(0, 0, -9.8f);
        float ScaleFactor => 1;
        float Timestep => 0.016666f;
        uint MaxSubSteps => 8;
        bool DoFixedStep => true;
        bool BlockOnFetch => false;
        uint NumSubSteps => 1;
        string SceneName => "PhysXDefaultSceneName";
        bool UseHardware => false;
        bool ActivateOnSetFinished => true;
        bool SimActive => false;
    }
}
