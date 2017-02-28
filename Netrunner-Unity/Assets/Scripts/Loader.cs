using EnergonSoftware.Netrunner.Core;

using UnityEngine.SceneManagement;

namespace EnergonSoftware.Netrunner
{
    public sealed class Loader : MonoBehavior
    {
        private void Start()
        {
// TODO: this is sort of temporary for now
            SceneManager.LoadSceneAsync("auth", LoadSceneMode.Additive);

            Destroy(gameObject);
        }
    }
}
