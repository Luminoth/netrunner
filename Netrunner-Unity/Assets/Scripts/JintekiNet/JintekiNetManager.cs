using System;

using EnergonSoftware.Netrunner.Core;

namespace EnergonSoftware.Netrunner.JintekiNet
{
// jinteki uses socket.io according to the Chrome browser tools
// the Unity Socket.IO plugin apparently requires Unity Pro :\
// so maybe building something like that from scratch is needed

    public sealed class JintekiNetManager : SingletonBehavior<JintekiNetManager>
    {
        public void Authenticate(string username, string password, Action onSuccess, Action<string> onFailure)
        {
            onSuccess?.Invoke();
        }
    }
}
