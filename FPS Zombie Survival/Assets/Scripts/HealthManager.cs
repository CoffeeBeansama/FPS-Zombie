using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FPS_Zombie.Sounds;
using UnityStandardAssets.Characters.FirstPerson;

namespace FPS_Zombie.Player.Health
{
    [RequireComponent(typeof(AudioSource))]
    public class HealthManager : MonoBehaviour
    {

        [SerializeField] private float RunTimeHealth = 100;
        private float MaximumHealth = 100;

        [SerializeField] private GameObject GameOverScreen;
       
        [SerializeField] private Image HealthEffect;
        [SerializeField] private GameObject HurtEffect;
        [SerializeField] private AudioClip[] HurtSounds;

        [Header("Heal Effect")]
        [SerializeField] private float RegenerateTime = 3.0f;
        [SerializeField] private float RegenerateCooldown = 3.0f;
        [SerializeField] private int HealthMultiplier = 2;
        private bool StartCoolDown = false;
        private bool CanRegenerate = false;

        
        public static bool PlayerDead = false;
        private bool m_cursorIsLocked = true;
      
        private void Start()
        {
            HurtEffect.SetActive(false);
            GameOverScreen.SetActive(false);
        }



        private void Update()
        {
            LockCursor();
            HealthRegenerate();
            
            PlayerDead = false;
            if (RunTimeHealth >= 0) return;
            
            PlayerDead = true;
            GameOverScreen.SetActive(true);
            gameObject.GetComponent<FirstPersonController>().enabled = false;



            
            
              
        
        
        }
        private void LockCursor()
        {

            if (Input.GetKeyUp(KeyCode.Escape))
            {
                m_cursorIsLocked = false;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                m_cursorIsLocked = true;
            }else if(RunTimeHealth <= 0)
            {
                m_cursorIsLocked = false;
            }

            if (m_cursorIsLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else if (!m_cursorIsLocked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

        }



        public void DamagePlayer(int ZombieDamage)
        {
            if (!PlayerDead)
            {
                
                RunTimeHealth -= ZombieDamage;
                UpdateHealthEffect();
                StartCoolDown = true;
                StartCoroutine(EnableAndDisableHurtEffect());
            }
        }

      

        IEnumerator EnableAndDisableHurtEffect()
        {

            HurtEffect.SetActive(true);

            int RandomHurtSound = Random.Range(0, HurtSounds.Length);

            SoundManager.instance.PlaySound(HurtSounds[RandomHurtSound]);


            yield return new WaitForSeconds(1);

            
            HurtEffect.SetActive(false);


        }

        private void HealthRegenerate()
        {
          
            if (RunTimeHealth >= MaximumHealth) return;

            if(StartCoolDown)
            {
                RegenerateCooldown -= 1 * Time.deltaTime;

                if(RegenerateCooldown <= 0f)
                {
                    CanRegenerate = true;
                    StartCoolDown = false;
                }

            }

            if(CanRegenerate)
            {

                bool NotFullHealth = RunTimeHealth <= MaximumHealth - 0.1;
                
                if (NotFullHealth) /// Adding - 0.01 makes sure it doesnt go beyond maximum health;
                {
                    RunTimeHealth += HealthMultiplier * Time.deltaTime;
                }
                else
                {
                    UpdateHealthEffect();
                    RunTimeHealth = MaximumHealth;
                    RegenerateCooldown = RegenerateTime;
                    CanRegenerate = false;
                }
            }
          

        }

    
        private void UpdateHealthEffect()
        {
            Color HealthColor = HealthEffect.color;

            HealthColor.a = 1 - (RunTimeHealth / MaximumHealth);

            HealthEffect.color = HealthColor;

        }

       




    }
}
