using Maple2.File.IO.Enum;
using System.Numerics;

namespace Maple2.File.IO.Nif;

public class NiPhysXActorDesc : NifBlock {
    public string ActorName;
    public List<Matrix4x4> Poses;
    public NifBlock? BodyDesc;
    public float Density = 1;
    public NxActorFlag ActorFlags = NxActorFlag.None;
    public ushort ActorGroup = 0;
    public ushort DominanceGroup = 0;
    public uint ContactReportFlags = 0;
    public ushort ForceFieldMaterial = 0;
    public List<NiPhysXShapeDesc> ShapeDescriptions;
    public NiPhysXActorDesc? ActorParent;
    public NifBlock? Source;
    public NifBlock? Destination;

    public NiPhysXActorDesc(int blockIndex) : base("NiPhysXActorDesc", false, blockIndex) {
        Poses = new List<Matrix4x4>();
        ShapeDescriptions = new List<NiPhysXShapeDesc>();
        ActorName = string.Empty;
    }

    public override void Parse(NifDocument document) {
        base.Parse(document);

        ActorName = document.ReadString();

        int numPoses = document.Reader.ReadAdjustedInt32();

        Poses = new List<Matrix4x4>();
        Poses.EnsureCapacity(numPoses);

        for (int i = 0; i < numPoses; ++i) {
            Poses.Add(document.Reader.ReadAdjustedMatrix4x3());
        }

        BodyDesc = document.ReadBlockRef<NifBlock>();
        Density = document.Reader.ReadAdjustedFloat32();
        ActorFlags = (NxActorFlag) document.Reader.ReadAdjustedUInt32();
        ActorGroup = document.Reader.ReadAdjustedUInt16();
        DominanceGroup = document.Reader.ReadAdjustedUInt16();
        ContactReportFlags = document.Reader.ReadAdjustedUInt32();
        ForceFieldMaterial = document.Reader.ReadAdjustedUInt16();
        ShapeDescriptions = document.ReadBlockRefList<NiPhysXShapeDesc>();
        ActorParent = document.ReadBlockRef<NiPhysXActorDesc>();
        Source = document.ReadBlockRef<NifBlock>();
        Destination = document.ReadBlockRef<NifBlock>();
    }
}

