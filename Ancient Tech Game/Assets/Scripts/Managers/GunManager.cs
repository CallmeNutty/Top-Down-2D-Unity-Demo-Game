using UnityEngine;
using System.Collections;

public class GunManager : MonoBehaviour
{

    [System.Serializable]
    public class Weapon
    {
        public string name;
        public int damage;
    }

    [System.Serializable]
    public class Melee : Weapon
    {
        public int swingSpeed;
    }
}
