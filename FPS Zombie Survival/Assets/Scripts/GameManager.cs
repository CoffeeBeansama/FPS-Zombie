using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FPS_Zombie.Enemies;

namespace FPS_Zombie
{
    public enum Game_State
    {
        SpawnZombie,
        Wait,
        NextRound
    }

    public class GameManager : MonoBehaviour
    {
        [Header("Spawn Settings")]
       
        [SerializeField] private GameObject[] Spawners;
        [SerializeField] private ZombieData Zombie_Data;

        public int ZombieAlive;
        [SerializeField] private int NumberSpawned;
        [SerializeField] private int MaxSpawnNumber;
        

        [SerializeField] private int Rounds;
        [SerializeField] private Text TimeCheck;
        [SerializeField] private Text RoundCheck;
        [SerializeField] private float CurrentTime;
        [SerializeField] private float SpawnTimeBuffer;
        [SerializeField] private float RoundTimeBuffer;

        public Game_State GameState;

    
     




        private void Start()
        {
            RoundCheck.text = Rounds.ToString();
            CurrentTime = SpawnTimeBuffer;

          
           

        }

        private void Update()
        {


            bool AllZombiesSpawned = NumberSpawned == MaxSpawnNumber;

            switch (AllZombiesSpawned) 
            {
                case true: GameState = Game_State.Wait; break;
                case false: GameState = Game_State.SpawnZombie; break;
            }

            switch(GameState)
            {
                case Game_State.SpawnZombie:
                   
                    
                    if (Rounds < 3)
                    {
                        SpawnZombie(0, 0, 5);
                    }
                    else if (Rounds < 6)
                    {
                        SpawnZombie(1, 2, 12);
                    }
                    else if (Rounds < 9)
                    {
                        SpawnZombie(2, 3, 18);
                    }
                    else if (Rounds < 12)
                    {
                        SpawnZombie(3, 4, 18);
                    }
                    else if (Rounds < 15)
                    {
                        SpawnZombie(5, 5, 1);
                    }

                    break;
                case Game_State.Wait:

                   if(ZombieAlive == 0)
                    {
                        
                        StartCoroutine(NextRound());
                    }
           
                   break;
               

            }

           

            









        }

        



        private void SpawnZombie(int FromThisNumber, int ToThisIndex,int SpawnNumber) //Spawn Zombie based on index in Zombie data: Zombie List
        {

            MaxSpawnNumber = SpawnNumber;
            
            CurrentTime -= 1 * Time.deltaTime;

            int ConstTime = Mathf.RoundToInt(CurrentTime);
            TimeCheck.text = ConstTime.ToString();

            if (CurrentTime <= 0)
            {

                int RandomZombie = Random.Range(FromThisNumber, ToThisIndex);
                int RandomSpawner = Random.Range(0, Spawners.Length);
                GameObject CreateZombie = Instantiate(Zombie_Data.RegularZombies[RandomZombie], Spawners[RandomSpawner].transform.position, Quaternion.identity);

                ZombieAlive += 1;
                NumberSpawned += 1;
                CurrentTime = SpawnTimeBuffer;
            }

        }

        IEnumerator NextRound()
        {
            NumberSpawned = 0;
            Rounds += 1;
            RoundCheck.text = Rounds.ToString();
            yield return new WaitForSeconds(RoundTimeBuffer);

            
                
            GameState = Game_State.SpawnZombie;










        }

       



    }


    
}
