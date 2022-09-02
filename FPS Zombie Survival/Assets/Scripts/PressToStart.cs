using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FPS_Zombie
{
    public class PressToStart : MonoBehaviour
    {

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(FadeOut());
            }
        }

        IEnumerator FadeOut()
        {

            Animation anim = gameObject.GetComponent<Animation>();
            anim.Play("MainMenu FaidOut");
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("World");

        }



    }
}
