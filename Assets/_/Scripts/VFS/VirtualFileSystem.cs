// VirtualFileSystem.cs
using System;
using System.Linq;
using Newtonsoft.Json;

[Serializable]
public class VNodeData {
    public string name;
    public bool isDirectory;
    public string type;
    public string content;
    public string assetKey;
    public System.Collections.Generic.List<VNodeData> children;
}

public class VirtualFileSystem {
    public VNode Root;
    public VNode CurrentDir;

    public void LoadFromJson(string json) {
        var data = JsonConvert.DeserializeObject<VNodeData>(json);
        Root = Build(data, null);
        CurrentDir = Root;
    }

    private VNode Build(VNodeData d, VNode parent) {
        var node = new VNode {
            Name = d.name, IsDirectory = d.isDirectory,
            Type = d.type, Content = d.content, AssetKey = d.assetKey,
            Parent = parent
        };
        if (d.isDirectory && d.children != null)
            foreach (var c in d.children) node.Children.Add(Build(c, node));
        return node;
    }

    public VNode ResolvePath(string path) {
        if (string.IsNullOrEmpty(path)) return CurrentDir;
        VNode current = path.StartsWith("/") ? Root : CurrentDir;
        foreach (var part in path.Split('/', StringSplitOptions.RemoveEmptyEntries)) {
            if (part == ".") continue;
            if (part == "..") { current = current.Parent ?? current; continue; }
            current = current.Children.FirstOrDefault(c => c.Name == part);
            if (current == null) return null;
        }
        return current;
    }

    public bool ChangeDirectory(string path, out string error) {
        error = null;
        var target = ResolvePath(path);
        if (target == null) { error = $"cd: no such file or directory: {path}"; return false; }
        if (!target.IsDirectory) { error = $"cd: not a directory: {path}"; return false; }
        CurrentDir = target;
        return true;
    }

    public string GetCurrentPathString() => CurrentDir.GetPath();
}