using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/itemmergeoptionbase.xml
// ./data/xml/table/itemmergeoptionmaterial.xml
[XmlRoot("ms2")]
public class ItemMergeOptionRoot {
    [XmlElement] public List<MergeOption> mergeOption;
}

public partial class MergeOption : IFeatureLocale {
    [XmlAttribute] public int id;

    // Technically this is a list, but never more than 1
    [XmlElement] public MergeStep mergeStep;
}

public partial class MergeStep {
    [XmlAttribute] public int step;

    [XmlElement] public List<Slot> slot;

    public partial class Slot {
        [XmlAttribute] public int part = 1;
        [M2dArray] public int[] partLimit = Array.Empty<int>();
        [XmlAttribute] public long consumeMeso;

        // Not present in xmls
        // [XmlAttribute] public float mergeProb;
        // [XmlAttribute] public int optionPickNum;
        // itemMaterial0, itemMaterial1
    }

    public partial class Option {
        [XmlAttribute] public string optionName = string.Empty;
        [XmlAttribute] public int optionWeight;
        [XmlAttribute] public bool isStaticOption;

        [M2dArray] public float[] idx0 = Array.Empty<float>();
        [M2dArray] public float[] idx1 = Array.Empty<float>();
        [M2dArray] public float[] idx2 = Array.Empty<float>();
        [M2dArray] public float[] idx3 = Array.Empty<float>();
        [M2dArray] public float[] idx4 = Array.Empty<float>();
        [M2dArray] public float[] idx5 = Array.Empty<float>();
        [M2dArray] public float[] idx6 = Array.Empty<float>();
        [M2dArray] public float[] idx7 = Array.Empty<float>();
        [M2dArray] public float[] idx8 = Array.Empty<float>();
        [M2dArray] public float[] idx9 = Array.Empty<float>();
        // Also idx{0}_weight, but not used in xml

        public float[] this[int i] => i switch {
            0 => idx0,
            1 => idx1,
            2 => idx2,
            3 => idx3,
            4 => idx4,
            5 => idx5,
            6 => idx6,
            7 => idx7,
            8 => idx8,
            9 => idx9,
            _ => throw new ArgumentOutOfRangeException(nameof(i), i, "Invalid option index."),
        };
    }
}


// ./data/xml/table/itemmergeoptionbase.xml
[XmlRoot("ms2")]
public class ItemMergeOptionRootKR {
    [XmlElement] public List<MergeOptionKR> mergeOption = [];
}

public partial class MergeOptionKR : IFeatureLocale {
    [XmlAttribute] public int id;

    [XmlElement] public List<Slot> slot = [];
}

public partial class Slot {
    [XmlAttribute] public int part = 1;
    [M2dArray] public int[] partLimit = [];

    [XmlElement] public List<OptionKR> option = [];
}

public partial class OptionKR {
    [XmlAttribute] public string optionName = string.Empty;
    [XmlAttribute] public int min;

    [XmlAttribute] public float idx0_max;
    [XmlAttribute] public float idx1_max;
    [XmlAttribute] public float idx2_max;
    [XmlAttribute] public float idx3_max;
    [XmlAttribute] public float idx4_max;
    [XmlAttribute] public float idx5_max;
    [XmlAttribute] public float idx6_max;
    [XmlAttribute] public float idx7_max;
    [XmlAttribute] public float idx8_max;
    [XmlAttribute] public float idx9_max;
}
