using UnityEngine;
using System.Collections;

public class Enemies : MonoBehaviour
{

    //Base Class for Enemy Mobs
    public class Enemy
    {
        //Constructor for asssigning variables
        public Enemy (int HP, float SPD)
        {
            health = HP;
            speed = SPD;
        }

        //Health value for mob
        public int health;
        //Speed that the mob moves at
        public float speed;
    }


    //Picks a random Civillian
    public GameObject PickCivillian()
    {
        //Pick random Civ
        return TrackCivillians.civillians[Random.Range(0, TrackCivillians.civillians.Count)];
    }

    //Kills Civillian that you collided with
    public void KillCivillian(Collision2D collider2D, GameObject chosenCivillian, GameObject thisEnemy)
    {
        //Remove Civillian from the "civillians" list
        TrackCivillians.civillians.Remove(chosenCivillian);
        //Proceed to destroy civillian and this gameObject respectively
        Destroy(collider2D.gameObject);
        Destroy(thisEnemy);
    }

    //Is called every Frame
    void Update()
    {
        if (TrackCivillians.civillians.Count == 0)
        {
            GameObject[] Temp = GameObject.FindGameObjectsWithTag("Enemy");
            for (int k = 0; k < Temp.Length; k++)
            {
                Destroy(Temp[k]);
            }
        }

        Debug.Log(TrackCivillians.civillians.Count);
    }

}
