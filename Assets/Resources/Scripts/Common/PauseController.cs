using System;
using TMPro;
using UnityEngine;

namespace Common
{
    public class PauseController: MonoBehaviour
    {
        public string configFileName = "Json/pause";
        public bool IsPaused { get; private set; }
        public TextMeshProUGUI resumeButtonTextBox;
        public TextMeshProUGUI exitButtonTextBox;
        public GameObject pausePanel;

        private Config _config;

        private void Awake()
        {
            ConfigProvider<Config>.Init(configFileName);
            _config = ConfigProvider<Config>.GetConfig();
            resumeButtonTextBox.text = _config.resumeButtonText;
            exitButtonTextBox.text = _config.exitButtonText;
        }

        public void Pause()
        {
            pausePanel.SetActive(true);
            TimeStopper.StopTime();
            IsPaused = true;
        }

        public void Resume()
        {
            pausePanel.SetActive(false);
            TimeStopper.ResumeTime();
            IsPaused = false;
        }

        public void Exit()
        {
            SceneLoader.LoadMenu();
        }

        [Serializable]
        public class Config
        {
            public string resumeButtonText;
            public string exitButtonText;
        }
    }
}