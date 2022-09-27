using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS_Zombie.Weapons
{
    [RequireComponent(typeof(BoxCollider))]
    public class GunOnPlayer : MonoBehaviour
    {

       
        public int GunIndexUsing = 0;
     

        [SerializeField] private int GunPurchased;
        [SerializeField] private WeaponOnHand PlayerWeapon;
        private new BoxCollider collider;

        private GunBase GunScript;


        private void Start()
        {
            GunBase BaseScript = gameObject.transform.GetChild(0).transform.GetComponent<GunBase>();

            GunIndexUsing = 0;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            PlayerWeapon.WeaponHolding[0] = BaseScript._WeaponIndex;
            collider = GetComponent<BoxCollider>();
            collider.isTrigger = true;
        }

        private void Update()
        {

            ShufflingGunEquipped();
          
        }

        private void ShufflingGunEquipped()
        {
            GunScript = FindObjectOfType<GunBase>();

            bool canShoot = GunScript.Firing == false && !GunScript._reloading;




            if (canShoot)
            {
                if (PlayerAction.IsPressingOne)
                {
                    PlayerWeapon.SlotUsing = 0;

                    if (PlayerWeapon.WeaponHolding[1] != null)
                    {

                        gameObject.transform.GetChild(PlayerWeapon.WeaponHolding[0].GunIndex).gameObject.SetActive(true);

                        gameObject.transform.GetChild(PlayerWeapon.WeaponHolding[1].GunIndex).gameObject.SetActive(false);

                    }
                }
                else if (PlayerAction.IsPressingTwo)
                {
                    PlayerWeapon.SlotUsing = 1;

                    if (PlayerWeapon.WeaponHolding[1] != null)
                    {

                        gameObject.transform.GetChild(PlayerWeapon.WeaponHolding[1].GunIndex).gameObject.SetActive(true);

                        gameObject.transform.GetChild(PlayerWeapon.WeaponHolding[0].GunIndex).gameObject.SetActive(false);
                    }
                }
            }
        }





        private void OnTriggerEnter(Collider shop)
        {
            if(shop.gameObject.tag != "Shop") return;

            WeaponPurchase Shop = shop.GetComponent<WeaponPurchase>();

            GunPurchased = Shop.WeaponIndex;

        }

        

    }
}
