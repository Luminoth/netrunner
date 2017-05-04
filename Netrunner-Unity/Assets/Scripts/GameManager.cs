using System.Threading;

using EnergonSoftware.Netrunner.Core;
using EnergonSoftware.Netrunner.Core.Assets;
using EnergonSoftware.Netrunner.Core.Util;

using UnityEngine;

namespace EnergonSoftware.Netrunner
{
    public sealed class GameManager : SingletonBehavior<GameManager>
    {
        private const string ConfigAssetPath = "Assets/Base/Config.asset";

        [SerializeField, ReadOnly]
        private int _mainTheadId;

        public int MainThreadId => _mainTheadId;

        [SerializeField]
        private Config _config;

        public Config Config => _config;

        private void Awake()
        {
            _mainTheadId = Thread.CurrentThread.ManagedThreadId;
            _config = AssetManager.Instance.LoadAsset<Config>(ConfigAssetPath);
        }
    }
}
