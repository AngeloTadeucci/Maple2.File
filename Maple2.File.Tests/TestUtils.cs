using System.Diagnostics;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Tests;

public static class TestUtils {
    private const string m2dPath = @"C:\Nexon\Library\Library\maplestory2\appdata\Data";
    public static readonly M2dReader XmlReader;
    public static readonly M2dReader ServerReader;
    public static readonly M2dReader ExportedReader;
    public static readonly M2dReader AssetMetadataReader;

    static TestUtils() {
        XmlReader = new M2dReader(@$"{m2dPath}\Xml.m2d");
        Filter.Load(XmlReader, "NA", "Live");
        ExportedReader = new M2dReader(@$"{m2dPath}\Resource\Exported.m2d");
        ServerReader = new M2dReader(@$"{m2dPath}\Server.m2d");
        AssetMetadataReader = new M2dReader(@$"{m2dPath}\Resource\asset-web-metadata.m2d");
    }

    public static void UnknownElementHandler(object? sender, XmlElementEventArgs e) {
        Debug.Print("Missing element {0}, expected [{1}]", e.Element.Name, e.ExpectedElements);
    }

    public static void UnknownAttributeHandler(object? sender, XmlAttributeEventArgs e) {
        Debug.Print("Missing attribute {0}, expected [{1}]", e.Attr.Name, e.ExpectedAttributes);
    }
}
