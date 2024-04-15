using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Game.Scripts.Locations
{
    public class TriggerController : MonoBehaviour
    {
        [SerializeField] private string addressablePath;
        [SerializeField] private Transform contentTransform;
        private bool isLoaded;
        private AsyncOperationHandle locationHandle;

        private async void OnTriggerEnter(Collider other)
        {
            if (!isLoaded)
            {
                isLoaded = true;
                var location =  Addressables.LoadAssetAsync<GameObject>(addressablePath);
                await location.Task;
                Instantiate(location.Result,contentTransform);
                locationHandle = location;
            }
        }

        private void OnDisable()
        {
            if (locationHandle.IsValid())
            {
                Addressables.Release(locationHandle);
            }
        }
    }
}
