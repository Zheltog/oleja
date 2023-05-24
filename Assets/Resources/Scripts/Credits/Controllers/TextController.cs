using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Credits
{
    public class TextController: MonoBehaviour
    {
        public float secondsBeforeNextLine = 3f;
        public TextMeshProUGUI textBox;
        public TextMeshProUGUI menuButtonTextBox;
        
        private List<string> _textLines;
        private int _currentLine;

        private void Start()
        {
            var config = ConfigManager.GetConfig();
            menuButtonTextBox.text = config.menuButtonText;
            _textLines = config.textLines;

            StartCoroutine(PrintLines());
        }

        private IEnumerator PrintLines()
        {
            while (_currentLine < _textLines.Count)
            {
                textBox.text = _textLines[_currentLine];
                _currentLine++;
                yield return new WaitForSeconds(secondsBeforeNextLine);
            }
        }
    }
}