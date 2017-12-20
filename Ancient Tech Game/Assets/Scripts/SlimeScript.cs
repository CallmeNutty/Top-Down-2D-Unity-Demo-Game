using UnityEngine;
using System.Collections;

public class SlimeScript : MonoBehaviour
{

    //Declare Variables
    private bool targetingCivillian;
    [SerializeField]
    private float runSpeed;

    [SerializeField]
    private GameObject gameManager;
    private TrackCivillians trackCivillians;
    private GameObject chosenCivillian;
    private GameObject[] civillians;


    //Collisions with Civillians
    private void OnCollisionEnter2D(Collision2D coll)
    {
        //If collided with chosenCivillian
        if (coll.gameObject.tag == "Civillian")
        {
            trackCivillians.civillianCount--;
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
        //Or if collided with Bullet
        else if (coll.gameObject.tag == "Bullet")
        {
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
        else
        {
            Destroy(coll.gameObject);
        }
    }

    // Use this for initialization
    void Start ()
    {
        //Populate Array with gameObjects that have Civillian tags
        civillians = GameObject.FindGameObjectsWithTag("Civillian");

        trackCivillians = gameManager.GetComponent<TrackCivillians>();

        trackCivillians.civillianCount = civillians.Length;
	}

    // Update is called once per frame
    void Update()
    {
        //If not currently targeting a Civillian
        if (targetingCivillian == false)
        {
            targetingCivillian = true; //Now targetting a civ due to following line
            chosenCivillian = civillians[Random.Range(0, civillians.Length)]; //Pick random Civ
        }
        //If chosen Civillian no longer exists
        else if (chosenCivillian == null)
        {
            targetingCivillian = false; //No longer targetting a Civ so previous block will execute next frame
        }
        //Otherwise if you are targeting a civillian
        else if (targetingCivillian == true)
        {
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, chosenCivillian.transform.position, runSpeed * Time.deltaTime); //Move towards Civ
        }
    }
}
