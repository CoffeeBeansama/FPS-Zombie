using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS_Zombie.Weapons
{
    [CreateAssetMenu(fileName = "WeaponOnHand")]
    public class WeaponOnHand : ScriptableObject
    {
        public int SlotUsing;
        public WeaponIndex[] WeaponHolding;

        public void OnEnable()
        {
            SlotUsing = 1;
            WeaponHolding[1] = null;
        }





    }
}
