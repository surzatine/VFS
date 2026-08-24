public class MachineData
{
    public string ip;
    public string hostname;
    public string os;
    public List<PortInfo> ports;
    public List<CredentialLeak> sniffableCredentials;
    public string exploitPayload;
    public bool isCompromised;
    public VNodeData fileSystem;
}
