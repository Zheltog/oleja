using System.Collections;
using System.Collections.Generic;
using Common;
using TMPro;
using UnityEngine;

namespace RoomFinish
{
    public class TextController : MonoBehaviour
    {
        public GameObject panel;
        public TextMeshProUGUI textBox;
        public float secondsBeforeNextSymbol = 0.075f;
        public float delayMultiplier = 5;
        public float pitchRangeMin = 0.7f;
        public float pitchRangeMax = 0.8f;

        private AudioController _audio;
        private List<string> _forumMessageLines;
        private string _currentText = "";
        private int _currentLineIndex;
        private bool _isPrinting;

        private void Start()
        {
            var config = ConfigProvider<Config>.GetConfig();
            _forumMessageLines = config.forumMessageLines;
            _audio = GetComponent<AudioController>();
        }

        private void Update()
        {
            if (!panel.activeSelf)
            {
                return;
            }
            
            if (!Input.anyKeyDown ||
                Input.GetMouseButtonDown(0) ||
                Input.GetMouseButtonDown(1) ||
                Input.GetMouseButtonDown(2))
            {
                return;
            }

            if (_isPrinting)
            {
                return;
            }

            if (_currentLineIndex == _forumMessageLines.Count)
            {
                SceneLoader.LoadGameOver();
                return;
            }

            StartCoroutine(PrintNextLine());
        }

        private IEnumerator PrintNextLine()
        {
            _isPrinting = true;

            var chars = _forumMessageLines[_currentLineIndex].ToCharArray();
            var prevChar = ' ';

            foreach (var currentChar in chars)
            {
                yield return new WaitForSeconds(GetDelay(prevChar, currentChar));

                if (!char.IsWhiteSpace(currentChar))
                {
                    _audio.PlayTextSound(pitchRangeMin, pitchRangeMax);
                }

                _currentText += currentChar;
                textBox.text = _currentText;
                prevChar = currentChar;
            }

            _currentLineIndex++;
            _isPrinting = false;
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