using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FPS_Zombie.Weapons;

namespace FPS_Zombie
{
    [RequireComponent(typeof(SphereCollider))]
    public class Items : MonoBehaviour
    {
        private Animation ItemAnimation;


        public virtual void OnTriggerEnter(Collider player)
        {
            

            if (player.gameObject.CompareTag("Player"))
            {







                Destroy(gameObject);




            }
          

        }

        

    }
}
