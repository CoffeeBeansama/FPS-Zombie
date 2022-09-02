using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FPS_Zombie.Enemies;

namespace FPS_Zombie
{

    [RequireComponent(typeof(SphereCollider))]
    public class Nuke : MonoBehaviour
    {

        private GameObject[] Zombie;

        private void Start()
        {
            Destroy(gameObject, 30f);

        }
        private void Update()
        {
            Zombie = GameObject.FindGameObjectsWithTag("Zombie");

        }

        private void OnTriggerEnter(Collider player)
        {
            if(player.gameObject.CompareTag("Player"))
            {
                for(int i = 0; i < Zombie.Length; i++)
                {
                    Zombie[i].GetComponent<Zombie>().Nuke();
                }

                Destroy(gameObject, 0.10f);


                
            }

        }
    }
}
