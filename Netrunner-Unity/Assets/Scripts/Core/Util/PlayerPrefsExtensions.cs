using System;
using UnityEngine;

namespace EnergonSoftware.Netrunner.Core.Util
{
    public static class PlayerPrefsExtensions
    {
        public static void SetBool(string key, bool value)
        {
            PlayerPrefs.SetInt(key, value ? 1 : 0);
        }

        public static bool GetBool(string key)
        {
            return 0 != PlayerPrefs.GetInt(key);
        }

        public static bool GetBool(string key, bool defaultValue)
        {
            return 0 != PlayerPrefs.GetInt(key, defaultValue ? 1 : 0);
        }
    }
}
