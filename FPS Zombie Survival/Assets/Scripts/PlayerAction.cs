using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS_Zombie
{
    public static class PlayerAction 
    {

        public static KeyCode InteractButton = KeyCode.F;
        public static KeyCode ReloadingButton = KeyCode.R;
        public static KeyCode OneButton = KeyCode.Alpha1;
        public static KeyCode TwoButton = KeyCode.Alpha2;

        public static bool IsInteracting => Input.GetKey(InteractButton);
        public static bool IsReloading => Input.GetKey(ReloadingButton);
        public static bool IsPressingOne => Input.GetKey(OneButton);
        public static bool IsPressingTwo => Input.GetKey(TwoButton);

        public static bool IsFiring = Input.GetMouseButton(0);
        
    }
}
