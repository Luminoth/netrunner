using EnergonSoftware.Netrunner.Core;
using EnergonSoftware.Netrunner.Core.Assets;

using UnityEngine;

namespace EnergonSoftware.Netrunner
{
    public sealed class GameManager : SingletonBehavior<GameManager>
    {
        private const string ConfigAssetPath = "Assets/Base/Config.asset";

        [SerializeField]
        private Config _config;

        private void Awake()
        {
            _config = AssetManager.Instance.LoadAsset<Config>(ConfigAssetPath);
        }
    }
}
