using System.Collections;
using Common;
using UnityEngine;

namespace Garden
{
    public class MainController: MonoBehaviour
    {
        public string configFileName = "Json/garden";
        public string enteringAnimationName = "GardenEntering";
        public Animator mainAnimator;
        public GameObject mainPanel;

        private PauseController _pause;
    
        private void Awake()
        {
            _pause = GetComponent<PauseController>();
            ConfigProvider<Config>.Init(configFileName);
            mainAnimator.Play(enteringAnimationName, 0, 0);
            var enteringSeconds = AnimationUtils.GetAnimationLength(mainAnimator, enteringAnimationName);
            StartCoroutine(DisableMainAnimator(enteringSeconds));
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape))
            {
                return;
            }
            
            if (mainPanel.activeSelf)
            {
                return;
            }
            
            if (_pause.IsPaused)
            {
                _pause.Resume();
            }
            else
            {
                _pause.Pause();
            }
        }

        private IEnumerator DisableMainAnimator(float delay)
        {
            yield return new WaitForSeconds(delay);
            mainAnimator.enabled = false;
        }
    }
}