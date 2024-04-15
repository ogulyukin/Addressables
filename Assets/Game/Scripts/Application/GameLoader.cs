using JetBrains.Annotations;
using UnityEngine.AddressableAssets;

namespace SampleGame
{
    [UsedImplicitly]
    public sealed class GameLoader
    {
        private const string GameScene = "Game";

        public async void LoadGame()
        {
           var _ = await Addressables.LoadSceneAsync(GameScene).Task;
        }
    }
}