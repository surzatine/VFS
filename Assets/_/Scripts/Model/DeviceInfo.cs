using System.Collections.Generic;

[System.Serializable]
public class PortInfo {
    public int port;
    public string service;   // "ssh", "http", "ftp"
    public bool isOpen;
}

[System.Serializable]
public class CredentialLeak {
    public string username;
    public string password;
    public string context; // e.g. "FTP login", "HTTP POST /login"
}

[System.Serializable]
public class MachineData {
    public string ip;
    public string hostname;
    public string os;               // "Windows Server 2019", "Ubuntu 20.04"
    public List<PortInfo> ports;
    public List<CredentialLeak> sniffableCredentials;
    public string exploitPayload;   // required payload string to succeed, e.g. "windows/x64/meterpreter/reverse_tcp"
    public bool isCompromised;
    public VNodeData fileSystem;    // the machine's VFS, unlocked once compromised
}

[System.Serializable]
public class CapturedHash
{
    public string username;
    public string hash;
    public string algorithm;
    public string plaintext;
}

[System.Serializable]
public class NetworkPacket
{
    public string sourceIp;
    public string destinationIp;
    public int port;
    public string protocol;
    public string data;
}
