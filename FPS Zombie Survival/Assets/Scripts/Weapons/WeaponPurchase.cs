using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace FPS_Zombie.Weapons
{ 
   
    [RequireComponent(typeof(BoxCollider))]
    public class WeaponPurchase : MonoBehaviour
    {

        
        [SerializeField] private Scores ScoreData;
        [SerializeField] private GameObject FPS_Controller;
        [SerializeField] private int PointsRequired;
        [SerializeField] private Text ShopText;


     
        public int WeaponIndex;

        [SerializeField] private WeaponIndex GunInventoryIndex;
        [SerializeField] private WeaponOnHand WeaponInventory;
        
        public bool PlayerPurchase { get; private set; }
        private bool PlayerTouchingShop;
        private BoxCollider GunCollider;

        private void Start()
        {
            GunCollider = GetComponent<BoxCollider>();
            GunCollider.isTrigger = true;

        }

        private void Update()
        {
            if (!PlayerTouchingShop) return;

            if(Input.GetKeyDown(KeyCode.F))
            {
                ShopText.text = "";
                PurchaseWeapon(PointsRequired);
                
            }


        }

        private void OnTriggerEnter(Collider player)
        {
            if(player.gameObject.CompareTag("Player"))
            {
                PlayerPurchase = true;
                PlayerTouchingShop = true;
                ShopText.text = ("Points required: " + PointsRequired.ToString());

            }
        }


        private void PurchaseWeapon(int GunCost)
        {

            GunOnPlayer GunScript = FPS_Controller.GetComponent<GunOnPlayer>();
            if (ScoreData.PlayerScore < GunCost) return;
            WeaponInventory.WeaponHolding[WeaponInventory.SlotUsing] = GunInventoryIndex;
            FPS_Controller.transform.GetChild(GunScript.GunIndexUsing).gameObject.SetActive(false);
        

            GunScript.GunIndexUsing = WeaponIndex;
           
            FPS_Controller.transform.GetChild(WeaponIndex).gameObject.SetActive(true);
            ScoreData.PlayerScore -= PointsRequired;







        }

      


        


        private void OnTriggerExit(Collider player)
        {
            if (player.gameObject.CompareTag("Player"))
            {
            
                PlayerTouchingShop = false;
                ShopText.text = "";

            }
        }



    }
}
