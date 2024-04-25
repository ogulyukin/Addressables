using System.Threading.Tasks;
using SampleGame;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace Game.Scripts.UI
{
    public class MenuScreenController : MonoBehaviour
    {
        private ApplicationExiter applicationExiter;
        private GameLoader gameLoader;
        private MenuScreen menuScreen;
        private const string MenuUI = "MenuScreen";
        private AsyncOperationHandle<GameObject> menuHandle;
        
        [Inject]
        public void Construct(ApplicationExiter applicationFinisher, GameLoader gmLoader)
        {
            gameLoader = gmLoader;
            applicationExiter = applicationFinisher;
        }

        private async void OnEnable()
        {
            menuHandle = Addressables.LoadAssetAsync<GameObject>(MenuUI);
            var menuUI =  await menuHandle.Task;
            menuScreen = Instantiate(menuUI, gameObject.transform).GetComponent<MenuScreen>();
            menuScreen.StartButton.onClick.AddListener(gameLoader.LoadGame);
            menuScreen.ExitButton.onClick.AddListener(applicationExiter.ExitApp);
        }

        private void OnDisable()
        {
            menuScreen.StartButton.onClick.RemoveListener(gameLoader.LoadGame);
            menuScreen.ExitButton.onClick.RemoveListener(applicationExiter.ExitApp);
            
            if (menuHandle.IsValid())
            {
                Addressables.Release(menuHandle);
            }
        }
    }
}
