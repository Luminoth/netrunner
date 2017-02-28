using EnergonSoftware.Netrunner.Core;

using UnityEngine;
using UnityEngine.UI;

namespace EnergonSoftware.Netrunner.UI
{
    public sealed class Authentication : MonoBehavior
    {
        [SerializeField]
        private InputField _usernameInput;

        [SerializeField]
        private InputField _passwordInput;

#region Event Handlers
        public void OnLogin()
        {
Debug.Log("login " + _usernameInput.text);
        }
#endregion
    }
}
