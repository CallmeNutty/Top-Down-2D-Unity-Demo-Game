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
    public class Firearm : Weapon
    {
        public bool automatic;
    }

    public Firearm firearm;

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
