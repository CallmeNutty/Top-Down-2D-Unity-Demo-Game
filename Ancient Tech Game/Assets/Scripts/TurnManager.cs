using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TurnManager : MonoBehaviour {

    //Declare Variables
    [SerializeField]
    private Text waveCounter;

    private int wave = 1;
    private float counter = 5;
	
	// Update is called once per frame
	void Update ()
    {
        //Stop the timer from going below zero
        if (counter > 0)
        {
            counter -= Time.deltaTime; //Reduce counter by one frame
        }

        //If wave is over
        if (TrackMobs.enemies.Count == 0)
        {
            StartCounter(5, counter);
        }

        waveCounter.text = "Wave 0 starts in: " + Mathf.Round(counter);
    }

    void StartCounter (int timeAmount, float counter)
    {
        counter += timeAmount;
    }

}
