using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{

    [SerializeField]
    private float bulletSpeed;
    [HideInInspector]
    public int damage;

    [SerializeField]
    private Rigidbody2D rb2d;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Civillian")
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator SelfDestruct(int time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(SelfDestruct(5));
        rb2d.AddRelativeForce(new Vector2(bulletSpeed, 0), ForceMode2D.Impulse);
        print(damage);
	}
}
