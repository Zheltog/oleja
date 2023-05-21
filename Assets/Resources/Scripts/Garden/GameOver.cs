using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Garden
{
    public class GameOver : MonoBehaviour
    {
        public float durationSeconds = 3f;

        private void Start()
        {
            StartCoroutine(ExitAfterSeconds());
        }

        IEnumerator ExitAfterSeconds()
        {
            yield return new WaitForSeconds(durationSeconds);
            SceneManager.LoadScene("SampleScene");
        }
    }
}