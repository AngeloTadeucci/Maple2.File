using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.Parser.Enum;
using Maple2.File.Parser.Xml.Skill;
using Maple2.File.Parser.Xml.String;

namespace Maple2.File.Parser;

public class SkillParser {
    private readonly M2dReader xmlReader;
    private readonly XmlSerializer nameSerializer;
    private readonly XmlSerializer skillSerializer;
    private readonly XmlSerializer skillNewSerializer;
    private readonly Language language;

    public SkillParser(M2dReader xmlReader, Language language) {
        this.xmlReader = xmlReader;
        this.language = language;
        nameSerializer = new XmlSerializer(typeof(StringMapping));
        skillSerializer = new XmlSerializer(typeof(SkillData));
        skillNewSerializer = new XmlSerializer(typeof(SkillDataNew));
    }

    public IEnumerable<(int Id, string Name, SkillData Data)> Parse() {
        Dictionary<int, string> skillNames = LoadSkillNames();

        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("skill/"))) {
            var data = skillSerializer.Deserialize(xmlReader.GetXmlReader(entry)) as SkillData;
            Debug.Assert(data != null);

            if (data.FeatureLocale() == null) continue;

            int skillId = int.Parse(Path.GetFileNameWithoutExtension(entry.Name));
            yield return (skillId, skillNames.GetValueOrDefault(skillId, string.Empty), data);
        }
    }

    public IEnumerable<(int Id, string Name, SkillNew Data)> ParseNew() {
        Dictionary<int, string> skillNames = LoadSkillNames();

        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("skilldata/"))) {
            var data = skillNewSerializer.Deserialize(xmlReader.GetXmlReader(entry)) as SkillDataNew;
            Debug.Assert(data != null);

            if (data.FeatureLocale() == null) continue;

            foreach (SkillNew skill in data.Skills) {
                // if (skill.id == 10900178) Console.WriteLine(skill);
                yield return (skill.id, skillNames.GetValueOrDefault(skill.id, string.Empty), skill);
            }
        }
    }

    public Dictionary<int, string> LoadSkillNames() {
        Dictionary<int, string> skillNames = new();
        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith($"string/{language.ToString()}/skillname"))) {
            XmlReader reader = xmlReader.GetXmlReader(entry);
            var mapping = nameSerializer.Deserialize(reader) as StringMapping;
            Debug.Assert(mapping != null);

            foreach (Key key in mapping.key) {
                skillNames.Add(int.Parse(key.id), key.name);
            }
        }

        return skillNames;
    }
}
