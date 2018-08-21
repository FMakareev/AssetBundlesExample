using UnityEditor;
using System.Collections;

public class BundleCreate
{

    [MenuItem("Simple Bundles/Build")]
    static void BuildBundles()
    {
        // https://docs.unity3d.com/ScriptReference/EditorUtility.SaveFolderPanel.html
        string path = EditorUtility.SaveFolderPanel("Save Bundle", "", "");
        if (path.Length != 0)
        {
            // https://docs.unity3d.com/ScriptReference/BuildPipeline.html
            BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
        }
    }
}