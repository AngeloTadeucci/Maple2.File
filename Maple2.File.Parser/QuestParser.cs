using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Quest;
using Maple2.File.Parser.Xml.String;

namespace Maple2.File.Parser;

public class QuestParser {
    private readonly M2dReader xmlReader;
    private readonly XmlSerializer descriptionSerializer;
    private readonly XmlSerializer questSerializer;

    public QuestParser(M2dReader xmlReader) {
        this.xmlReader = xmlReader;
        descriptionSerializer = new XmlSerializer(typeof(QuestDescriptionRoot));
        Type type = FeatureLocaleFilter.Locale == "KR" ? typeof(QuestDataRootKR) : typeof(QuestDataRootRoot);
        questSerializer = new XmlSerializer(type);
    }

    public IEnumerable<(int Id, string Name, QuestData Data)> Parse() {
        Dictionary<int, string> questNames = ParseQuestDescriptions();

        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("quest/"))) {
            var reader = XmlReader.Create(new StringReader(Sanitizer.SanitizeQuest(xmlReader.GetString(entry))));

            var root = questSerializer.Deserialize(reader) as QuestDataRootRoot;
            Debug.Assert(root != null);

            QuestData? data = root.environment?.quest;
            if (data == null) continue;

            int questId = int.Parse(Path.GetFileNameWithoutExtension(entry.Name));
            yield return (questId, questNames.GetValueOrDefault(questId, string.Empty), data);
        }
    }

    public IEnumerable<(int Id, string Name, QuestDataKR Data)> ParseKr() {
        Dictionary<int, string> questNames = ParseQuestDescriptions();

        PackFileEntry? entry = xmlReader.GetEntry("questdata.xml");
        Debug.Assert(entry != null, "questdata.xml not found");
        var reader = XmlReader.Create(new StringReader(Sanitizer.SanitizeQuest(xmlReader.GetString(entry))));

        var root = questSerializer.Deserialize(reader) as QuestDataRootKR;
        Debug.Assert(root != null);

        foreach (QuestDataKR data in root.quests) {
            yield return (data.id, questNames.GetValueOrDefault(data.id, string.Empty), data);
        }
    }

    public Dictionary<int, string> ParseQuestDescriptions() {
        Dictionary<int, string> questNames = new();
        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("string/en/questdescription"))) {
            // Match match = Regex.Match(entry.Name, "questdescription_event(\\w{2})\\.xml");
            // if (match.Success && !filter.Locale.Equals(match.Groups[1].Value, StringComparison.OrdinalIgnoreCase)) {
            //     Console.WriteLine($"Skipping {entry.Name}");
            //     continue;
            // }

            var reader = XmlReader.Create(new StringReader(Sanitizer.SanitizeQuestDescription(xmlReader.GetString(entry))));
            var root = descriptionSerializer.Deserialize(reader) as QuestDescriptionRoot;
            Debug.Assert(root != null);

            foreach (QuestDescription description in root.quest) {
                questNames.Add(description.questID, description.name);
            }
        }

        return questNames;
    }
}
