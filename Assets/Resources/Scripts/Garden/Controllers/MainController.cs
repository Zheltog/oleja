using System.Collections;
using Common;
using UnityEngine;

namespace Garden
{
    public class MainController: MonoBehaviour
    {
        public string configFileName = "Json/garden";
        public float disableMainAnimatorAfterSeconds = 11f;   // TODO
        public Animator mainAnimator;
        public GameObject mainPanel;

        private PauseController _pause;
    
        private void Awake()
        {
            _pause = GetComponent<PauseController>();
            ConfigProvider<Config>.Init(configFileName);
            StartCoroutine(DisableMainAnimator());
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

        private IEnumerator DisableMainAnimator()
        {
            yield return new WaitForSeconds(disableMainAnimatorAfterSeconds);
            mainAnimator.enabled = false;
        }
    }
}