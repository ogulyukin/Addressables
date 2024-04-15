using JetBrains.Annotations;
using UnityEngine.SceneManagement;

namespace SampleGame
{
    [UsedImplicitly]
    public sealed class MenuLoader
    {
        private const string MenuScene = "Menu";

        //Сцена с меню является основой проекта. (Entry Point)

        public void LoadMenu()
        {
            SceneManager.LoadScene(MenuScene);
        }
    }
}