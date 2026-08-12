using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Hacking/ImageRegistry")]
public class ImageRegistry : ScriptableObject {
    [System.Serializable]
    public class ImageEntry {
        public string key;      // matches VNode.content, e.g. "photo_001"
        public Sprite image;
    }

    public List<ImageEntry> images;
    private Dictionary<string, Sprite> _lookup;

    public Sprite GetImage(string key) {
        if (_lookup == null) {
            _lookup = new Dictionary<string, Sprite>();
            foreach (var e in images) _lookup[e.key] = e.image;
        }
        return _lookup.TryGetValue(key, out var sprite) ? sprite : null;
    }
}