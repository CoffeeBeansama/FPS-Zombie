using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using FPS_Zombie.Player.Health;


namespace FPS_Zombie.Enemies
{
    
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(Animation))]
    [RequireComponent(typeof(ZombieHealth))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class Zombie : MonoBehaviour
    {
        private GameObject Player;
        [SerializeField] private EnemyState EnemyState;
        [SerializeField] private int ZombieDamage;
        [SerializeField] private int MovementSpeed;
        [SerializeField] private int ScoreWhenKilled = 100;
        
        [SerializeField] private Scores ScoreData;
      

        [Header("Animations")]
       
        [SerializeField] private string ChaseAnimation;
        [SerializeField] private string AttackAnimation;
        [SerializeField] private string DeathAnimation;


        [SerializeField] private float DeathAnimationSeconds;


        [Header("Item Spawn")]
        [SerializeField] private SpawnItem ItemHolder;
        [SerializeField, Range(0f,1f)] private float ItemSpawnChance = 0.1f;


        public bool Attacking;

        private GameManager Gamemanager;

        private Animation ZombieAnimation;
        private ZombieHealth This_Zombie_Health;
        private NavMeshAgent This_Zombie_Navigation;
        private float ReachDistance = 2f;
        private float AttackReach = 2f;
        private bool ScoreAdded;


        private HealthManager _healthManager;


        private void Start()
        {
            Gamemanager = FindObjectOfType<GameManager>();
            _healthManager = FindObjectOfType<HealthManager>();
            This_Zombie_Health = GetComponent<ZombieHealth>();
            This_Zombie_Navigation = GetComponent<NavMeshAgent>();
            ZombieAnimation = GetComponent<Animation>();
            EnemyState = EnemyState.Chase;
           
            Player = GameObject.FindGameObjectWithTag("Player");

          
            
        }


        private void Update()
        {

            if(This_Zombie_Health.Health <= 0)
            {
                EnemyState = EnemyState.Die;
            }



            switch(EnemyState)
            {
                case EnemyState.Chase: ChaseState(); break;
                case EnemyState.Attack: AttackOneState(); Attacking = true; break;
                case EnemyState.Attack2: break;
                case EnemyState.Die: DeathState(); break;
            }

        }

        private void ChaseState()
        {

            This_Zombie_Navigation.SetDestination(Player.transform.position);
            ZombieAnimation.Play(ChaseAnimation);
            This_Zombie_Navigation.speed = MovementSpeed;


            if(InAttackRange())
            {
                
                EnemyState = EnemyState.Attack;
            }

        
        }

        private void AttackOneState()
        {
            This_Zombie_Navigation.enabled = false;
            ZombieAnimation.Play(AttackAnimation);

            bool PlayerOutOfRange = !InAttackRange() && !Attacking;
            if (PlayerOutOfRange)
            {
                This_Zombie_Navigation.enabled = true;
                EnemyState = EnemyState.Chase;
            }

        }
        private void AttackTwoState()
        {

        }

        private void DeathState()
        {
            

            ZombieAnimation.Play(DeathAnimation);
            This_Zombie_Navigation.enabled = false;

            if(ScoreAdded) return;
            ScoreData.PlayerScore += ScoreWhenKilled;
            ScoreAdded = true;

            if(Gamemanager == null) return;
            
            Gamemanager.ZombieAlive -= 1;
            
            
            Destroy(gameObject, DeathAnimationSeconds );

        }

        private void OnDestroy()
        {
            DropItem(ItemSpawnChance);
        }

        private void DropItem(float DropChance)
        {
            bool LuckyItemSpawn = ItemHolder.SpawnnableObjects.Length > 0 && Random.value < DropChance;

            if (LuckyItemSpawn)
            {
                int RandomItem = Random.Range(0, ItemHolder.SpawnnableObjects.Length);

                GameObject ItemSpawn = Instantiate(ItemHolder.SpawnnableObjects[RandomItem], transform.GetChild(2).transform.position, Quaternion.identity);
            }
        }

        private bool InAttackRange()
        {

            if(Vector3.Distance(transform.position,Player.transform.position) <= ReachDistance)
            {
                return true;
            }

            return false;
        }

        public void EndAttackState()
        {
            Attacking = false;
        }

        public void ZombieDamagePlayer()
        {
            if(InZombieAttackReach())
            {
                Debug.Log("dAMAGE");
                _healthManager.DamagePlayer(ZombieDamage);
            }

        }



        private bool InZombieAttackReach()
        {
            if(Vector3.Distance(transform.position, Player.transform.position) <= AttackReach)
            {
                return true;
            }

            return false;
        }

        public void Nuke()
        {
            EnemyState = EnemyState.Die;
        }


        
      
    }
}