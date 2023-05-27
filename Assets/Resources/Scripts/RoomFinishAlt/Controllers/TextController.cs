using Common;
using RoomCommon;
using UnityEngine;

namespace RoomFinishAlt
{
    public class TextController : MonoBehaviour
    {
        public GameObject panel;

        private TextPrinter _printer;

        private void Start()
        {
            var config = ConfigProvider<Config>.GetConfig();
            _printer = GetComponent<TextPrinter>();
            _printer.Init(config.forumMessageLines);
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

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnPrintCompleted();
                return;
            }

            if (_printer.IsPrinting)
            {
                return;
            }

            if (_printer.IsCompleted)
            {
                OnPrintCompleted();
                return;
            }

            StartCoroutine(_printer.PrintNextLine());
        }

        private void OnPrintCompleted()
        {
            SceneLoader.LoadCredits();
        }
    }
}