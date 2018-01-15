using UnityEngine;
using System.Collections;

public class SlimeScript : MonoBehaviour
{

    //Declare Variables
    [SerializeField]
    private Enemies Enemies;
    private GameObject chosenCivillian;

    //Create an instance of the "Enemy" base class
    Enemies.Enemy Slime = new Enemies.Enemy(10, 1);

    //Collisions with Civillians
    private void OnCollisionEnter2D(Collision2D coll)
    {

        //If collided with chosenCivillian
        if (coll.gameObject.tag == "Civillian")
        {
            //Kill civillian that was collided with
            Enemies.KillCivillian(coll, chosenCivillian, gameObject);
        }
    }

    void Start()
    {
        Enemies = GameObject.FindGameObjectWithTag("GameController").GetComponent<Enemies>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //If not currently targeting a Civillian
        if (chosenCivillian == null)
        {
            //Pick a random civillian
            chosenCivillian = Enemies.PickCivillian();
        }
        //Otherwise if you are targeting a civillian
        else
        {
            //Move towards Civ
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, chosenCivillian.transform.position, Slime.speed * Time.deltaTime);
        }
    }
}
