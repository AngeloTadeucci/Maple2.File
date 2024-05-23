namespace Maple2.File.Flat.maplestory2library {
    public interface ICameraTargetBoundingCylinder : ICameraTargetBounding {
        string ModelName => "CameraTargetBoundingCylinder";
        float RadiusForVisualizer => 100;
        string ShapeType => "Cylinder";
    }
}
