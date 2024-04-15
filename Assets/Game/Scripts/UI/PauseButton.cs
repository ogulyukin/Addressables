using Game.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace SampleGame
{
    public sealed class PauseButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        
        [SerializeField] private PauseScreenController pauseScreenController;

        private void OnEnable()
        {
            button.onClick.AddListener(pauseScreenController.Show);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(pauseScreenController.Show);
        }
    }
}