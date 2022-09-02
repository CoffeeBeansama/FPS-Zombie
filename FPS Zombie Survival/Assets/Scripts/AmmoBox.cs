using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FPS_Zombie.Weapons;

namespace FPS_Zombie
{
    public class AmmoBox : MonoBehaviour
    {

        private void Start()
        {
            Destroy(gameObject, 30f);
        }
        public void OnTriggerEnter(Collider player)
        {
           
            if(player.gameObject.CompareTag("MainCamera"))
            {
                player.transform.GetChild(0).GetComponent<GunBase>().AmmoAdd();
                Destroy(gameObject);
               

            }
        }
    }
}
