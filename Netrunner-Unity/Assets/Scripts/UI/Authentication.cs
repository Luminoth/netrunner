using EnergonSoftware.Netrunner.Auth;
using EnergonSoftware.Netrunner.Core;
using EnergonSoftware.Netrunner.Core.Util;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace EnergonSoftware.Netrunner.UI
{
    public sealed class Authentication : MonoBehavior
    {
#region Controls
        #pragma warning disable 0649
        [SerializeField]
        private InputField _usernameInput;

        [SerializeField]
        private InputField _passwordInput;

        [SerializeField]
        private Toggle _saveLoginToggle;

        [SerializeField]
        private Core.UI.Text _errorText;

        [SerializeField]
        private Button _loginButton;
        #pragma warning restore 0649
#endregion

        private void Awake()
        {
            DisableErrorText();
        }

        private void Start()
        {
            _usernameInput.text = PlayerPrefs.GetString("authUsername");
            // TODO: password
            _saveLoginToggle.isOn = PlayerPrefsExtensions.GetBool("authSaveLogin", true);
        }

        private void SetInteractable(bool interactable)
        {
            _usernameInput.interactable = interactable;
            _passwordInput.interactable = interactable;
            _saveLoginToggle.interactable = interactable;
            _loginButton.interactable = interactable;
        }

        private void EnableErrorText(string error)
        {
            _errorText.text = error;
            _errorText.gameObject.SetActive(true);
        }

        private void DisableErrorText()
        {
            _errorText.text = string.Empty;
            _errorText.gameObject.SetActive(false);
        }

#region Event Handlers
        public void OnLogin()
        {
            SetInteractable(false);
            DisableErrorText();

            AuthManager.Instance.Authenticate(_usernameInput.text, _passwordInput.text, _saveLoginToggle.isOn,
                () =>
                {
                    SceneManager.LoadSceneAsync("chat", LoadSceneMode.Additive);
                    SceneManager.UnloadSceneAsync("auth");
                },
                reason =>
                {
                    EnableErrorText($"Authentication Failed: ${reason}");
                    SetInteractable(true);
                }
            );
        }
#endregion
    }
}
