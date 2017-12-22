using UnityEngine;
using System.Collections;

public class GolemScript : MonoBehaviour
{
    //Declare Variables
    [SerializeField]
    private Enemies Enemies;
    private GameObject chosenCivillian;
    [SerializeField]
    private Rigidbody2D rb2d;

    //Create an instance of the "Enemy" base class
    Enemies.Enemy Golem = new Enemies.Enemy(20, 0.25f);


    private IEnumerator StopLunging()
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
        StartCoroutine(StopLunging());
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
            rb2d.AddForce((chosenCivillian.transform.position - gameObject.transform.position).normalized * Golem.speed, ForceMode2D.Impulse);
        }
    }
}
