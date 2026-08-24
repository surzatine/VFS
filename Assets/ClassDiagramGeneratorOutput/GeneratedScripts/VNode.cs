public class VNode
{
    public string Name;
    public bool IsDirectory;
    public string Type;
    public string Content;
    public string AssetKey;
    public List<VNode> Children;
    public VNode Parent;
}
