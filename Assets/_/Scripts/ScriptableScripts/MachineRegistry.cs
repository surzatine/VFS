using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

[CreateAssetMenu(menuName = "Hacking/MachineRegistry")]
public class MachineRegistry : ScriptableObject
{

    [SerializeField] private MachineData machineData;
    
    public MachineData GetByIp(string ip)
    {
        return machineData;
    }
}
