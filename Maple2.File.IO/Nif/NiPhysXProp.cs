namespace Maple2.File.IO.Nif;

public class NiPhysXProp : NifBlock {
    public List<NifBlock> ExtraData; // NiExtraData
    public NifBlock? Controller = null; // NiTimeController
    public float PhysXToWorldScale = 1;
    public List<NifBlock> Sources; // NiPhysXSrc
    public List<NifBlock> Dests; // NiPhysXDest
    public List<NifBlock> ModifiedMeshes; // NiMesh
    public bool KeepMeshes = false;
    public NiPhysXPropDesc? Snapshot = null;

    public NiPhysXProp(int blockIndex) : base("NiPhysXProp", true, blockIndex) {
        ExtraData = new List<NifBlock>();
        Sources = new List<NifBlock>();
        Dests = new List<NifBlock>();
        ModifiedMeshes = new List<NifBlock>();
    }

    public override void Parse(NifDocument document) {
        base.Parse(document);

        ExtraData = document.ReadBlockRefList<NifBlock>();
        Controller = document.ReadBlockRef<NifBlock>();
        PhysXToWorldScale = document.Reader.ReadAdjustedFloat32();
        Sources = document.ReadBlockRefList<NifBlock>();
        Dests = document.ReadBlockRefList<NifBlock>();
        ModifiedMeshes = document.ReadBlockRefList<NifBlock>();
        KeepMeshes = document.Reader.ReadBoolean();
        Snapshot = document.ReadBlockRef<NiPhysXPropDesc>();

        document.PhysXProps.Add(this);
    }
}

