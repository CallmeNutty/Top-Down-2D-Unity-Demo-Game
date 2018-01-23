using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    //Declare Variables
    [SerializeField]
    private float playerSpeed;

    [SerializeField]
    private Rigidbody2D playerRb2d;
    [SerializeField]
    private SpriteRenderer playerSpriteRenderer;
	
	// Update is called once per frame
	void Update ()
    {
        //Movement for Up
	    if (Input.GetKey(KeyCode.W))
        {
            playerRb2d.AddForce(new Vector2(0, playerSpeed), ForceMode2D.Impulse);
        }

        //Movement for Left
        if (Input.GetKey(KeyCode.A))
        {
            playerRb2d.AddForce(new Vector2(-playerSpeed, 0), ForceMode2D.Impulse);
        }

        //Movement for Down
        if (Input.GetKey(KeyCode.S))
        {
            playerRb2d.AddForce(new Vector2(0, -playerSpeed), ForceMode2D.Impulse);
        }

        //Movement for Right
        if (Input.GetKey(KeyCode.D))
        {
            playerRb2d.AddForce(new Vector2(playerSpeed, 0), ForceMode2D.Impulse);
        }

        //Player Rotation with mouse
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        //Player Image rotation
        if (angle > 90 || angle < -90)
        {
            playerSpriteRenderer.flipX = false;
        }
        else
        {
            playerSpriteRenderer.flipX = true;
        }

    }
}
