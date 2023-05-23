using System.Collections;
using Common;
using UnityEngine;

namespace GameOver
{
    public class MainController : MonoBehaviour
    {
        public float durationSeconds = 3f;

        private void Awake()
        {
            StartCoroutine(ExitAfterSeconds());
        }

        IEnumerator ExitAfterSeconds()
        {
            yield return new WaitForSeconds(durationSeconds);
            SceneController.LoadMenu();
        }
    }
}