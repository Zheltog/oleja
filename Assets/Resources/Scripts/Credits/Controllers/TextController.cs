using System.Collections;
using System.Collections.Generic;
using Common;
using TMPro;
using UnityEngine;

namespace Credits
{
    public class TextController: MonoBehaviour
    {
        public float secondsBeforeNextLine = 3f;
        public TextMeshProUGUI creditsTextBox;
        public TextMeshProUGUI menuButtonTextBox;
        
        private List<string> _creditsLines;
        private int _currentLine;

        private void Start()
        {
            var config = ConfigProvider<Config>.GetConfig();
            menuButtonTextBox.text = config.menuButtonText;
            _creditsLines = config.creditsLines;

            StartCoroutine(PrintLines());
        }

        private IEnumerator PrintLines()
        {
            while (_currentLine < _creditsLines.Count)
            {
                creditsTextBox.text = _creditsLines[_currentLine];
                _currentLine++;
                yield return new WaitForSeconds(secondsBeforeNextLine);
            }
        }
    }
}