using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{   
 
    public enum EnemyType
    {
        TypeA,
        TypeB,
        TypeC,
        Indestructible,
    }
    
    [Header("MyEnemyType")]
    [SerializeField] private EnemyType enemyType;

    private string weaponA = "WeaponA"; //set the tag
    private string weaponB = "WeaponB"; // set the tag
    private string weaponC = "WeaponC"; // set the tag

    //Combat
    [Header("Shooting")]
    [SerializeField] private bool doIShoot;
    [SerializeField] private bool doIDoubleShoot;
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
        if (doIShoot || doIDoubleShoot)
        {
            Shoot();            
        }
        
    }

    void Shoot()
    {        
        if (Time.time >= nextShoot && !doIDoubleShoot)
        {            
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity); // Create a bullet
            nextShoot = Time.time + fireRate; // Update the next fire time
        }
        else if (Time.time >= nextShoot && doIDoubleShoot) // shootgun
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity); // Create a bullet
            StartCoroutine(ShootSecondBulletWithDelay()); //prepare second bullet
            nextShoot = Time.time + fireRate; // Update the next fire time
        }
    }

    private IEnumerator ShootSecondBulletWithDelay() //coroutine second bullet
    {
        yield return new WaitForSeconds(fireDelay);
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity); // Create the second bullet
    }


    private void OnTriggerEnter(Collider other) // detect if I'm hit and if I should die
    {
        if (other.transform.IsChildOf(transform))
        {
            Debug.Log("I'm Hit");

            if (other.gameObject.CompareTag(weaponA) && enemyType == EnemyType.TypeA)
            {
                Debug.Log("I should Die form A");
                Destroy(gameObject);
            }
            
            if (other.gameObject.CompareTag(weaponB) && enemyType == EnemyType.TypeB)
            {
                Debug.Log("I should Die form B");
                Destroy(gameObject);
            }
            
            if (other.gameObject.CompareTag(weaponC) && enemyType == EnemyType.TypeC)
            {
                Debug.Log("I should Die form C");
                Destroy(gameObject);
            }

            else
            {
                return;
            }           

        }       
        
    }

}
