using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    [SerializeField]
    private float bulletSpeed;

    [SerializeField]
    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start ()
    {
        rb2d.AddRelativeForce(new Vector2(bulletSpeed, 0), ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
