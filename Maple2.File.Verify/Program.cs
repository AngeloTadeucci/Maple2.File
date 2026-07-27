using System.Diagnostics;
using Maple2.File.IO;

if (args.Length < 1) {
    Console.Error.WriteLine("Usage: MS2Verify <path-to-m2d-or-directory> [...more paths]");
    Console.Error.WriteLine("Returns 0 on success, 1 if any entry fails to decrypt.");
    return 2;
}

var archives = new List<string>();
foreach (string arg in args) {
    if (Directory.Exists(arg)) {
        archives.AddRange(Directory.GetFiles(arg, "*.m2d", SearchOption.AllDirectories));
    } else if (File.Exists(arg) && arg.EndsWith(".m2d", StringComparison.OrdinalIgnoreCase)) {
        archives.Add(arg);
    } else {
        Console.Error.WriteLine($"Skipping '{arg}': not an .m2d file or directory.");
    }
}

if (archives.Count == 0) {
    Console.Error.WriteLine("No .m2d archives found.");
    return 2;
}

var failures = new List<string>();
var totalStopwatch = Stopwatch.StartNew();

foreach (string path in archives.Distinct().OrderBy(p => p)) {
    var sw = Stopwatch.StartNew();
    int verified = 0;
    int total = 0;

    try {
        using var reader = new M2dReader(path);
        total = reader.Files.Count;
        foreach (var entry in reader.Files) {
            try {
                _ = reader.GetBytes(entry);
                verified++;
            } catch (Exception ex) {
                failures.Add($"{path} :: {entry.Name} -> {ex.Message}");
            }
        }
    } catch (Exception ex) {
        failures.Add($"{path} :: <archive open> -> {ex.Message}");
    }

    sw.Stop();
    string status = verified == total && total > 0 ? "OK" : "FAIL";
    Console.WriteLine($"[{status}] {path}  ({verified}/{total} entries, {sw.ElapsedMilliseconds}ms)");
}

totalStopwatch.Stop();
Console.WriteLine();
Console.WriteLine($"Verified {archives.Count} archive(s) in {totalStopwatch.ElapsedMilliseconds}ms");

if (failures.Count > 0) {
    Console.Error.WriteLine();
    Console.Error.WriteLine($"FAILED: {failures.Count} entr{(failures.Count == 1 ? "y" : "ies")} could not be decrypted:");
    foreach (string f in failures) {
        Console.Error.WriteLine($"  {f}");
    }
    return 1;
}

Console.WriteLine("All entries verified successfully.");
return 0;
