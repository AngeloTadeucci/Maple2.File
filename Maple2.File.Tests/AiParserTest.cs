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

namespace Maple2.File.Tests;

[TestClass]
public class AiParserTest {
    private void TestNode(Node node, HashSet<string> definedPresets) {
        Assert.IsTrue(node.name != "");
        Assert.IsFalse(node.condition.Count != 0 && node.name != "conditions");

        foreach (Node child in node.node) {
            TestNode(child, definedPresets);
        }

        foreach (Condition child in node.condition) {
            TestCondition(child, definedPresets);
        }

        foreach (AiPreset child in node.aiPreset) {
            TestAiPreset(child, definedPresets, false);
        }
    }

    private void TestCondition(Condition condition, HashSet<string> definedPresets) {
        Assert.IsTrue(condition.name != "");

        foreach (Node child in condition.node) {
            TestNode(child, definedPresets);
        }

        foreach (AiPreset child in condition.aiPreset) {
            TestAiPreset(child, definedPresets, false);
        }
    }

    private void TestAiPreset(AiPreset preset, HashSet<string> definedPresets, bool isTopLevel) {
        Assert.IsTrue(preset.name != "");

        Assert.IsFalse(preset.node.Count != 0 && !isTopLevel);
        Assert.IsFalse(preset.aiPreset.Count != 0 && !isTopLevel);

        if (isTopLevel) {
            foreach (Node child in preset.node) {
                TestNode(child, definedPresets);
            }

            foreach (AiPreset child in preset.aiPreset) {
                TestAiPreset(child, definedPresets, false);
            }
        }
    }

    [TestMethod]
    public void TestAiParser() {
        var parser = new AiParser(TestUtils.ServerReader);

        bool foundAnyNodes = false;

        foreach ((string name, NpcAi data) in parser.Parse()) {
            HashSet<string> definedPresets = new();

            bool hasReserved = (data.aiPresets?.aiPreset.Count ?? 0) > 0;
            bool hasBattle = (data.aiPresets?.aiPreset.Count ?? 0) > 0;
            bool hasBattleEnd = (data.aiPresets?.aiPreset.Count ?? 0) > 0;
            bool hasAiPresets = (data.aiPresets?.aiPreset.Count ?? 0) > 0;
            bool hasAnyNodes = hasReserved || hasBattle || hasBattleEnd || hasAiPresets;
            bool hasAnySubNodes = false;

            foreach (AiPreset preset in data.aiPresets?.aiPreset ?? new List<AiPreset>()) {
                // mostly true except LargeBlueAge_04 can appear twice
                //Assert.IsFalse(definedPresets.Contains(preset.name));

                definedPresets.Add(preset.name);

                hasAnySubNodes |= true;
            }

            foreach (Node node in data.battle?.node ?? new List<Node>()) {
                TestNode(node, definedPresets);

                hasAnySubNodes |= true;
            }

            foreach (Node node in data.battleEnd?.node ?? new List<Node>()) {
                TestNode(node, definedPresets);

                hasAnySubNodes |= true;
            }

            foreach (AiPreset preset in data.aiPresets?.aiPreset ?? new List<AiPreset>()) {
                TestAiPreset(preset, definedPresets, true);

                hasAnySubNodes |= true;
            }

            foreach (Condition condition in data.reserved?.condition ?? new List<Condition>()) {
                TestCondition(condition, definedPresets);

                hasAnySubNodes |= true;
            }

            foundAnyNodes |= hasAnyNodes && hasAnySubNodes;
        }

        Assert.IsTrue(foundAnyNodes);
    }
}
