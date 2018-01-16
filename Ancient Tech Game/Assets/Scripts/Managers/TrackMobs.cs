using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrackMobs : MonoBehaviour
{
    //Declare Variables
    public static List<GameObject> civillians;
    public static List<GameObject> enemies;
    // Use this for initialization
    void Start ()
    {
        //Populate List with Objects with tag "Civillian"
        civillians = new List<GameObject>(GameObject.FindGameObjectsWithTag("Civillian"));

        //Populate List with Objects with tag "Enemy"
        enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
    }
}
