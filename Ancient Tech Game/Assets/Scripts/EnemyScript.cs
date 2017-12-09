using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    private bool targetingCivillian;
    [SerializeField]
    private float runSpeed;
    
    private GameObject chosenCivillian;
    private GameObject[] civillians;


    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject == chosenCivillian)
        {
            Destroy(coll.gameObject);
            Destroy(this.gameObject);
        }
    }

    // Use this for initialization
    void Start ()
    {
        civillians = GameObject.FindGameObjectsWithTag("Civillian");
	}

    // Update is called once per frame
    void Update()
    {
        if (targetingCivillian == false)
        {
            targetingCivillian = true;
            chosenCivillian = civillians[Random.Range(0, civillians.Length)];
        }
        else if (chosenCivillian == null)
        {
            targetingCivillian = false;
        }
        else if (targetingCivillian == true)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, chosenCivillian.transform.position, runSpeed);
        }

        Debug.Log(chosenCivillian);
        Debug.Log(targetingCivillian);
    }
}
