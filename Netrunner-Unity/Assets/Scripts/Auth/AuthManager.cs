using System;

using EnergonSoftware.Netrunner.Core;
using EnergonSoftware.Netrunner.Core.Util;

using UnityEngine;

namespace EnergonSoftware.Netrunner
{
    public sealed class AuthManager : SingletonBehavior<AuthManager>
    {
        [SerializeField]
        [ReadOnly]
        private bool _isAuthenticated;

        public bool IsAuthenticated => _isAuthenticated;

        public void Authenticate(string username, string password, bool saveLogin, Action onSuccess, Action<string> onFailure)
        {
            if(saveLogin) {
                PlayerPrefs.SetString("authUsername", username);
                // TODO: password
            } else {
                PlayerPrefs.DeleteKey("authUsername");
                // TODO: password
            }
            PlayerPrefsExtensions.SetBool("authSaveLogin", saveLogin);

// TODO: put this shiz in a callback to the auth process
            _isAuthenticated = true;
            onSuccess?.Invoke();
        }
    }
}
