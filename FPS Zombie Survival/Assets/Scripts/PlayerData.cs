using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS_Zombie
{
    public class PlayerData : ScriptableObject
    {
        private GameObject[] GunOnPlayer;


        private void OnEnable()
        {
           for(int i = 0; i < GunOnPlayer.Length; i++)
            {
                GunOnPlayer[i] = null;
            }
        }
    }
}
