using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS_Zombie
{
    [CreateAssetMenu(fileName = "Score Manager")]
    public class Scores : ScriptableObject,ISerializationCallbackReceiver
    {

        public int PlayerScore;
        
        public void OnAfterDeserialize()
        {
            PlayerScore = 0;
        }

        public void OnBeforeSerialize()
        {

        }
        
        public void AddScore(int NumbersToAdd)
        {
            PlayerScore += NumbersToAdd;
        }
    }
}