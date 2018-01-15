using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TurnManager : MonoBehaviour {

    //Declare Variables
    private List<GameObject> mobList = new List<GameObject>();
    [SerializeField]
    private Text waveCounter;
    [SerializeField]
    private GameObject slime;
    [SerializeField]
    private GameObject golem;

    public int enemiesThisWave;
    private bool waveOver;
    private int wave = 0;
    public float counter = 5;
    public int prepTime = 5;
	
	// Update is called once per frame
	void Update ()
    {
        //If wave is over
        if (TrackMobs.enemies.Count == 0 && Mathf.Round(counter) < prepTime && waveOver != true)
        {
            wave++;
            waveOver = true; //Prevent this tree from running again until next wave
            counter += prepTime; //Reset the counter
            
            //Adds random enemies to the Moblist
            for (int k = 0; k < enemiesThisWave; k++)
            {
                mobList.Add(PickEnemies(slime, golem, 0.8f, 0.2f));
            }
        }
        //If timer has run out
        else if (counter <= 0)
        {
            waveOver = false; //Allow first tree to run again

            for (int k = 0; k < mobList.Count; k++)
            {
                Instantiate(mobList[k], PickSpawnPoint(-20, 20, 20, -20, 30, 10), Quaternion.identity);
            }
        }
        //If counter hasn't run out yet
        else if (counter > 0)
        {
            counter -= Time.deltaTime; //Reduce counter by one frame
        }

        //To change the top text properly
        waveCounter.text = string.Format("Wave {0} starts in: {1}", wave ,Mathf.Round(counter));
    }

    //Method which picks random GameObject based on percentage chance
    GameObject PickEnemies(GameObject slime, GameObject golem, float slimeChance, float golemChance)
    {
        if (Random.value <= slimeChance)
        {
            print("slime");
            return slime;
        }
        else if (Random.value <= golemChance)
        {
            print("golem");
            return golem;
        }

        return slime;
    }

    //Method which picks a random point in a given range of X and Y
    Vector3 PickSpawnPoint(int leftY, int rightY, int topX, int bottomX, int YRange, int XRange)
    {
        float yPos;
        float xPos;

        bool spawnLeft = Random.Range(1, 3) == 1;
        bool spawnTop = Random.Range(1, 3) == 1;

        if (spawnLeft == true)
        {
            yPos = Random.Range(leftY - YRange, leftY + YRange);
        }
        else
        {
            yPos = Random.Range(rightY - YRange, rightY + YRange);
        }

        if (spawnTop == true)
        {
            xPos = Random.Range(topX - XRange, topX + XRange);
        }
        else
        {
            xPos = Random.Range(bottomX - XRange, bottomX + XRange);
        }

        print("xpos = " + xPos);
        print("ypos = " + yPos);

        return new Vector3(xPos, yPos);
    }
}
