using System.Diagnostics;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.Parser.Flat.Convert;
using Maple2.File.IO.Nif;
using Maple2.File.Parser.Tools;
using Maple2.File.Tests.helpers;

namespace Maple2.File.Tests;

public static class TestUtils {
    public static readonly M2dReader XmlReader;
    public static readonly M2dReader ServerReader;
    public static readonly M2dReader ExportedReader;
    public static readonly M2dReader AssetMetadataReader;
    public static readonly AssetIndex AssetIndex;
    public static readonly List<PrefixedM2dReader> ModelM2dReaders;

    static TestUtils() {
        DotEnv.Load();
        string? m2dPath = Environment.GetEnvironmentVariable("MS2_DATA_FOLDER");
        if (string.IsNullOrEmpty(m2dPath)) {
            throw new Exception("MS2_DATA_FOLDER is not set");
        }

        XmlReader = new M2dReader(@$"{m2dPath}\Xml.m2d");
        ExportedReader = new M2dReader(@$"{m2dPath}\Resource\Exported.m2d");
        ServerReader = new M2dReader(@$"{m2dPath}\Server.m2d");
        AssetMetadataReader = new M2dReader(@$"{m2dPath}\Resource\asset-web-metadata.m2d");
        AssetIndex = new AssetIndex(AssetMetadataReader);
        ModelM2dReaders = new List<PrefixedM2dReader>() {
            new PrefixedM2dReader("/library/", $@"{m2dPath}\Resource\Library.m2d"),
            new PrefixedM2dReader("/model/map/", $@"{m2dPath}\Resource\Model\Map.m2d"),
            new PrefixedM2dReader("/model/effect/", $@"{m2dPath}\Resource\Model\Effect.m2d"),
            new PrefixedM2dReader("/model/camera/", $@"{m2dPath}\Resource\Model\Camera.m2d"),
            new PrefixedM2dReader("/model/tool/", $@"{m2dPath}\Resource\Model\Tool.m2d"),
            new PrefixedM2dReader("/model/item/", $@"{m2dPath}\Resource\Model\Item.m2d"),
            new PrefixedM2dReader("/model/npc/", $@"{m2dPath}\Resource\Model\Npc.m2d"),
            new PrefixedM2dReader("/model/path/", $@"{m2dPath}\Resource\Model\Path.m2d"),
            new PrefixedM2dReader("/model/character/", $@"{m2dPath}\Resource\Model\Character.m2d"),
            new PrefixedM2dReader("/model/textures/", $@"{m2dPath}\Resource\Model\Textures.m2d"),
        };
    }

    public static void UnknownElementHandler(object? sender, XmlElementEventArgs e) {
        Debug.Print("Missing element {0}, expected [{1}]", e.Element.Name, e.ExpectedElements);
    }

    public static void UnknownAttributeHandler(object? sender, XmlAttributeEventArgs e) {
        Debug.Print("Missing attribute {0}, expected [{1}]", e.Attr.Name, e.ExpectedAttributes);
    }
}

// We still want to load all files from the KR version, not only Xml.m2d
public static class TestUtilsKR {
    public static readonly M2dReader XmlReader;
    public static readonly M2dReader ServerReader;
    public static readonly M2dReader ExportedReader;
    public static readonly M2dReader AssetMetadataReader;
    public static readonly AssetIndex AssetIndex;
    public static readonly List<PrefixedM2dReader> ModelM2dReaders;

    static TestUtilsKR() {
        DotEnv.Load();
        string? m2dPath = Environment.GetEnvironmentVariable("KMS2_DATA_FOLDER");
        if (string.IsNullOrEmpty(m2dPath)) {
            throw new Exception("KMS2_DATA_FOLDER is not set");
        }

        XmlReader = new M2dReader(@$"{m2dPath}\Xml.m2d");
        ExportedReader = new M2dReader(@$"{m2dPath}\Resource\Exported.m2d");
        ServerReader = new M2dReader(@$"{m2dPath}\Server.m2d");
        AssetMetadataReader = new M2dReader(@$"{m2dPath}\Resource\asset-web-metadata.m2d");
        AssetIndex = new AssetIndex(AssetMetadataReader);
        ModelM2dReaders = new List<PrefixedM2dReader>() {
            new PrefixedM2dReader("/library/", $@"{m2dPath}\Resource\Library.m2d"),
            new PrefixedM2dReader("/model/map/", $@"{m2dPath}\Resource\Model\Map.m2d"),
            new PrefixedM2dReader("/model/effect/", $@"{m2dPath}\Resource\Model\Effect.m2d"),
            new PrefixedM2dReader("/model/camera/", $@"{m2dPath}\Resource\Model\Camera.m2d"),
            new PrefixedM2dReader("/model/tool/", $@"{m2dPath}\Resource\Model\Tool.m2d"),
            new PrefixedM2dReader("/model/item/", $@"{m2dPath}\Resource\Model\Item.m2d"),
            new PrefixedM2dReader("/model/npc/", $@"{m2dPath}\Resource\Model\Npc.m2d"),
            new PrefixedM2dReader("/model/path/", $@"{m2dPath}\Resource\Model\Path.m2d"),
            new PrefixedM2dReader("/model/character/", $@"{m2dPath}\Resource\Model\Character.m2d"),
            new PrefixedM2dReader("/model/textures/", $@"{m2dPath}\Resource\Model\Textures.m2d"),
        };
    }

    public static void UnknownElementHandler(object? sender, XmlElementEventArgs e) {
        Debug.Print("Missing element {0}, expected [{1}]", e.Element.Name, e.ExpectedElements);
    }

    public static void UnknownAttributeHandler(object? sender, XmlAttributeEventArgs e) {
        Debug.Print("Missing attribute {0}, expected [{1}]", e.Attr.Name, e.ExpectedAttributes);
    }
}

