using UnityEngine;
using System.Collections;

public class Enemies : MonoBehaviour
{

    public AudioClip slimeDeathSound;
    public AudioSource golemDeathSound;

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

    //Is called every Frame
    void Update()
    {
        //if all civillians are dead
        if (TrackMobs.civillians.Count == 0)
        {
            //Kill every Enemy
            for (int k = 0; k < TrackMobs.enemies.Count; k++)
            {
                Destroy(TrackMobs.enemies[k]);
                TrackMobs.enemies.RemoveAt(k);
            }
        }
    }


    //Picks a random Civillian
    public GameObject PickCivillian()
    {
        //Pick random Civ
        return TrackMobs.civillians[Random.Range(0, TrackMobs.civillians.Count)];
    }

    //Kills Civillian that you collided with
    public void KillCivillian(Collision2D collider2D, GameObject chosenCivillian, GameObject thisEnemy)
    {
        AudioSource.PlayClipAtPoint(slimeDeathSound, new Vector3(0,0,0), 1);
        //Remove Civillian from the "civillians" list
        TrackMobs.civillians.Remove(chosenCivillian);
        //Remove Enemy from the "enemies" list as mobs die with civillians
        TrackMobs.enemies.Remove(thisEnemy);
        //Proceed to destroy civillian and this gameObject respectively
        Destroy(collider2D.gameObject);
        Destroy(thisEnemy);
    }

}
