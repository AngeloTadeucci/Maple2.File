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

namespace Maple2.File.Parser;

public class AiParser {
    private readonly M2dReader xmlReader;
    private readonly XmlSerializer aiSerializer;

    public AiParser(M2dReader xmlReader) {
        this.xmlReader = xmlReader;
        this.aiSerializer = new XmlSerializer(typeof(NpcAi));
    }

    public void ParseAttributes<T>(XmlNode xmlNode, T outType) {
        foreach (XmlAttribute attrib in xmlNode.Attributes) { 
            FieldInfo? field = typeof(T).GetField(attrib.Name);

            if (field is null)
            {
                throw new MemberAccessException($"object of type '{typeof(T).Name}' doesn't have member '{attrib.Name}' from node '{xmlNode.LocalName}'");
            }
            Console.WriteLine(field.FieldType.Name);
            // int, string, long, bool, short, int[], Vector3, enum, float, enum[]
            switch (field.FieldType.Name)
            {
                case "bool":
                    break;
                case "short":
                    break;
                case "int":
                    break;
                case "long":
                    break;
                case "float":
                    break;
                case "Vector3":
                    break;
                case "string":
                    break;
                case "int[]":
                    break;
                default:
                    if (field.FieldType.IsArray && field.FieldType.GetElementType().IsEnum) { 
                    }
                    else if (field.FieldType.IsEnum) { 
                    }//field.FieldType.arr
                    break;
            }
        }
    }

    public IEnumerable<(string aiName, NpcAi Data)> Parse() {
        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("AI/"))) {
            string sanitized = Sanitizer.SanitizeAi(xmlReader.GetString(entry));

            XmlDocument document = new XmlDocument();
            var nodeStack = new List<(int StackIndex, XmlNodeList Nodes, object OutNode)>();
            NpcAi root = new NpcAi();

            nodeStack.Add((0, document.ChildNodes, root));

            while (nodeStack.Count > 0) {
                (int StackIndex, XmlNodeList Nodes, object OutNode) = nodeStack.Last();

                if (StackIndex > Nodes.Count)
                {
                    nodeStack.RemoveAt(nodeStack.Count - 1);

                    continue;
                }

                // child node of stack entry
                XmlNode xmlNode = Nodes[StackIndex];

                switch (OutNode) {
                    case NpcAi npcAi:
                        switch(xmlNode.LocalName)
                        {
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
                        if (xmlNode.LocalName == "node")
                        {
                            condition.entries.Add(new Node());
                            ParseAttributes(xmlNode, (Node)condition.entries.Last());
                            nodeStack.Add((0, xmlNode.ChildNodes, (Node)condition.entries.Last()));
                        }
                        else if (xmlNode.LocalName == "aiPreset")
                        {
                            condition.entries.Add(new AiPreset());
                            ParseAttributes(xmlNode, (AiPreset)condition.entries.Last());
                        }
                        else
                        {
                            throw new NotImplementedException($"unknown node type {xmlNode.LocalName} in condition name='{condition.name}'");
                        }
                        break;
                    case AiPresetDefinition aiPreset:
                        if (xmlNode.LocalName == "node")
                        {
                            aiPreset.entries.Add(new Node());
                            ParseAttributes(xmlNode, (Node)aiPreset.entries.Last());
                            nodeStack.Add((0, xmlNode.ChildNodes, (Node)aiPreset.entries.Last()));
                        }
                        else if (xmlNode.LocalName == "aiPreset")
                        {
                            aiPreset.entries.Add(new AiPreset());
                            ParseAttributes(xmlNode, (AiPreset)aiPreset.entries.Last());
                        }
                        else
                        {
                            throw new NotImplementedException($"unknown node type {xmlNode.LocalName} in aiPreset definition name='{aiPreset.name}'");
                        }
                        break;
                    default:
                        throw new NotImplementedException($"unknown type {OutNode.GetType().Name}");
                }

                nodeStack[nodeStack.Count + 1] = (StackIndex + 1, Nodes, OutNode);
            }

            //document.LoadXml(sanitized);
            //
            //document.SelectNodes("")
            //
            //var root = aiSerializer.Deserialize(XmlReader.Create(new StringReader(sanitized))) as NpcAi;
            //
            //Debug.Assert(root != null);

            // removing the AI/ prefix because the <aiInfo path> attribute is relative to AI
            string aiName = entry.Name.Substring(3);

            yield return (aiName, root);
        }
    }
}
