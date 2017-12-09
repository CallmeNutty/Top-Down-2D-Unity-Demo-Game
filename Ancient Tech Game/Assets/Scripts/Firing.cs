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
	    if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, new Vector3(bulletSpawner.transform.position.x, bulletSpawner.transform.position.y), bulletSpawner.transform.rotation, emptyBullet.transform);
        }

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 1f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        bulletSpawner.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }
}
