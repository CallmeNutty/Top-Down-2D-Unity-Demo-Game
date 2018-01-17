using UnityEngine;
using System.Collections;

public class FirearmManager : GunManager
{

    [System.Serializable]
    public class Firearm : Weapon
    {
        public bool automatic;
    }

    public Firearm firearm;
}
