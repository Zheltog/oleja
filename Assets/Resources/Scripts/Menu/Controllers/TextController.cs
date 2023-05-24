using Common;
using TMPro;
using UnityEngine;

namespace Menu
{
    public class TextController : MonoBehaviour
    {
        public TextMeshProUGUI newGameButtonTextBox;
        public TextMeshProUGUI creditsButtonTextBox;
        public TextMeshProUGUI exitButtonTextBox;
        public TextMeshProUGUI versionTextBox;

        private void Start()
        {
            var config = ConfigProvider<Config>.GetConfig();
            newGameButtonTextBox.text = config.newGameButtonText;
            creditsButtonTextBox.text = config.creditsButtonText;
            exitButtonTextBox.text = config.exitButtonText;
            versionTextBox.text = config.versionText;
        }
    }
}