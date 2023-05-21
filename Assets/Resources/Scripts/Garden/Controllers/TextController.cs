using TMPro;
using UnityEngine;

namespace Garden
{
    public class TextController: MonoBehaviour
    {
        public TextMeshProUGUI tipText;
        public TextMeshProUGUI closeReadingTipText;
        public TextMeshProUGUI readingText;
        public GameObject readingPanel;
    
        private string _currentInitiator = "";
        private bool _isReading;
        private Config _config;
    
        private void Start()
        {
            _config = ConfigManager.GetConfig();
            TextControllerProxy.Initialize(this);
            closeReadingTipText.text = _config.tips.closeReading;
            readingPanel.SetActive(false);
        }
        
        private void Update()
        {
            if (_isReading && Input.GetKeyDown(KeyCode.Escape))
            {
                StopReading();
            }
        }
    
        public void ShowTip(string initiatorName)
        {
            if (_currentInitiator == initiatorName)
            {
                return;
            }
            
            _currentInitiator = initiatorName;
    
            var currentPhase = PhaseControllerProxy.CurrentPhase();
            var allTips = _config.tips.itemTips;
            var tipsForItem = allTips.Find(tips => tips.itemName == initiatorName);
            var tipForPhase = tipsForItem.tipsForPhases.Find(tip => tip.phase == currentPhase.ToString());
    
            if (tipForPhase != null)
            {
                tipText.text = tipForPhase.tip;
            }
        }
    
        public void HideTip(string itemName)
        {
            if (_currentInitiator != itemName)
            {
                return;
            }
    
            _currentInitiator = null;
            tipText.text = "";
        }
        
        public void StartReading(string itemName)
        {
            Time.timeScale = 0;
            readingPanel.SetActive(true);
            readingText.text = _config.texts.Find(itemText => itemText.itemName == itemName).text;
            _isReading = true;
        }
    
        private void StopReading()
        {
            readingText.text = "";
            readingPanel.SetActive(false);
            _isReading = false;
            Time.timeScale = 1;
        }
    }
}