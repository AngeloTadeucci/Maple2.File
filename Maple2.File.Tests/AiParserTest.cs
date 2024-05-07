using Maple2.File.Parser.Xml.AI;
using Maple2.File.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Maple2.File.Parser.Xml.Table.InteractObject;
using System.Diagnostics.CodeAnalysis;

namespace Maple2.File.Tests;

[TestClass]
public class AiParserTest {
    private void TestNode(Entry entry, HashSet<string> definedPresets) {
        Assert.IsTrue(entry.name != "");

        if (entry is AiPreset)
        {
            Assert.IsTrue(definedPresets.Contains(entry.name));

            return;
        }

        Node node = (Node)entry;

        Assert.IsTrue(node is not null);

        Assert.IsFalse(node.conditions.Count != 0 && node.name != "conditions");

        foreach (Entry child in node.entries)
        {
            TestNode(child, definedPresets);
        }

        foreach (Condition child in node.conditions) {
            TestCondition(child, definedPresets);
        }
    }

    private void TestCondition(Condition condition, HashSet<string> definedPresets) {
        Assert.IsTrue(condition.name != "");

        foreach (Entry child in condition.entries)
        {
            TestNode(child, definedPresets);
        }
    }

    private void TestAiPreset(AiPresetDefinition preset, HashSet<string> definedPresets) {
        Assert.IsTrue(preset.name != "");

        foreach (Entry child in preset.entries) {
            TestNode(child, definedPresets);
        }
    }

    [TestMethod]
    public void TestAiParser() {
        var parser = new AiParser(TestUtils.ServerReader);

        bool foundAnyNodes = false;

        foreach ((string name, NpcAi data) in parser.Parse()) {
            HashSet<string> definedPresets = new();

            bool hasReserved = (data.aiPresets?.aiPresets.Count ?? 0) > 0;
            bool hasBattle = (data.aiPresets?.aiPresets.Count ?? 0) > 0;
            bool hasBattleEnd = (data.aiPresets?.aiPresets.Count ?? 0) > 0;
            bool hasAiPresets = (data.aiPresets?.aiPresets.Count ?? 0) > 0;
            bool hasAnyNodes = hasReserved || hasBattle || hasBattleEnd || hasAiPresets;
            bool hasAnySubNodes = false;

            foreach (AiPresetDefinition preset in data.aiPresets?.aiPresets ?? new List<AiPresetDefinition>()) {
                // mostly true except LargeBlueAge_04 can appear twice
                //Assert.IsFalse(definedPresets.Contains(preset.name));

                definedPresets.Add(preset.name);

                hasAnySubNodes |= true;
            }

            foreach (Node node in data.battle?.nodes ?? new List<Node>()) {
                TestNode(node, definedPresets);

                hasAnySubNodes |= true;
            }

            foreach (Node node in data.battleEnd?.nodes ?? new List<Node>()) {
                TestNode(node, definedPresets);

                hasAnySubNodes |= true;
            }
            
            foreach (AiPresetDefinition preset in data.aiPresets?.aiPresets ?? new List<AiPresetDefinition>()) {
                TestAiPreset(preset, definedPresets);

                hasAnySubNodes |= true;
            }

            foreach (Condition condition in data.reserved?.conditions ?? new List<Condition>()) {
                TestCondition(condition, definedPresets);

                hasAnySubNodes |= true;
            }

            foundAnyNodes |= hasAnyNodes && hasAnySubNodes;
        }

        Assert.IsTrue(foundAnyNodes);
    }
}
