using System;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Maple2.File.Parser.Tools;

public static class Sanitizer {
    public static string SanitizeMagicPath(string xml) {
        // typos
        xml = xml.Replace("ldestroyTime", "destroyTime");
        xml = xml.Replace("ccontrolValue", "controlValue");
        xml = xml.Replace("fireoffsetPosition", "fireOffsetPosition");
        xml = xml.Replace("lifetime", "lifeTime");

        xml = FixCommaFloats(xml, "lifeTime", "delayTime", "spawnTime", "vel", "distance", "destroyTime",
            "controlRate");
        xml = Regex.Replace(xml, "(-?\\d+\\.\\d+)\\.\\d+", "$1"); // 1.2.3 -> 1.2
        return xml;
    }

    public static string SanitizeAi(string xml) {
        xml = xml.Replace(" ooltime=", " cooltime=");
        xml = xml.Replace(" prop=", " prob=");
        xml = xml.Replace(" prop=", " prob=");
        xml = xml.Replace(" rob=", " prob=");
        xml = xml.Replace(" zfaceTarget=", " faceTarget=");
        xml = xml.Replace(" pfaceTarget=", " faceTarget=");
        xml = xml.Replace(" sequnce=", " sequence=");
        xml = xml.Replace(" facePos=\"0\"", " facePos=\"0, 0, 0\""); // only this typo
        xml = xml.Replace(" center=\"4725, 4575. 5710\"", " center=\"4725, 4575, 5710\""); // only this typo
        xml = xml.Replace(" lifeTime=\"15.6\"", " lifeTime=\"15600\""); // only this typo
        xml = xml.Replace(" summonRadius=\"250\"", " summonRadius=\"0, 0, 250\""); // only this typo

        xml = xml.Replace("<select ", "<node name=\"select\" ");
        xml = xml.Replace("</select>", "</node>");

        return xml;
    }

    public static string SanitizeMap(string xml) {
        xml = RemoveEmpty(xml);
        xml = xml.Replace("enterreturnid=\"Kritias_Epic03\"", "enterreturnid=\"52100304\"");
        xml = xml.Replace("enterreturnid=\"Develop\"", "enterreturnid=\"99999999\"");
        return xml;
    }

    public static string SanitizeNpc(string xml) {
        int headerIndex = xml.IndexOf("<?xml", StringComparison.Ordinal);
        if (headerIndex != 0) {
            xml = xml.Substring(headerIndex);
        }

        if (!xml.Contains("<environment")) {
            xml = xml.Replace("<ms2>", "<ms2><environment>");
            xml = xml.Contains("<effectdummy")
                ? xml.Replace("<effectdummy", "</environment><effectdummy")
                : xml.Replace("</ms2>", "</environment></ms2>");
        }

        return xml;
    }

    public static string SanitizeQuest(string xml) {
        xml = RemoveEmpty(xml);
        xml = SanitizeBool(xml);
        return xml;
    }

    public static string SanitizeQuestDescription(string xml) {
        xml = RemoveEmpty(xml);
        xml = xml.Replace("count=\"0E98\"", "count=\"0\"");
        return xml;
    }

    public static string SanitizeFunctionCube(string xml) {
        xml = RemoveEmpty(xml);
        xml = xml.Replace("AutoStateChange=\"1-C\"", "AutoStateChange=\"1-0\"");
        return xml;
    }

    public static string SanitizeBool(string xml) {
        xml = Regex.Replace(xml, "true", "true", RegexOptions.IgnoreCase);
        xml = Regex.Replace(xml, "false", "false", RegexOptions.IgnoreCase);
        return xml;
    }

    public static string RemoveEmpty(string xml) {
        return Regex.Replace(xml, "\\w+=\"\"", string.Empty);
    }

    // Floats using ',' are converted to '.' (1,2 -> 1.2)
    private static string FixCommaFloats(string xml, params string[] attributes) {
        string pattern = $"({string.Join('|', attributes)})=\"(-?\\d+)(?:,(\\d+))\"";
        return Regex.Replace(xml, pattern, "$1=\"$2.$3\"");
    }
}
