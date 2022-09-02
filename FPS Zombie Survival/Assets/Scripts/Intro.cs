using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FPS_Zombie
{
    public class Intro : MonoBehaviour
    {
        [SerializeField] private float Timer;
        
        [SerializeField] private GameObject BlackScreen;

        private void Start()
        {
            
            StartCoroutine(IntroPlay());
        }

        IEnumerator IntroPlay()
        {
            yield return new WaitForSeconds(Timer);
            BlackScreen.SetActive(true);
            yield return new WaitForSeconds(1f);

            SceneManager.LoadScene("MainMenu");
        }
    }
}
