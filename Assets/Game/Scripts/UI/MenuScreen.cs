using UnityEngine;
using UnityEngine.UI;

namespace SampleGame
{
    public sealed class MenuScreen : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button exitButton;

        public Button StartButton => startButton;
        public Button ExitButton => exitButton;

    }
}