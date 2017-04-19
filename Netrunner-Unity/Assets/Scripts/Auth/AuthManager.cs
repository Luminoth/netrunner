using System;

using EnergonSoftware.Netrunner.Core;
using EnergonSoftware.Netrunner.Core.Util;
using EnergonSoftware.Netrunner.JintekiNet;

using UnityEngine;

namespace EnergonSoftware.Netrunner.Auth
{
    public sealed class AuthManager : SingletonBehavior<AuthManager>
    {
        [SerializeField, ReadOnly]
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

            JintekiNetManager.Instance.Authenticate(username, password,
                () =>
                {
                    _isAuthenticated = true;
                    onSuccess?.Invoke();
                },
                reason =>
                {
                    _isAuthenticated = false;
                    onFailure?.Invoke(reason);
                }
            );
        }
    }
}
