using EnergonSoftware.Netrunner.Auth;
using EnergonSoftware.Netrunner.Core;
using EnergonSoftware.Netrunner.Core.Assets;
using EnergonSoftware.Netrunner.JintekiNet;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace EnergonSoftware.Netrunner
{
    public sealed class Loader : MonoBehavior
    {
        private void Start()
        {
            CreateManagers();

// TODO: this is sort of temporary for now
            SceneManager.LoadSceneAsync(AuthManager.Instance.IsAuthenticated ? "chat" : "auth", LoadSceneMode.Additive);

            Destroy(gameObject);
        }

        private void CreateManagers()
        {
            GameObject managers = new GameObject { name = "Managers" };

// TODO: this process should be dependency-driven
            AssetManager.Create(managers);
            GameManager.Create(managers);
            JintekiNetManager.Create(managers);
            AuthManager.Create(managers);
        }
    }
}
