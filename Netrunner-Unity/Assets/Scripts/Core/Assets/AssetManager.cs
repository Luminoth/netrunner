using UnityEngine;

namespace EnergonSoftware.Netrunner.Core.Assets
{
    public sealed class AssetManager : SingletonBehavior<AssetManager>
    {
#region Resources
        public T LoadResource<T>(string resourcePath) where T: UnityEngine.Object
        {
            return Resources.Load<T>(resourcePath);
        }

        public GameObject LoadResourcePrefab(string resourcePath)
        {
            return LoadResource<GameObject>(resourcePath);
        }

        public GameObject LoadAndInstantiateResourcePrefab(string resourcePath)
        {
            GameObject prefab = LoadResourcePrefab(resourcePath);
            return null == prefab ? null : Instantiate(prefab);
        }

        public T LoadAndInstantiateResourcePrefab<T>(string resourcePath) where T: Component
        {
            GameObject prefabInstance = LoadAndInstantiateResourcePrefab(resourcePath);
            return prefabInstance?.GetComponent<T>();
        }
#endregion

#region Assets
        public T LoadAsset<T>(string assetPath) where T: UnityEngine.Object
        {
#if UNITY_EDITOR
            return UnityEditor.AssetDatabase.LoadAssetAtPath<T>(assetPath);
#else
            // TODO
            throw new System.NotImplementedException();
#endif
        }

        public GameObject LoadPrefab(string assetPath)
        {
            return LoadAsset<GameObject>(assetPath);
        }

        public GameObject LoadAndInstantiatePrefab(string assetPath)
        {
            GameObject prefab = LoadPrefab(assetPath);
            return null == prefab ? null : Instantiate(prefab);
        }

        public T LoadAndInstantiatePrefab<T>(string assetPath) where T: Component
        {
            GameObject prefabInstance = LoadAndInstantiatePrefab(assetPath);
            return prefabInstance?.GetComponent<T>();
        }
#endregion
    }
}
