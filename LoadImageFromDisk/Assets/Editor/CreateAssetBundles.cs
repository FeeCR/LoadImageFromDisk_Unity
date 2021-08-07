using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class CreateAssetBundles
{
   
    [MenuItem("Assets/ Build AssetBundles")]
    static void BuildAssetBundles () {

        string assetbBundleDirectory = "Assets/StreamingAssets";

        if (!Directory.Exists(Application.streamingAssetsPath)) {

            Directory.CreateDirectory(assetbBundleDirectory);

        }

        BuildPipeline.BuildAssetBundles(assetbBundleDirectory, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);

    }

}
