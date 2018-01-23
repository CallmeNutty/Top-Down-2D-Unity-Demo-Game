using UnityEngine;
using System.Collections;

public class Firing : MonoBehaviour
{
    [SerializeField]
    private AudioSource gunSound;
    [SerializeField]
    private GunManager gunManager;
    [SerializeField]
    private FirearmManager firearmManager;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject bulletSpawner;
    [SerializeField]
    private GameObject emptyBullet;
    private GameObject spawnedBullet;
    private BulletScript bulletScript;

    // Update is called once per frame
    void Update ()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (firearmManager.firearm.automatic == true)
        {
            if (Input.GetMouseButton(0))
            {
                spawnedBullet = Instantiate(bullet, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y), gameObject.transform.rotation, emptyBullet.transform) as GameObject;
                bulletScript = spawnedBullet.GetComponent<BulletScript>();
                bulletScript.damage = firearmManager.firearm.damage;
                if (!gunSound.isPlaying)
                {
                    gunSound.Play();
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                spawnedBullet = Instantiate(bullet, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y), gameObject.transform.rotation, emptyBullet.transform) as GameObject;
                bulletScript = spawnedBullet.GetComponent<BulletScript>();
                bulletScript.damage = firearmManager.firearm.damage;
                gunSound.Play();
            }
        }

        if (angle > 90 || angle < -90)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
