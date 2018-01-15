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
    private GameObject createdMob;

    public int enemiesThisWave;
    private bool waveOver;
    private bool enemiesSpawned;
    private int wave = 0;
    public float counter;
    public int prepTime;
	
	// Update is called once per frame
	void Update ()
    {
        //If wave is over
        if (TrackMobs.enemies.Count == 0 && Mathf.Round(counter) < prepTime && waveOver != true)
        {
            wave++;
            waveOver = true; //Prevent this tree from running again until next wave
            enemiesSpawned = false;
            counter += prepTime; //Reset the counter

            mobList.Clear();
            enemiesThisWave = ScaleDifficulty(wave, 1.5f);

            //Adds random enemies to the Moblist
            for (int k = 0; k < enemiesThisWave; k++)
            {
                mobList.Add(PickEnemies(slime, golem, 0.8f, 0.4f));
            }
        }
        //If timer has run out
        else if (counter <= 0)
        {
            waveOver = false; //Allow first tree to run again

            if (enemiesSpawned == false)
            {
                for (int k = 0; k < mobList.Count; k++)
                {
                    createdMob = Instantiate(mobList[k], PickSpawnPoint(-16, 16, 16, -16, 8, 8), Quaternion.identity) as GameObject;
                    TrackMobs.enemies.Add(createdMob);
                    if (k == mobList.Count - 1) { enemiesSpawned = true; }
                }
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
        //If random value is less than chance for slime to spawn
        if (Random.value <= slimeChance)
        {
            return slime;
        }
        else if (Random.value <= golemChance)
        {
            return golem;
        }

        //By default return a slime
        return slime;
    }

    //Method which picks a random point in a given range of X and Y
    Vector3 PickSpawnPoint(int leftY, int rightY, int topX, int bottomX, int YRange, int XRange)
    {
        float yPos;
        float xPos;

        //Decide which general directions it will be spawning in
        bool spawnLeft = Random.Range(1, 3) == 1;
        bool spawnTop = Random.Range(1, 3) == 1;

        //Choose value based on given value subtracted and added by the range
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

        //Return the xPos and yPos as a 3D Vector
        return new Vector3(xPos, yPos);
    }

    //Method which scales difficulty based on wave
    int ScaleDifficulty(int wave, float difficulty)
    {
        return Random.Range(Mathf.RoundToInt(difficulty * wave), Mathf.RoundToInt(difficulty * wave) + Mathf.RoundToInt(Mathf.Pow(difficulty, 4)));
    }
}
