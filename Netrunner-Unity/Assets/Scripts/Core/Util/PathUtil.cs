using UnityEngine;

namespace EnergonSoftware.Netrunner.Core.Util
{
    public static class PathUtil
    {
        public static string Combine(string a, string b)
        {
            return a + "/" + b;
        }

        public static string Combine(string a, string b, string c)
        {
            return a + "/" + b + "/" + c;
        }

        public static string GetDataPath(string relativePath)
        {
            return Combine(Application.dataPath, relativePath);
        }
    }
}
