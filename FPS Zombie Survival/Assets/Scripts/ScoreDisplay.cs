using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FPS_Zombie.UI
{
    public class ScoreDisplay : MonoBehaviour
    {
        [SerializeField] private Scores ScoreHolder;

        private void Update()
        {
            StartCoroutine(UpdateScore(0.10f));
        }

        IEnumerator UpdateScore(float Updatetime)
        {
            yield return new WaitForSeconds(Updatetime);
            gameObject.GetComponent<Text>().text = ScoreHolder.PlayerScore.ToString();
        }
       
    }
}
