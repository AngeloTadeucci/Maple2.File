namespace Maple2.File.IO.Nif;

using State = List<NiPhysXPropDesc.StateString>;

public class NiPhysXPropDesc : NifBlock {
    public record StateString(string String, uint Value);

    public List<NiPhysXActorDesc> Actors;
    public List<NifBlock> Joints; // NiPhysXJointDesc
    public List<NifBlock> Clothes; // NiPhysXClothDesc
    public Dictionary<ushort, NifBlock?> Materials;
    public List<State> StateNames;
    public byte Flags;

    public NiPhysXPropDesc(int blockIndex) : base("NiPhysXPropDesc", false, blockIndex) {
        Actors = new List<NiPhysXActorDesc>();
        Joints = new List<NifBlock>();
        Clothes = new List<NifBlock>();
        Materials = new Dictionary<ushort, NifBlock?>();
        StateNames = new List<State>();
    }

    public override void Parse(NifDocument document) {
        base.Parse(document);

        Actors = document.ReadBlockRefList<NiPhysXActorDesc>();
        Joints = document.ReadBlockRefList<NifBlock>();
        Clothes = document.ReadBlockRefList<NifBlock>();
        Materials = new Dictionary<ushort, NifBlock?>();
        StateNames = new List<State>();

        uint numMaterials = document.Reader.ReadAdjustedUInt32();

        for (uint i = 0; i < numMaterials; i++) {
            ushort key = document.Reader.ReadAdjustedUInt16();
            NifBlock? material = document.ReadBlockRef<NifBlock>();

            Materials.Add(key, material);
        }

        uint numStates = document.Reader.ReadAdjustedUInt32();

        StateNames.EnsureCapacity((int) numStates);

        for (uint i = 0; i < numStates; i++) {
            State state = new State();

            int numStrings = document.Reader.ReadAdjustedInt32();

            state.EnsureCapacity((int) numStrings);

            for (int j = 0; j < numStrings; j++) {
                string key = document.ReadString();
                uint value = document.Reader.ReadAdjustedUInt32();

                state.Add(new StateString(key, value));
            }

            StateNames.Add(state);
        }

        Flags = document.Reader.ReadByte();
    }
}
