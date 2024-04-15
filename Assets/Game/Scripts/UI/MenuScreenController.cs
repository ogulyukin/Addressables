using System.Threading.Tasks;
using SampleGame;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Game.Scripts.UI
{
    public class MenuScreenController : MonoBehaviour
    {
        private ApplicationExiter applicationExiter;
        private GameLoader gameLoader;
        private MenuScreen menuScreen;
        private const string MenuUI = "MenuScreen";
        
        [Inject]
        public void Construct(ApplicationExiter applicationFinisher, GameLoader gmLoader)
        {
            gameLoader = gmLoader;
            applicationExiter = applicationFinisher;
        }

        private async void OnEnable()
        {
            var menuUI =  await Addressables.LoadAssetAsync<GameObject>(MenuUI).Task;
            menuScreen = Instantiate(menuUI, gameObject.transform).GetComponent<MenuScreen>();
            menuScreen.StartButton.onClick.AddListener(gameLoader.LoadGame);
            menuScreen.ExitButton.onClick.AddListener(applicationExiter.ExitApp);
        }

        private void OnDisable()
        {
            menuScreen.StartButton.onClick.RemoveListener(gameLoader.LoadGame);
            menuScreen.ExitButton.onClick.RemoveListener(applicationExiter.ExitApp);
        }
    }
}
