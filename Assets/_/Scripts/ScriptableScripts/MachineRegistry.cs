using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

[CreateAssetMenu(menuName = "Hacking/MachineRegistry")]
public class MachineRegistry : ScriptableObject
{

    [SerializeField] private MachineData machineData;
    
    public MachineData GetByIp(string ip)
    {
        if (machineData == null)
            return null;

        return machineData.ip == ip ? machineData : null;
    }
}
