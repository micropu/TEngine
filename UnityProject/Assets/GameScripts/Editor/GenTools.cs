using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using TEngine.Editor;
using YooAsset;


#if UNITY_EDITOR
using UnityEditor;
#endif

public static class GenTools
{


    [MenuItem("TestTool/Export/ClearSandBox", false, 100)]
    public static void ExportProto()
    {
        ClearSandBox();
    }

    static void ClearSandBox(string packageName = "DefaultPackage")
    {
        string projectPath = Path.GetDirectoryName(UnityEngine.Application.dataPath);
        projectPath = PathUtility.RegularPath(projectPath);
        string sandBoxPath = PathUtility.Combine(projectPath, YooAssetSettingsData.Setting.DefaultYooFolderName, packageName);
        if (Directory.Exists(sandBoxPath))
        {
            Directory.Delete(sandBoxPath, true);
        }
    }

    [MenuItem("TestTool/Export/一键测试资源", false, 100)]
    public static void AutomationBuildRes()
    {
        var bundlePath = Application.dataPath + "/../Bundles/Windows";
        if (Directory.Exists(bundlePath))
        {

            Directory.Delete(bundlePath, true);
        }
        BuildDLLCommand.BuildAndCopyDlls(BuildTarget.StandaloneWindows64);
        AssetDatabase.Refresh();
        ReleaseTools.BuildTest();
        AssetDatabase.Refresh();

    }


    [MenuItem("TestTool/RunResServer", false, 100)]
    public static void RunResServer()
    {
        BatTools.RunBat("start.bat", System.IO.Path.Combine(Application.dataPath, "../../Tools/FileServer/"));
    }
}

public class BatTools
{

    public static void RunBat(string batFile, string workingDir)
    {
        var path = FormatPath(workingDir + batFile);
        if (!System.IO.File.Exists(path))
        {
            Debug.LogError("bat文件不存在：" + path);
        }
        else
        {
            System.Diagnostics.Process proc = null;
            try
            {
                proc = new System.Diagnostics.Process();
                proc.StartInfo.WorkingDirectory = workingDir;
                proc.StartInfo.FileName = batFile;
                //proc.StartInfo.Arguments = args;
                //proc.StartInfo.CreateNoWindow = true;
                //proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;//disable dos window
                proc.Start();
                proc.WaitForExit();
                proc.Close();
            }
            catch (System.Exception ex)
            {
                Debug.LogFormat("Exception Occurred :{0},{1}", ex.Message, ex.StackTrace.ToString());
            }
        }

    }

    static string FormatPath(string path)
    {
        path = path.Replace("/", "\\");
        if (Application.platform == RuntimePlatform.OSXEditor)
            path = path.Replace("\\", "/");
        return path;
    }
}

