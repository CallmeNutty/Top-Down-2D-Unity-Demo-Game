using UnityEngine;
using System.Collections;

public class SlimeScript : MonoBehaviour
{

    //Declare Variables
    [SerializeField]
    private float runSpeed;

    [SerializeField]
    private Enemies enemies;
    private GameObject chosenCivillian;

    Enemies.Enemy Slime = new Enemies.Enemy(10, 1);

    //Collisions with Civillians
    private void OnCollisionEnter2D(Collision2D coll)
    {
        //If collided with chosenCivillian
        if (coll.gameObject.tag == "Civillian")
        {
            TrackCivillians.civillians.Remove(chosenCivillian);
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //If not currently targeting a Civillian
        if (chosenCivillian == null)
        {
            chosenCivillian = TrackCivillians.civillians[Random.Range(0, TrackCivillians.civillians.Count)]; //Pick random Civ
        }
        //Otherwise if you are targeting a civillian
        else
        {
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, chosenCivillian.transform.position, Slime.speed * Time.deltaTime); //Move towards Civ
        }
    }
}
