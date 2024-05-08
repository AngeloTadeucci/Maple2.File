using System.Diagnostics;
using Maple2.File.Parser.Xml.AI;
using Maple2.File.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class AiParserTest {
    private void TestEntry(Entry entry, HashSet<string> definedPresets) {
        Assert.IsTrue(entry.name != "");

        foreach (Entry child in entry.Entries) {
            switch (child) {
                case NodeEntry node:
                    TestNode(node, definedPresets);
                    break;
                case ConditionEntry condition:
                    TestCondition(condition, definedPresets);
                    break;
                case AiPresetEntry preset:
                    TestAiPreset(preset, definedPresets, false);
                    break;
            }
        }
    }

    private void TestNode(NodeEntry entry, HashSet<string> definedPresets) {
        Assert.IsTrue(entry.name != "");

        foreach (Entry child in entry.Entries) {
            TestEntry(child, definedPresets);
        }
    }

    private void TestCondition(ConditionEntry condition, HashSet<string> definedPresets) {
        Assert.IsTrue(condition.name != "");

        foreach (Entry child in condition.Entries) {
            TestEntry(child, definedPresets);
        }
    }

    private void TestAiPreset(AiPresetEntry preset, HashSet<string> definedPresets, bool isTopLevel) {
        Assert.IsTrue(preset.name != "");
        Assert.IsFalse(preset.Entries.Count != 0 && !isTopLevel);

        if (isTopLevel) {
            foreach (Entry child in preset.Entries) {
                TestEntry(child, definedPresets);
            }
        }
    }

    [TestMethod]
    public void TestAiParser() {
        var parser = new AiParser(TestUtils.ServerReader, includeComments:true);

        bool foundAnyNodes = false;

        foreach ((string name, NpcAi data) in parser.Parse()) {
            HashSet<string> definedPresets = new();

            bool hasReserved = data.Reserved.Count > 0;
            bool hasBattle = data.Battle.Count > 0;
            bool hasBattleEnd = data.BattleEnd.Count > 0;
            bool hasAiPresets = data.AiPresets.Count > 0;
            bool hasAnyNodes = hasReserved || hasBattle || hasBattleEnd || hasAiPresets;
            bool hasAnySubNodes = false;

            foreach (Entry entry in data.AiPresets) {
                if (entry is Comment) continue;
                if (entry is not AiPresetEntry preset) {
                    throw new ArgumentException($"Unexpected AiPreset node: {entry.name}");
                }

                // mostly true except LargeBlueAge_04 can appear twice
                //Assert.IsFalse(definedPresets.Contains(preset.name));

                definedPresets.Add(preset.name);

                hasAnySubNodes = true;
            }

            foreach (Entry entry in data.Battle) {
                TestEntry(entry, definedPresets);

                hasAnySubNodes = true;
            }

            foreach (Entry entry in data.BattleEnd) {
                TestEntry(entry, definedPresets);

                hasAnySubNodes = true;
            }

            foreach (Entry entry in data.AiPresets) {
                if (entry is Comment) continue;
                if (entry is not AiPresetEntry preset) {
                    throw new ArgumentException($"Unexpected AiPreset node: {entry.name}");
                }

                TestAiPreset(preset, definedPresets, true);

                hasAnySubNodes = true;
            }

            foreach (Entry entry in data.Reserved) {
                if (entry is Comment) continue;
                if (entry is not ConditionEntry condition) {
                    throw new ArgumentException($"Unexpected Condition node: {entry.name}");
                }

                TestCondition(condition, definedPresets);

                hasAnySubNodes = true;
            }

            foundAnyNodes |= hasAnyNodes && hasAnySubNodes;
        }

        Assert.IsTrue(foundAnyNodes);
    }
}
