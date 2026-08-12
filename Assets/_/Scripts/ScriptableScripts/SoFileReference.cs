using UnityEngine;

[CreateAssetMenu(fileName = "SoFileReference", menuName = "FileReference/SoFileReference", order = 1)]
public class SoFileReference : ScriptableObject
{
    [SerializeField] private FileReference fileReference;
    
    public FileReference FileReference => fileReference;
}

[System.Serializable]
public class FileReference
{
    [SerializeField] private FileTypeEnum fileType;
    [SerializeField] private string fileName;
    [SerializeField] private string fileContent;
    [SerializeField] private string filePath;
    [SerializeField] private bool isFileExists;
    [SerializeField] private Sprite fileIcon;
    [SerializeField] private Sprite fileContentImage;
    
    public FileTypeEnum FileType => fileType;
    public string FileName => fileName;
    public string FileContent => fileContent;
    public string FilePath => filePath;
    public bool IsFileExists => isFileExists;
    public Sprite FileIcon => fileIcon;
    public Sprite FileContentImage => fileContentImage;
}

