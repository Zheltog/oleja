using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RoomCommon
{
    public class TextPrinter: MonoBehaviour
    {
        public TextMeshProUGUI textBox;
        public float secondsBeforeNextSymbol = 0.075f;
        public float delayMultiplier = 5;

        public bool IsPrinting { get; private set; }
        public bool IsCompleted { get; private set; }
        
        private AudioController _audio;
        private List<string> _textLines;
        private string _currentText = "";
        private int _currentLineIndex;

        private void Start()
        {
            _audio = GetComponent<AudioController>();
        }

        public void Init(List<string> textLines)
        {
            _textLines = textLines;
        }
        
        public IEnumerator PrintNextLine()
        {
            if (IsCompleted)
            {
                yield break;
            }
            
            IsPrinting = true;

            var chars = _textLines[_currentLineIndex].ToCharArray();
            var prevChar = ' ';

            foreach (var currentChar in chars)
            {
                yield return new WaitForSeconds(GetDelay(prevChar, currentChar));

                if (!char.IsWhiteSpace(currentChar))
                {
                    _audio.PlayTextSound();
                }

                _currentText += currentChar;
                textBox.text = _currentText;
                prevChar = currentChar;
            }

            _currentLineIndex++;
            IsPrinting = false;

            if (_currentLineIndex == _textLines.Count)
            {
                IsCompleted = true;
            }
        }
        
        private float GetDelay(char prevChar, char nextChar)
        {
            if (char.IsPunctuation(prevChar) || nextChar == '\n')
            {
                return secondsBeforeNextSymbol * delayMultiplier;
            }

            return secondsBeforeNextSymbol;
        }
    }
}