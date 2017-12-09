using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float playerSpeed;

    [SerializeField]
    private Rigidbody2D playerRb2d;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetKey(KeyCode.W))
        {
            playerRb2d.AddForce(new Vector2(0, playerSpeed), ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerRb2d.AddForce(new Vector2(-playerSpeed, 0), ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerRb2d.AddForce(new Vector2(0, -playerSpeed), ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerRb2d.AddForce(new Vector2(playerSpeed, 0), ForceMode2D.Impulse);
        }
    }
}
