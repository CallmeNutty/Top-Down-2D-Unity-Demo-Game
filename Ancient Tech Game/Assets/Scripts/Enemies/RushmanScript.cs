using UnityEngine;
using System.Collections;

public class RushmanScript : MonoBehaviour
{
    //Declare Variables
    [SerializeField]
    private Enemies Enemies;
    private GameObject chosenCivillian;
    [SerializeField]
    private Rigidbody2D rb2d;

    //Create an instance of the "Enemy" base class
    Enemies.Enemy Rushman = new Enemies.Enemy(20, 10f);

    //Co Routine to stop Lunging
    private IEnumerator StopDashing()
    {
        float stopTimer;

        while (true)
        {
            stopTimer = Random.Range(0.2f, 1f);
            rb2d.velocity = rb2d.velocity * 0.15f * Time.deltaTime;
            yield return new WaitForSeconds(stopTimer);
        }
    }

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
        StartCoroutine(StopDashing());
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
            //Lunge at Civ
            rb2d.AddForce((chosenCivillian.transform.position - gameObject.transform.position).normalized * Rushman.speed * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
}
