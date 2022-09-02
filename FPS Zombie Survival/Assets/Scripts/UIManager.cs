using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FPS_Zombie.UI
{
    public class UIManager : MonoBehaviour
    {
       

        public void RestartGame()
        {
            SceneManager.LoadScene("World");

        }

        public void BackToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
            
        }
    }
}
