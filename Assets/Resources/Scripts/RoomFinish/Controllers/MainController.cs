using System.Collections;
using Common;
using UnityEngine;

namespace RoomFinish
{
    public class MainController: MonoBehaviour
    {
        public string configFileName = "Json/roomfinish";
        public string standingUpAnimationName = "StopTyping";
        public Player player;
        public Animator mainAnimator;
        public float blackScreenSeconds = 5f;
    
        private void Awake()
        {
            MainControllerProxy.Init(this);
            ConfigProvider<Config>.Init(configFileName);
        }

        public void StopTyping()
        {
            mainAnimator.Play(standingUpAnimationName, 0, 0);
            var standingUpSeconds = AnimationUtils.GetAnimationLength(mainAnimator, standingUpAnimationName);
            StartCoroutine(DisableMainAnimator(standingUpSeconds));
        }

        public void ToBeContinued()
        {
            mainAnimator.enabled = true;
            player.enabled = false;
            mainAnimator.Play("BlackScreen", 0, 0);
            StartCoroutine(LoadCreditsAfterBlackScreen());
        }
        
        private IEnumerator DisableMainAnimator(float delay)
        {
            yield return new WaitForSeconds(delay);
            mainAnimator.enabled = false;
        }

        private IEnumerator LoadCreditsAfterBlackScreen()
        {
            yield return new WaitForSeconds(blackScreenSeconds);
            SceneLoader.LoadCredits();
        }
    }
}