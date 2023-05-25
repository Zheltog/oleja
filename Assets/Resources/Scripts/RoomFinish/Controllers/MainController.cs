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
        public float blackScreenSeconds = 5f;
    
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

        public void ToBeContinued()
        {
            mainAnimator.enabled = true;
            mainAnimator.Play("BlackScreen", 0, 0);
            StartCoroutine(LoadCreditsAfterBlackScreen());
        }
        
        private IEnumerator DisableMainAnimator()
        {
            yield return new WaitForSeconds(disableMainAnimatorAfterSeconds);
            mainAnimator.enabled = false;
        }

        private IEnumerator LoadCreditsAfterBlackScreen()
        {
            yield return new WaitForSeconds(blackScreenSeconds);
            SceneLoader.LoadCredits();
        }
    }
}