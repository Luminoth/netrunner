using System;

using UnityEngine;

namespace EnergonSoftware.Netrunner
{
    [CreateAssetMenu(fileName="Config", menuName="Energon Software/Netrunner/Config")]
    [Serializable]
    public sealed class Config : ScriptableObject
    {
        [SerializeField]
        private string _backendURL;

        public string BackendURL => _backendURL;
    }
}
