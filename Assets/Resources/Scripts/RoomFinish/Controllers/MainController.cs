using System.Collections;
using Common;
using UnityEngine;

namespace RoomFinish
{
    public class MainController: MonoBehaviour
    {
        public string configFileName = "Json/roomfinish";
        public Animator mainAnimator;
        public float disableMainAnimatorAfterSeconds = 11f;   // TODO
    
        private void Awake()
        {
            MainControllerProxy.Init(this);
            ConfigProvider<Config>.Init(configFileName);
        }

        public void StopTyping()
        {
            mainAnimator.Play("StopTyping", 0, 0);
            StartCoroutine(DisableMainAnimator());
        }
        
        private IEnumerator DisableMainAnimator()
        {
            yield return new WaitForSeconds(disableMainAnimatorAfterSeconds);
            mainAnimator.enabled = false;
        }
    }
}