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

    public NiPhysXProp(int blockIndex) : base("NiPhysXProp", true, blockIndex) { }

    public override void Parse(NifDocument document) {
        base.Parse(document);

        ExtraData = document.ReadBlockRefList<NifBlock>();
        Controller = document.ReadBlockRef<NifBlock>();
        PhysXToWorldScale = document.Reader.ReadFloat32();
        Sources = document.ReadBlockRefList<NifBlock>();
        Dests = document.ReadBlockRefList<NifBlock>();
        ModifiedMeshes = document.ReadBlockRefList<NifBlock>();
        KeepMeshes = document.Reader.ReadBool();
        Snapshot = document.ReadBlockRef<NiPhysXPropDesc>();

        document.PhysXProps.Add(this);
    }
}

