using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Maple2.File.IO.Tok.XmlTypes;

// https://www.pathengine.com/Contents/ProgrammersGuide/WorldRepresentation/DirectXMLGeneration/TokenisedXML/page.php
namespace Maple2.File.IO.Tok {
    public class TokReader {
        private readonly byte[] data;
        private int position;

        private readonly List<string> elements;
        private readonly List<(TokDataType Type, string Attribute)> attributes;
        private readonly XmlSerializer serializer;

        public TokReader(byte[] bytes) {
            data = bytes;
            position = 0;

            // Add NULL element to offset indices.
            elements = new List<string> { "NULL" };
            attributes = new List<(TokDataType Type, string Attribute)> { (0, "NULL") };
            serializer = new XmlSerializer(typeof(Mesh));
        }

        public Mesh Parse() {
            ParseElementsHeader();
            ParseAttributesHeader();
            return ParseData();
        }

        private void ParseElementsHeader() {
            while (!IsNull()) {
                string element = Next(TokDataType.CStr);
                elements.Add(element);
            }
            EndSequence();
        }

        private void ParseAttributesHeader() {
            while (!IsNull()) {
                var type = (TokDataType) Convert.ToByte(Next(TokDataType.UInt8));
                string attribute = Next(TokDataType.CStr);
                attributes.Add((type, attribute));
            }
            EndSequence();
        }

        private Mesh ParseData() {
            var doc = new XmlDocument();
            XmlNode node = doc;

            while (!IsEof()) {
                XmlElement element = doc.CreateElement("", NextElement(), "");
                if (!IsNull()) { // There are attributes
                    while (!IsNull()) {
                        (TokDataType type, string attribute) = NextAttribute();
                        string value = Next(type);
                        element.SetAttribute(attribute, value);
                    }
                }

                EndSequence(); // End attributes

                node?.AppendChild(element);
                node = element;

                while (!IsEof() && IsNull()) {
                    node = node?.ParentNode;
                    EndSequence();
                }
            }

            return (Mesh) serializer.Deserialize(new XmlNodeReader(doc));
        }

        private string NextElement() {
            int index = data[position++];
            return elements[index];
        }

        private (TokDataType Type, string Attribute) NextAttribute() {
            int index = data[position++];
            return attributes[index];
        }

        private bool IsEof() {
            return position >= data.Length;
        }

        private bool IsNull() {
            return data[position] == 0;
        }

        private string Next(TokDataType dataType) {
            switch (dataType) {
                case TokDataType.CStr:
                    int start = position;
                    while (data[position] != 0) {
                        position++;
                    }

                    int length = position - start;
                    position++; // null-terminator
                    return Encoding.Default.GetString(data, start, length);
                case TokDataType.Int32:
                    int int32 = BitConverter.ToInt32(data, position);
                    position += 4;
                    return int32.ToString();
                case TokDataType.Int16:
                    short int16 = BitConverter.ToInt16(data, position);
                    position += 2;
                    return int16.ToString();
                case TokDataType.Int8:
                    return ((sbyte) data[position++]).ToString();
                case TokDataType.UInt32:
                    uint uint32 = BitConverter.ToUInt32(data, position);
                    position += 4;
                    return uint32.ToString();
                case TokDataType.UInt16:
                    ushort uint16 = BitConverter.ToUInt16(data, position);
                    position += 2;
                    return uint16.ToString();
                case TokDataType.UInt8:
                    return data[position++].ToString();
                default:
                    throw new ArgumentOutOfRangeException(nameof(dataType), dataType, null);
            }
        }

        private void EndSequence() {
            if (data[position] != 0) {
                throw new ArgumentException($"Skipping non-null value: {data[position]:X2} @ 0x{position:X8}");
            }
            position++;
        }
    }
}
