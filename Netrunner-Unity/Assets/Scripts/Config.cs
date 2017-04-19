using System;

using EnergonSoftware.Netrunner.Core.Util;

using UnityEngine;

namespace EnergonSoftware.Netrunner
{
    [CreateAssetMenu(fileName="Config", menuName="Energon Software/Netrunner/Config")]
    [Serializable]
    public sealed class Config : ScriptableObject
    {
#region UNITY_EDITOR
        [UnityEditor.MenuItem("Assets/Create/Energon Software/Netrunner/Config")]
        private static void Create()
        {
            ScriptableObjectUtil.CreateAsset<Config>();
        }
#endregion

        [SerializeField]
        private string _backendURL;

        public string BackendURL => _backendURL;
    }
}
