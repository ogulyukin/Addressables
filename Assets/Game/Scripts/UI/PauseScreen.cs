using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SampleGame
{
    public sealed class PauseScreen : MonoBehaviour
    {
        [SerializeField] private Button resumeButton;
        
        [SerializeField] private Button exitButton;

        public Button ResumeButton => resumeButton;

        public Button ExitButton => exitButton;
    }
}