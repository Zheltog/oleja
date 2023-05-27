using TMPro;
using UnityEngine;

namespace Menu
{
    public class QualitySettingsDropdown: MonoBehaviour
    {
        private TMP_Dropdown _dropdown;

        private void Start()
        {
            _dropdown = GetComponent<TMP_Dropdown>();
            
            _dropdown.onValueChanged.AddListener(delegate {
                ChangeLevel(_dropdown);
            });

            _dropdown.value = QualitySettings.GetQualityLevel();
        }
        
        private void ChangeLevel(TMP_Dropdown dropdown)
        {
            QualitySettings.SetQualityLevel(dropdown.value);   
        }
    }
}