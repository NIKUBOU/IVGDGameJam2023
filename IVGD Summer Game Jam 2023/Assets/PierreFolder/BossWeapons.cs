using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossWeapons : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float fireRate;
    [SerializeField] private float fireDelay;
    private float nextShoot;
    public GameObject bulletPrefab; // prefab of the bullet
    public Transform firePoint; // shooting location

    // Start is called before the first frame update
    void Start()
    {
        nextShoot = fireRate + Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }


    

    void Shoot()
    {
        if (Time.time >= nextShoot)
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity); // Create a bullet
            StartCoroutine(ShootSecondBulletWithDelay()); //prepare second bullet
            nextShoot = Time.time + fireRate; // Update the next fire time                 
            
        }
    }

    private IEnumerator ShootSecondBulletWithDelay()
    {
        yield return new WaitForSeconds(fireDelay);
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity); // Create the second bullet
    }
}
