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
        private AsyncOperationHandle<GameObject> locationHandle;

        private async void OnTriggerEnter(Collider other)
        {
            if (!isLoaded)
            {
                isLoaded = true;
                locationHandle  =  Addressables.LoadAssetAsync<GameObject>(addressablePath);
                await locationHandle .Task;
                Instantiate(locationHandle .Result,contentTransform);
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
