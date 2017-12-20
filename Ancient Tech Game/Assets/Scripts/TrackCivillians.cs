using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrackCivillians : MonoBehaviour
{
    //Declare Variables
    public static List<GameObject> civillians;

	// Use this for initialization
	void Start ()
    {
        //Populate List with Objects with tag "Civillian"
        civillians = new List<GameObject>(GameObject.FindGameObjectsWithTag("Civillian"));
    }

    // Update is called once per frame
    void Update()
    {
        print(civillians.Count);
    }
}
