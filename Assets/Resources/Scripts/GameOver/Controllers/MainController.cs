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

        private IEnumerator ExitAfterSeconds()
        {
            yield return new WaitForSeconds(durationSeconds);
            SceneLoader.LoadMenu();
        }
    }
}