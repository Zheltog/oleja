using System.Collections;
using Common;
using UnityEngine;

namespace Garden
{
    public class MainController: MonoBehaviour
    {
        public string configFileName = "Json/garden";
        public Animator mainAnimator;
        public float disableMainAnimatorAfterSeconds = 11f;   // TODO
    
        private void Awake()
        {
            ConfigProvider<Config>.Init(configFileName);
            StartCoroutine(DisableMainAnimator());
        }

        private IEnumerator DisableMainAnimator()
        {
            yield return new WaitForSeconds(disableMainAnimatorAfterSeconds);
            mainAnimator.enabled = false;
        }
    }
}