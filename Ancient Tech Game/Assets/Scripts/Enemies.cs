using UnityEngine;
using System.Collections;

public class Enemies : MonoBehaviour
{
    
    //Base Class for Enemy Mobs
    public class Enemy
    {
        //Constructor for asssigning variables
        public Enemy (int HP, int SPD)
        {
            health = HP;
            speed = SPD;
        }

        //Health value for mob
        public int health;
        //Speed that the mob moves at
        public int speed;
    }


    //Picks a random Civillian
    public GameObject PickCivillian()
    {
        //Pick random Civ
        return TrackCivillians.civillians[Random.Range(0, TrackCivillians.civillians.Count)];
    }

    //Kills Civillian that you collided with
    public void KillCivillian(Collision2D collider2D, GameObject chosenCivillian)
    {
        //Remove Civillian from the "civillians" list
        TrackCivillians.civillians.Remove(chosenCivillian);
        //Proceed to destroy civillian and this gameObject respectively
        Destroy(collider2D.gameObject);
        Destroy(gameObject);
    }
}
