using UnityEngine;

public class CommandProcessor : MonoBehaviour
{
    private LinuxCommand _linuxCommand;
    private string _result;
    public UnityEvent<string> onCommandProcessed;
}
