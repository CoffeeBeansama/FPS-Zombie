using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS_Zombie.Enemies
{
    public enum EnemyState
    {
    Chase,
    Attack,
    Attack2,
    Die
    }

    
    [CreateAssetMenu(fileName = "EnemyStates")]
    public class States : ScriptableObject
    {
        public GameObject Player;
        public EnemyState EnemyStates;
    }
}
