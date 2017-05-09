using System.IO;
using EnergonSoftware.Netrunner.Core.Logging;

using UnityEditor;

namespace EnergonSoftware.Netrunner.Core.Util
{
//https://docs.unity3d.com/2017.1/Documentation/Manual/AssetBundlesIntro.html

    public static class AssetBundleUtil
    {
        private static readonly UnityEngine.Logger Logger = new UnityEngine.Logger(new CustomLogHandler());

        private const string AssetBundleOutputDirectory = "AssetBundles";

        [MenuItem("Energon Software/Asset Bundles/Build/x86")]
        public static void BuildAssetBundles()
        {
            BuildAssetBundles(PathUtil.Combine(AssetBundleOutputDirectory, "x86"), BuildTarget.StandaloneWindows, false);
        }

        [MenuItem("Energon Software/Asset Bundles/Clean")]
        public static void CleanAssetBundles()
        {
            string absolutePath = PathUtil.GetDataPath(AssetBundleOutputDirectory);

            Logger.Log($"Deleting asset bundle directory {absolutePath}");
            if(Directory.Exists(absolutePath)) {
                Directory.Delete(absolutePath, true);
            }
            AssetDatabase.Refresh();
        }

        private static void BuildAssetBundles(string assetPath, BuildTarget buildTarget, bool buildForDownload)
        {
            string absolutePath = PathUtil.GetDataPath(assetPath);

            Logger.Log($"Creating asset bundle directory {absolutePath}");
            Directory.CreateDirectory(absolutePath);
            AssetDatabase.Refresh();

            Logger.Log($"Building asset bundles for target {buildTarget}...");
            BuildPipeline.BuildAssetBundles(PathUtil.Combine("Assets", assetPath), buildForDownload ? BuildAssetBundleOptions.None : BuildAssetBundleOptions.ChunkBasedCompression, buildTarget);
        }
    }
}
