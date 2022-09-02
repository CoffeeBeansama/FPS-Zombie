using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FPS_Zombie.Enemies
{
    [CreateAssetMenu(fileName = "Zombie Data")]
    public class ZombieData : ScriptableObject
    {
        public GameObject[] RegularZombies;
    }
}
