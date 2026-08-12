// VNode.cs
using System.Collections.Generic;

public class VNode {
    public string Name;
    public bool IsDirectory;
    public string Type;      // "text", "image", "folder", etc.
    public string Content;   // text body
    public string AssetKey;  // key into ImageRegistry (only used when Type == "image")
    public List<VNode> Children = new();
    public VNode Parent;

    public string GetPath() {
        if (Parent == null) return "/";
        var path = Name;
        var current = Parent;
        while (current?.Parent != null) {
            path = current.Name + "/" + path;
            current = current.Parent;
        }
        return "/" + path;
    }
}