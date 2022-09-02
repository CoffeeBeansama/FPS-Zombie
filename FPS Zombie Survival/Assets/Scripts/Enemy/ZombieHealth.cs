using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS_Zombie.Enemies
{
    public class ZombieHealth : MonoBehaviour
    {
        public int Health;


        public virtual void TakeDamage(int Damage)
        {
            Health -= Damage;
            

        }

    }
}   