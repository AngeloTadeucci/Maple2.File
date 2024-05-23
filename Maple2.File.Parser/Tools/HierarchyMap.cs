using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Maple2.File.Parser.Tools;

public class HierarchyMap<T> {
    private readonly Dictionary<string, HierarchyMap<T>> directories;
    private readonly Dictionary<string, T> values;

    public HierarchyMap() {
        directories = new Dictionary<string, HierarchyMap<T>>();
        values = new Dictionary<string, T>();
    }

    public IEnumerable<string> ListDirectories(string path) {
        return NavigateTo(path).directories.Keys;
    }

    // Adds a value at the specified path.
    // |path| should also include the key for the value.
    //
    // Example: Add("a/b/c/key", T)
    public void Add(string path, T value) {
        path ??= ""; // Default to empty string if null
        string[] split = path.Split(new[] { '/', '\\' }, 2, StringSplitOptions.RemoveEmptyEntries);
        if (split.Length == 1) {
            values.Add(split[0], value);
            return;
        }

        if (!directories.ContainsKey(split[0])) {
            directories.Add(split[0], new HierarchyMap<T>());
        }

        directories[split[0]].Add(split[1], value);
    }

    // Gets the value at the specified path.
    // |path| should also include the key for the value.
    //
    // Example: TryGet("a/b/c/key", T)
    public bool TryGet(string path, out T value) {
        path ??= ""; // Default to empty string if null
        string[] split = path.Split(new[] { '/', '\\' }, 2, StringSplitOptions.RemoveEmptyEntries);
        if (split.Length == 1) {
            if (values.ContainsKey(split[0])) {
                value = values[split[0]];
                return true;
            }

            value = default;
            return false;
        }

        if (directories.ContainsKey(split[0])) {
            return directories[split[0]].TryGet(split[1], out value);
        }

        value = default;
        return false;
    }

    // Finds the first value with a specified key.
    //
    // Example: Find("key", out T)
    public bool Find(string name, out T value, bool recursive = false) {
        if (!recursive) {
            return values.TryGetValue(name, out value);
        }

        foreach (HierarchyMap<T> map in directories.Values) {
            if (map.Find(name, out value, true)) {
                return true;
            }
        }

        value = default;
        return false;
    }

    // Lists all values in a directory.
    // If recursive == true, also lists values in sub-directories.
    // |path| must end with '/'
    //
    // Examples:
    //   - List("a/b/c/")
    //   - List("a/b/c/", true)
    public IEnumerable<T> List(string path, bool recursive = false) {
        HierarchyMap<T> current = NavigateTo(path);
        IEnumerable<T> list = current.values.Values;
        if (!recursive) {
            return list;
        }

        foreach (HierarchyMap<T> map in current.directories.Values) {
            list = list.Concat(map.List(path, true));
        }

        return list;
    }

    private HierarchyMap<T> NavigateTo(string path) {
        path ??= ""; // Default to empty string if null
        string[] split = path.Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);

        HierarchyMap<T> current = this;
        foreach (string directory in split) {
            if (!current.directories.TryGetValue(directory, out current)) {
                throw new DirectoryNotFoundException($"No such path: {path}");
            }
        }

        return current;
    }
}
