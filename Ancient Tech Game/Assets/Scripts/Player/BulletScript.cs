﻿using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    [SerializeField]
    private float bulletSpeed;

    [SerializeField]
    private Rigidbody2D rb2d;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Civillian")
        {
            Destroy(gameObject);
        }
        
        //Or if collided with Enemy
        else if (coll.gameObject.tag == "Enemy")
        {
            TrackMobs.enemies.Remove(coll.gameObject);
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start ()
    {
        rb2d.AddRelativeForce(new Vector2(bulletSpeed, 0), ForceMode2D.Impulse);
	}
}