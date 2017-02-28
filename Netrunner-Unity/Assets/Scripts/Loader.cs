using EnergonSoftware.Netrunner.Core;

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
            AuthManager.Create(managers);
        }
    }
}
