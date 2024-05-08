using Maple2.File.Parser.Xml.AI;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;
using System.Text.RegularExpressions;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Table;
using System.Xml;
using System.Text;
using System.Xml.Linq;
using System;
using System.Reflection;
using System.Numerics;
using Maple2.File.Parser.Flat.Convert;

namespace Maple2.File.Parser;

public class AiParser {
    private readonly M2dReader xmlReader;

    public AiParser(M2dReader xmlReader) {
        this.xmlReader = xmlReader;
    }

    public void ParseAttributes<T>(XmlNode xmlNode, T outObject) {
        foreach (XmlAttribute attrib in xmlNode.Attributes) { 
            FieldInfo? field = typeof(T).GetField(attrib.Name);

            if (field is null) {
                throw new MemberAccessException($"object of type '{typeof(T).Name}' doesn't have member '{attrib.Name}' from node '{xmlNode.LocalName}'");
            }

            switch (field.FieldType.Name) {
                case "Boolean":
                    if (!bool.TryParse(attrib.Value, out bool outBool)) {
						if (!int.TryParse(attrib.Value, out int outBoolInt)) {
                        	throw new InvalidDataException($"invalid bool '{attrib.Value}' for {typeof(T).Name} member {field.Name}");
						}

						outBool = outBoolInt != 0;
                    }

                    field.SetValue(outObject, outBool);
                    break;
                case "Int16":
                    if (!short.TryParse(attrib.Value, out short outShort)) {
                        throw new InvalidDataException($"invalid short '{attrib.Value}' for {typeof(T).Name} member {field.Name}");
                    }

                    field.SetValue(outObject, outShort);
                    break;
                case "Int32":
                    if (!int.TryParse(attrib.Value, out int outInt)) {
                        throw new InvalidDataException($"invalid int '{attrib.Value}' for {typeof(T).Name} member {field.Name}");
                    }

                    field.SetValue(outObject, outInt);
                    break;
                case "Int64":
                    if (!long.TryParse(attrib.Value, out long outLong)) {
                        throw new InvalidDataException($"invalid long '{attrib.Value}' for {typeof(T).Name} member {field.Name}");
                    }

                    field.SetValue(outObject, outLong);
                    break;
                case "Single":
                    if (!float.TryParse(attrib.Value, out float outFloat)) {
                        throw new InvalidDataException($"invalid float '{attrib.Value}' for {typeof(T).Name} member {field.Name}");
                    }

                    field.SetValue(outObject, outFloat);
                    break;
                case "Vector3":
                    float[] floatValues = Array.ConvertAll(attrib.Value.Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries), float.Parse);

                    if (floatValues.Length != 3) {
                        throw new InvalidDataException($"invalid Vector3 '{attrib.Value}' for {typeof(T).Name} member {field.Name}");
                    }

                    field.SetValue(outObject, new Vector3(floatValues[0], floatValues[1], floatValues[2]));
                    break;
                case "String":
                    field.SetValue(outObject, attrib.Value);
                    break;
                case "Int32[]":
                    int[] intValues = Array.ConvertAll(attrib.Value.Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries), int.Parse);

                    field.SetValue(outObject, intValues);
                    break;
                default:
                    if (field.FieldType.IsArray && field.FieldType.GetElementType().IsEnum) {
                        Type? nestedType = field.FieldType.GetElementType();
                        if (nestedType is null) {
                            throw new InvalidDataException($"unhandled type of {field.FieldType.Name} on value '{attrib.Value}' for {typeof(T).Name} member {field.Name}");
                        }
                        // generates an object[] array of the enums. i couldn't find a way to generate the actual underlying enum type array directly because it kept resolving to object[]
                        var enumObjectValues = Array.ConvertAll(attrib.Value.Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries), value => System.Enum.Parse(nestedType, value));
                        // forcibly create an enum array and copy values over so that field.SetValue is happy & copies the array over to the member
                        dynamic enumValues = Array.CreateInstance(field.FieldType.GetElementType(), enumObjectValues.GetLength(0));
                        for (int i = 0; i < enumObjectValues.Length; ++i) {
                            enumValues[i] = (dynamic)enumObjectValues[i];
                        }
                        field.SetValue(outObject, enumValues);
                    }
                    else if (field.FieldType.IsEnum) {
                        field.SetValue(outObject, System.Enum.Parse(field.FieldType, attrib.Value));
                    }
                    else {
                        throw new InvalidDataException($"unhandled type of {field.FieldType.Name} on value '{attrib.Value}' for {typeof(T).Name} member {field.Name}");
                    }
                    break;
            }
        }
    }

    public IEnumerable<(string aiName, NpcAi Data)> Parse() {
        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("AI/"))) {
            string sanitized = Sanitizer.SanitizeAi(xmlReader.GetString(entry));

            XmlDocument document = new XmlDocument();
            var nodeStack = new List<(int stackIndex, XmlNodeList nodes, object outNode)>();
            NpcAi root = new NpcAi();

            document.LoadXml(sanitized);

            nodeStack.Add((0, document.ChildNodes, root));

            while (nodeStack.Count > 0) {
                (int stackIndex, XmlNodeList nodes, object outNode) = nodeStack.Last();

				int currentStackIndex = nodeStack.Count - 1;

                if (stackIndex >= nodes.Count) {
                    nodeStack.RemoveAt(nodeStack.Count - 1);

                    continue;
                }

                // child node of stack entry
                XmlNode? xmlNode = nodes.Item(stackIndex);

                if (xmlNode is null) {
                    throw new IndexOutOfRangeException($"stack index {stackIndex} node is null [{nodes.Count}]");
                }

				bool skipHeader = nodeStack.Count == 1 && xmlNode.Name == "xml";

                if (skipHeader || xmlNode.Name == "#comment") {
                    nodeStack[nodeStack.Count - 1] = (stackIndex + 1, nodes, outNode);

                    continue;
                }

                if (nodeStack.Count == 1 && xmlNode.Name == "npcAi") {
                    nodeStack[nodeStack.Count - 1] = (0, xmlNode.ChildNodes, outNode);

                    continue;
                }

                switch (outNode) {
                    case NpcAi npcAi:
                        switch(xmlNode.LocalName) {
                            case "reserved":
                                nodeStack.Add((0, xmlNode.ChildNodes, npcAi.reserved));
                                break;
                            case "battle":
                                nodeStack.Add((0, xmlNode.ChildNodes, npcAi.battle));
                                break;
                            case "battleEnd":
                                nodeStack.Add((0, xmlNode.ChildNodes, npcAi.battleEnd));
                                break;
                            case "aiPresets":
                                nodeStack.Add((0, xmlNode.ChildNodes, npcAi.aiPresets));
                                break;
                            default:
                                throw new NotImplementedException($"unknown node type {xmlNode.LocalName} in node 'npcAi'");
                        }

                        break;
                    case AiReservedNode reserved:
                        reserved.conditions.Add(new Condition());
                        ParseAttributes(xmlNode, reserved.conditions.Last());
                        nodeStack.Add((0, xmlNode.ChildNodes, reserved.conditions.Last()));
                        break;
                    case AiBattleNode battle:
                        battle.nodes.Add(new Node());
                        ParseAttributes(xmlNode, battle.nodes.Last());
                        nodeStack.Add((0, xmlNode.ChildNodes, battle.nodes.Last()));
                        break;
                    case AiBattleEndNode battleEnd:
                        battleEnd.nodes.Add(new Node());
                        ParseAttributes(xmlNode, battleEnd.nodes.Last());
                        nodeStack.Add((0, xmlNode.ChildNodes, battleEnd.nodes.Last()));
                        break;
                    case AiPresetsNode aiPresets:
                        aiPresets.aiPresets.Add(new AiPresetDefinition());
                        ParseAttributes(xmlNode, aiPresets.aiPresets.Last());
                        nodeStack.Add((0, xmlNode.ChildNodes, aiPresets.aiPresets.Last()));
                        break;
                    case Node node:
                        if (xmlNode.LocalName == "node") {
                            node.entries.Add(new Node());
                            ParseAttributes(xmlNode, (Node)node.entries.Last());
                            nodeStack.Add((0, xmlNode.ChildNodes, (Node)node.entries.Last()));
                        }
                        else if (xmlNode.LocalName == "aiPreset") {
                            node.entries.Add(new AiPreset());
                            ParseAttributes(xmlNode, (AiPreset)node.entries.Last());
                        }
                        else if (xmlNode.LocalName == "condition" && node.name == "conditions") {
                            node.conditions.Add(new Condition());
                            ParseAttributes(xmlNode, node.conditions.Last());
                        }
                        else {
                            throw new NotImplementedException($"unknown node type {xmlNode.LocalName} in node name='{node.name}'");
                        }
                        break;
                    case Condition condition:
                        if (xmlNode.LocalName == "node") {
                            condition.entries.Add(new Node());
                            ParseAttributes(xmlNode, (Node)condition.entries.Last());
                            nodeStack.Add((0, xmlNode.ChildNodes, (Node)condition.entries.Last()));
                        }
                        else if (xmlNode.LocalName == "aiPreset") {
                            condition.entries.Add(new AiPreset());
                            ParseAttributes(xmlNode, (AiPreset)condition.entries.Last());
                        }
                        else {
                            throw new NotImplementedException($"unknown node type {xmlNode.LocalName} in condition name='{condition.name}'");
                        }
                        break;
                    case AiPresetDefinition aiPreset:
                        if (xmlNode.LocalName == "node") {
                            aiPreset.entries.Add(new Node());
                            ParseAttributes(xmlNode, (Node)aiPreset.entries.Last());
                            nodeStack.Add((0, xmlNode.ChildNodes, (Node)aiPreset.entries.Last()));
                        }
                        else if (xmlNode.LocalName == "aiPreset") {
                            aiPreset.entries.Add(new AiPreset());
                            ParseAttributes(xmlNode, (AiPreset)aiPreset.entries.Last());
                        }
                        else {
                            throw new NotImplementedException($"unknown node type {xmlNode.LocalName} in aiPreset definition name='{aiPreset.name}'");
                        }
                        break;
                    default:
                        throw new NotImplementedException($"unknown type {outNode.GetType().Name}");
                }

                nodeStack[currentStackIndex] = (currentStackIndex + 1, nodes, outNode);
            }

            // removing the AI/ prefix because the <aiInfo path> attribute is relative to AI
            string aiName = entry.Name.Substring(3);

            yield return (aiName, root);
        }
    }
}
