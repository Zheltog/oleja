using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Menu
{
    public class ResolutionSettingsDropdown : MonoBehaviour
    {
        private TMP_Dropdown _dropdown;
        private readonly List<Resolution> _filteredResolutions = new();
        
        private void Start()
        {
            _dropdown = GetComponent<TMP_Dropdown>();
            _dropdown.ClearOptions();
            
            var resolutions = Screen.resolutions;
            var currentRefreshRate = Screen.currentResolution.refreshRate;

            foreach (var resolution in resolutions)
            {
                if (resolution.refreshRate == currentRefreshRate)
                {
                    _filteredResolutions.Add(resolution);
                }
            }

            var options = new List<string>();
            var currentResolutionIndex = 0;

            for (var i = 0; i< _filteredResolutions.Count; i++)
            {
                var resolution = _filteredResolutions[i];
                
                var option = resolution.width + " * " + resolution.height + " " + resolution.refreshRate + " Hz";
                options.Add(option);

                if (resolution.width == Screen.width && resolution.height == Screen.height)
                {
                    currentResolutionIndex = i;
                }
            }
            
            _dropdown.AddOptions(options);
            _dropdown.value = currentResolutionIndex;
            _dropdown.RefreshShownValue();
            
            _dropdown.onValueChanged.AddListener(delegate {
                ChangeResolution(_dropdown);
            });
        }
        
        private void ChangeResolution(TMP_Dropdown dropdown)
        {
            var resolution = _filteredResolutions[dropdown.value];
            Screen.SetResolution(resolution.width, resolution.height, true);
        }
    }
}