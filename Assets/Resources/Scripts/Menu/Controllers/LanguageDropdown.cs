using Common;
using TMPro;
using UnityEngine;

namespace Menu
{
    public class LanguageDropdown: MonoBehaviour
    {
        public string menuConfigFileName = "menu";
        
        private TMP_Dropdown _dropdown;

        private void Awake()
        {
            _dropdown = GetComponent<TMP_Dropdown>();
            _dropdown.ClearOptions();

            if (!LanguageInfoHolder.IsInitialized())
            {
                LanguageInfoHolder.Initialize();
            }
            
            ConfigProvider<Config>.Init(menuConfigFileName);

            _dropdown.AddOptions(LanguageInfoHolder.GetAvailableLanguages());
            _dropdown.value = LanguageInfoHolder.GetCurrentLanguageIndex();
            _dropdown.RefreshShownValue();
            
            _dropdown.onValueChanged.AddListener(delegate {
                ChangeLanguage(_dropdown);
            });
        }
        
        private void ChangeLanguage(TMP_Dropdown dropdown)
        {
            LanguageInfoHolder.SetCurrentLanguageIndex(dropdown.value);
            SceneLoader.LoadMenu();
        }
    }
}