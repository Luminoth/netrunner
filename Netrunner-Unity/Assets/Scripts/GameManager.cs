using System;
using System.Collections.Generic;
using System.Linq;
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

        private readonly Queue<Action> _mainThreadActions = new Queue<Action>();

        private void Awake()
        {
            _mainTheadId = Thread.CurrentThread.ManagedThreadId;
            _config = AssetManager.Instance.LoadAsset<Config>(ConfigAssetPath);
        }

        private void Update()
        {
            lock(_mainThreadActions) {
                while(_mainThreadActions.Any()) {
                    _mainThreadActions.Dequeue().Invoke();
                }
            }
        }

        // NOTE: this could be an IEnumerable that kicks off as a coroutine in Update()
        // rather than being an action, so that we don't block the main thread
        public void RunOnMainThread(Action action)
        {
            lock(_mainThreadActions) {
                _mainThreadActions.Enqueue(action);
            }
        }
    }
}
