using Common;
using TMPro;
using UnityEngine;

namespace Garden
{
    public class TextController: MonoBehaviour
    {
        public TextMeshProUGUI itemActionTipTextBox;
        public TextMeshProUGUI closeReadingTipTextBox;
        public TextMeshProUGUI readingTextBox;
        public GameObject panel;
    
        private string _currentInitiator = "";
        private bool _isReading;
        private Config _config;
    
        private void Start()
        {
            _config = ConfigProvider<Config>.GetConfig();
            TextControllerProxy.Initialize(this);
            closeReadingTipTextBox.text = _config.tips.closeReading;
            panel.SetActive(false);
        }
        
        private void Update()
        {
            if (_isReading && Input.GetKeyDown(KeyCode.X))
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
            var allTips = _config.tips.itemActionTips;
            var tipsForItem = allTips.Find(tips => tips.itemName == initiatorName);
            var tipForPhase = tipsForItem.tipsForPhases.Find(tip => tip.phase == currentPhase.ToString());
    
            if (tipForPhase != null)
            {
                itemActionTipTextBox.text = tipForPhase.tip;
            }
        }
    
        public void HideTip(string itemName)
        {
            if (_currentInitiator != itemName)
            {
                return;
            }
    
            _currentInitiator = null;
            itemActionTipTextBox.text = "";
        }
        
        public void StartReading(string itemName)
        {
            TimeStopper.StopTime();
            panel.SetActive(true);
            readingTextBox.text = _config.texts.Find(itemText => itemText.itemName == itemName).text;
            _isReading = true;
        }
    
        private void StopReading()
        {
            readingTextBox.text = "";
            panel.SetActive(false);
            _isReading = false;
            TimeStopper.ResumeTime();
        }
    }
}