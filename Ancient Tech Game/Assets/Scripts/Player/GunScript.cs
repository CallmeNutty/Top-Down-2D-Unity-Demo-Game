using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour
{

    [SerializeField]
    private float bulletSpeed;

    [SerializeField]
    private Rigidbody2D rb2d;

    public class Weapon
    {
        public string name;
        public int damage;
    }

    public class Firearm : Weapon
    {
         
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Civillian")
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start ()
    {
        rb2d.AddRelativeForce(new Vector2(bulletSpeed, 0), ForceMode2D.Impulse);
	}
}
