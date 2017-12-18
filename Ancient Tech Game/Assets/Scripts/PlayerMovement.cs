using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float playerSpeed;

    [SerializeField]
    private Rigidbody2D playerRb2d;
	
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

        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if (angle > 90 || angle < -90)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 200, 0);
        }

    }
}
