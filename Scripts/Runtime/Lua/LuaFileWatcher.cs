using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using LuaInterface;
#if UNITY_EDITOR
using UnityEditor;

public class DirectoryWatcher
{
    public DirectoryWatcher(string dirPath, FileSystemEventHandler handler)
    {
        Debug.Log("create directory watcher");
        CreateWatch(dirPath, handler);
    }

    void CreateWatch(string dirPath, FileSystemEventHandler handler)
    {
        if (!Directory.Exists(dirPath)) return;

        var watcher = new FileSystemWatcher();
        watcher.IncludeSubdirectories = true; //includeSubdirectories;
        watcher.Path = dirPath;
        watcher.NotifyFilter = NotifyFilters.LastWrite;
        watcher.Filter = "*.lua";
        watcher.Changed += handler;
        watcher.EnableRaisingEvents = true;
        watcher.InternalBufferSize = 10240;
    }
}

public class LuaFileWatcher
{
    private static LuaFunction ReloadFunction;

    private static HashSet<string> _changedFiles = new HashSet<string>();

    public static void CreateLuaFileWatcher(LuaState luaState,string luaDirPath)
    {
        var directoryWatcher =
            new DirectoryWatcher(luaDirPath, new FileSystemEventHandler(LuaFileOnChanged));
        ReloadFunction = luaState.GetFunction("hotfix");
        EditorApplication.update -= Reload;
        EditorApplication.update += Reload;
    }

    private static void LuaFileOnChanged(object obj, FileSystemEventArgs args)
    {
        var fullPath = args.FullPath;
        var luaFolderName = "Lua";
        var requirePath = fullPath.Replace(".lua", "");
        var luaScriptIndex = requirePath.IndexOf(luaFolderName) + luaFolderName.Length + 1;
        requirePath = requirePath.Substring(luaScriptIndex);
        requirePath = requirePath.Replace('\\', '.');
        //Debug.LogWarning("LuaFileOnChanged:"+ requirePath);
        _changedFiles.Add(requirePath);
    }

    private static void Reload()
    {
        
        if (EditorApplication.isPlaying == false)
        {
            return;
        }
        //Debug.LogWarning("Reload start");
        if (_changedFiles.Count == 0)
        {
            return;
        }

        foreach (var file in _changedFiles)
        {
            ReloadFunction.Call(file);
            Debug.LogWarning("Reload:" + file);
        }
        _changedFiles.Clear();
    }
}
#endif
