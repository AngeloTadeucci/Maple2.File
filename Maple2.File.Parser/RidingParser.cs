﻿using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Riding;

namespace Maple2.File.Parser;

public class RidingParser {
    private readonly M2dReader xmlReader;
    private readonly XmlSerializer ridingSerializer;
    private readonly XmlSerializer passengerRidingSerializer;

    public RidingParser(M2dReader xmlReader) {
        this.xmlReader = xmlReader;
        this.ridingSerializer = new XmlSerializer(typeof(RidingRoot));
        this.passengerRidingSerializer = new XmlSerializer(typeof(PassengerRidingRoot));
    }

    public IEnumerable<(int Id, Riding Data)> Parse() {
        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("riding/"))) {
            // Skip passenger/ subdirectory
            if (entry.Name.Contains("/passenger/")) continue;

            var reader = XmlReader.Create(new StringReader(Sanitizer.RemoveEmpty(xmlReader.GetString(entry))));
            var root = ridingSerializer.Deserialize(reader) as RidingRoot;
            Debug.Assert(root != null);

            Riding data = root.riding;
            if (data == null) continue;

            yield return (data.basic.id, data);
        }
    }

    public IEnumerable<(int Id, IList<PassengerRiding> Data)> ParsePassenger() {
        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("riding/passenger/"))) {
            var reader = XmlReader.Create(new StringReader(Sanitizer.RemoveEmpty(xmlReader.GetString(entry))));
            var root = passengerRidingSerializer.Deserialize(reader) as PassengerRidingRoot;
            Debug.Assert(root != null);

            IList<PassengerRiding> data = root.ridepassenger;
            if (data.Count == 0) continue;

            int rideId = int.Parse(Path.GetFileNameWithoutExtension(entry.Name));
            yield return (rideId, data);
        }
    }
}
