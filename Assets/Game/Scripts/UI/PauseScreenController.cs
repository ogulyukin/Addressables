using SampleGame;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace Game.Scripts.UI
{
    public class PauseScreenController : MonoBehaviour
    {
        private MenuLoader menuLoader;
        private PauseScreen pauseScreen;
        private const string PauseUI = "PauseScreen";
        private AsyncOperationHandle<GameObject> menuHandle;

        [Inject]
        public void Construct(MenuLoader mnLoader)
        {
            menuLoader = mnLoader;
        }

        private async void OnEnable()
        {
            menuHandle = Addressables.LoadAssetAsync<GameObject>(PauseUI);
            var pauseUI = await menuHandle.Task;
            pauseScreen = Instantiate(pauseUI, gameObject.transform).GetComponent<PauseScreen>();
            pauseScreen.gameObject.SetActive(false);
            pauseScreen.ResumeButton.onClick.AddListener(Hide);
            pauseScreen.ExitButton.onClick.AddListener(menuLoader.LoadMenu);
        }

        private void OnDisable()
        {
            pauseScreen.ResumeButton.onClick.RemoveListener(Hide);
            pauseScreen.ExitButton.onClick.RemoveListener(menuLoader.LoadMenu);
            
            if (menuHandle.IsValid())
            {
                Addressables.Release(menuHandle);
            }
        }
        
        public void Show()
        {
            Time.timeScale = 0; //KISS
            pauseScreen.gameObject.SetActive(true);
        }

        private void Hide()
        {
            Time.timeScale = 1; //KISS
            pauseScreen.gameObject.SetActive(false);
        }
    }
}
