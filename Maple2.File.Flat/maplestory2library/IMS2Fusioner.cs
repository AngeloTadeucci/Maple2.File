using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2Fusioner : IMS2PhysXProp, IMS2FunctionCube {
        string ModelName => "MS2Fusioner";
        float Temperature => 0;
        bool Projectable => true;
        bool Transparency => false;
        bool MinimapInVisible => false;
        bool DisableCollision => false;
        float ClippingDistance => 8000;
        bool ForceNearbox => false;
        bool UseInstancing => true;
        Color MaterialColor => Color.FromArgb(255, 180, 180, 180);
        IDictionary<string, Vector3> ChildrenCube => new Dictionary<string, Vector3>();
        string CubeType => "Ground";
        string CubeSubType => "None";
        int CubeSalableGroup => 0;
        bool GeneratePhysX => false;
        string MapAttribute => "default";
        bool IsObjectWeapon => false;
        uint ObjectWeaponRespawnTick => 0;
        string ObjectWeaponItemCode => "0";
        float ObjectWeaponActiveDistance => 150;
        uint ObjectWeaponSpawnNpcCode => 0;
        uint ObjectWeaponSpawnNpcCount => 1;
        float ObjectWeaponSpawnNpcRate => 1;
        uint ObjectWeaponSpawnNpcLifeTick => 0;
        string ObjectWeaponSpawnNpcAnimation => "0";
        bool UseInstancingUpdate => false;
        bool UseShellRender => false;
        Vector3 GeneratePhysXDimension => default;
        float CameraExtraDistance => 0;
        float checkCameraDistance => 0;
        bool InstancingOnLoad => false;
        bool InstancingKeepObject => false;
        bool IsFallReturn => true;
        int TransparencyGroupID => 0;
        bool IsHighPrioAlphaObject => false;
        float TransparencyFadeOutAlpha => 0.3f;
        int AutoHideGroupID => 0;
        string NameTag => "";
    }
}
