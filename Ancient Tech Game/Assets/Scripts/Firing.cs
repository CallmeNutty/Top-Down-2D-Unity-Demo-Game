using UnityEngine;
using System.Collections;

public class Firing : MonoBehaviour
{

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject bulletSpawner;
    [SerializeField]
    private GameObject emptyBullet;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        

        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        bulletSpawner.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, new Vector3(bulletSpawner.transform.position.x, bulletSpawner.transform.position.y), bulletSpawner.transform.rotation, emptyBullet.transform);
        }
    }
}
