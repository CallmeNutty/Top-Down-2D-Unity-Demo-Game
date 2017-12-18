using UnityEngine;
using System.Collections;

public class TrackCivillians : MonoBehaviour
{
    [HideInInspector]
    public int civillianCount;

	// Use this for initialization
	void Start ()
    {
	    
	}

    // Update is called once per frame
    void Update()
    {
        if (civillianCount == 0)
        {
            print("HI");
        }

        print(civillianCount);
    }
}
