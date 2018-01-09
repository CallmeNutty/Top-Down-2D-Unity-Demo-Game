using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour {

    private float counter = 1;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (counter > 0)
        {
            counter -= Time.deltaTime;
            Debug.Log(counter);
        }
        else
        {
            Debug.Log("NEXT TURN");
        }

        if (TrackMobs.enemies.Count == 0)
        {
            StartCounter(5, counter);
            print("HI");
        }
    }

    void StartCounter (int timeAmount, float counter)
    {
        counter += timeAmount;
    }

}
