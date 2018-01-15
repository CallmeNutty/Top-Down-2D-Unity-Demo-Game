using UnityEngine;
using System.Collections;

public class Firing : MonoBehaviour
{

    [SerializeField]
    private AudioSource gunSound;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject bulletSpawner;
    [SerializeField]
    private GameObject emptyBullet;
	
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
            gunSound.Play();
        }
    }
}
