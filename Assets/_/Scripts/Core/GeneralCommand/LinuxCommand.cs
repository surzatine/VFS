using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LinuxCommand
{
    private MachineRegistry _machineRegistry;
    private Dictionary<string, Action<string[]>> _commands;
    
    private VirtualFileSystem _vfs;
    
    // Tools
    private NmapCommand _nmapCommand;
    
    
    private string _result;
    
    public LinuxCommand( MachineRegistry machineRegistry,
        TextAsset startingFileSystemJson)
    {
        // Initialize
        _machineRegistry = machineRegistry;
        
        // Model
        _vfs = new VirtualFileSystem();
        _nmapCommand = new NmapCommand(machineRegistry, Print);
        
        // Load
        _vfs.LoadFromJson(startingFileSystemJson.text);
        
        // Initialize
        OnInitializeLinuxCommand();
    }
    
    private void OnInitializeLinuxCommand()
    {
        _commands = new Dictionary<string, Action<string[]>>
        {
            { "ls", CmdLs },
            { "cd", CmdCd },
            { "cat", CmdCat },
            { "pwd", args => Print(_vfs.GetCurrentPathString()) },
            { "clear", args => _result = "" },
            { "whoami", args => Print("user") },
            { "help", args => Print(string.Join(", ", _commands.Keys)) },
            
            // Tool 
            { "nmap", _nmapCommand.Execute },
        };
    }
    
    public Dictionary<string, Action<string[]>> GetCommandList => _commands;
    
    private void Print(string text) => _result += text + "\n";

    private void CmdLs(string[] args)
    {
        if (_vfs.CurrentDir.Children.Count == 0) { Print("(empty)"); return; }
        Print(string.Join("  ", _vfs.CurrentDir.Children
            .Select(c => c.IsDirectory ? c.Name + "/" : c.Name)));
    }

    private void CmdCd(string[] args)
    {
        var path = args.Length > 0 ? args[0] : "/";
        if (!_vfs.ChangeDirectory(path, out var error)) Print(error);
    }

    private void CmdCat(string[] args)
    {
        if (args.Length == 0) { Print("cat: missing filename"); return; }

        var node = _vfs.ResolvePath(args[0]);
        if (node == null) { Print($"cat: {args[0]}: No such file or directory"); return; }
        if (node.IsDirectory) { Print($"cat: {args[0]}: Is a directory"); return; }
        
        
        Print(node.Content);

        // if (node.Type == "image")
        // {
        //     var sprite = imageRegistry.GetImage(node.AssetKey);
        //     if (sprite != null)
        //     {
        //         onImageOpened?.Invoke(sprite);
        //         Print($"[opened image: {node.Name}]");
        //     }
        //     else Print($"cat: could not load image data for {node.Name}");
        // }
        // else
        // {
        //     Print(node.Content);
        // }
    }
    
    // Public API
    public string GetCurrentPathString() => _vfs.GetCurrentPathString();
    public string GetResult() => _result;
    
    public void ClearResult() =>  _result = "";
}
