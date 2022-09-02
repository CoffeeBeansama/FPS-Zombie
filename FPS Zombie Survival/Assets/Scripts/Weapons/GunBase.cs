using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FPS_Zombie.Enemies;
using FPS_Zombie.Sounds;
using FPS_Zombie.Player.Health;
using TMPro;


namespace FPS_Zombie.Weapons
{
    [RequireComponent(typeof(Animation))]
    public class GunBase : MonoBehaviour
    {
        [Header("Damage")]
        [SerializeField] private int HeadDamage;
        [SerializeField] private int BodyDamage;

        [Header("Ammo")]
        [SerializeField] private int CurrentAmmo;
        [SerializeField] private int AllAmmoHolding;
        [SerializeField] private TextMeshProUGUI CurrentAmmoText;
        [SerializeField] private TextMeshProUGUI AllAmmoText;
        private int MagazineCapacity;
        private int MaximumAmmoCapacity;
 
        [SerializeField] private float ReloadTime;

        [Header("Fire Rate")]
        [SerializeField] private float FireRate = 1.2f;
        
        [Header("Range")]
        [SerializeField] private float Range = 100f;
        [Header("Effects")]
        [SerializeField] private AudioClip FireSound;
        [SerializeField] private float FlashSpeed = 1.2f;
        [SerializeField] private GameObject MuzzleFlash;
        [Header("Animation")]
        [SerializeField] private string GunAnimationName;
        [SerializeField] private string ReloadAnimation;

        [Header("Weapon ID")]
        public WeaponIndex _WeaponIndex;

        private Animation GunAnimation;

        public bool _reloading = false;
        public bool Firing = false;
        private GameObject FPS_ControllerCamera ;

        private void Awake()
        {
           
        }

        private void Start()
        {
            MagazineCapacity = CurrentAmmo;
            MaximumAmmoCapacity = AllAmmoHolding;
            GunAnimation = GetComponent<Animation>();
            FPS_ControllerCamera = GameObject.FindGameObjectWithTag("MainCamera");
            
        }

        private void Update()
        {

            

            if (!HealthManager.PlayerDead)
            {
                StartCoroutine(UpdateAmmoText());
                if (_reloading) return;


                if (HasAmmo())
                {

                    if (Input.GetMouseButton(0) && !Firing)
                    {
                       
                        StartCoroutine(Shoot());

                    }

                }
                else
                {
                    if (StillHasAmmoHolding())

                        StartCoroutine("ReloadWeapon");
                }

            }
        }

        IEnumerator UpdateAmmoText()
        {
            yield return new WaitForSeconds(0.10f);
            CurrentAmmoText.text = CurrentAmmo.ToString();
            AllAmmoText.text = AllAmmoHolding.ToString();

        }

        IEnumerator Shoot()
        {
            Firing = true;
            CurrentAmmo -= 1;
            SoundManager.instance.PlaySound(FireSound);
            GunAnimation.Play(GunAnimationName);
            MuzzleFlash.SetActive(true);
           

            yield return new WaitForSeconds(FlashSpeed);

            MuzzleFlash.SetActive(false);
            
            RaycastHit Hit;

            if (Physics.Raycast(FPS_ControllerCamera.transform.position,FPS_ControllerCamera.transform.TransformDirection(Vector3.forward), out Hit, Range))
            {

                ZombieHealth ZombieHealth_Script = Hit.transform.GetComponent<ZombieHealth>();

                if (ZombieHealth_Script != null)
                {
                    ZombieHealth_Script.TakeDamage(BodyDamage);
                }
            }

            yield return new WaitForSeconds(FireRate);
           
            Firing = false;

        }


       

        IEnumerator ReloadWeapon()
        {
            _reloading = true;
            GunAnimation.Play(ReloadAnimation);
         
          
            yield return new WaitForSeconds(ReloadTime);
            CurrentAmmo = MagazineCapacity;

            AllAmmoHolding -= MagazineCapacity;


            _reloading = false;




        }

        

        private bool HasAmmo()
        {
            if (CurrentAmmo > 0)
            {
                return true;

            }

            return false;

        }

        private bool StillHasAmmoHolding()
        {
            if ( AllAmmoHolding != 0)
            {
                return true;

            }

            return false;

        }

        public void AmmoAdd()
        {
            CurrentAmmo = MagazineCapacity;
            AllAmmoHolding = MaximumAmmoCapacity;


        }

       
        


        
        
    }
}