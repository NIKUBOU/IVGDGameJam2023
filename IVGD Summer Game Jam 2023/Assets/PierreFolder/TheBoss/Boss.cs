using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Boss;

public enum EnemyType
{
    TypeA,
    TypeB,
    TypeC,
    Indestructible,
}


public class Boss : MonoBehaviour
{
    #region FIELD
    [Header("Current Pattern")]
    [SerializeField] private EnemyType enemyType;

    private bool isSwitchingEnemyType = false;

    private System.Random random = new System.Random();

    private string weaponA = "WeaponA"; //set the tag
    private string weaponB = "WeaponB"; // set the tag
    private string weaponC = "WeaponC"; // set the tag

    private EnemyType[] enemyTypes;

    [Header("Life")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private int damageAmount = 2;

    [Header("myTypes")]
    public GameObject bodyAObject;
    public GameObject bodyBObject;
    public GameObject bodyCObject;
    public GameObject bodyDObject;

    [Header("Weapons")]
    public GameObject weaponAObject;
    public GameObject weaponBObject;
    public GameObject weaponCObject;
    public GameObject weaponDObject;
    //[SerializeField] private float fireRate;
    //[SerializeField] private float fireDelay;
    //private float nextShoot;
    //public Transform[] firePoints;
    //public GameObject bulletPrefab;

    #endregion

    void Start()
    {
        currentHealth = maxHealth;
        enemyTypes = (EnemyType[])Enum.GetValues(typeof(EnemyType));
        //nextShoot = fireRate + Time.time;
    }

    
    void Update()
    {
        HealthSystem();
        //nextShoot = fireRate + Time.time;

        //if (Time.time >= nextShoot)
           // Shoot();
    }


    void LateUpdate()
    {
        PerformActionsBasedOnEnemyType();
        
    }


    private void HealthSystem()
    {
        if (isSwitchingEnemyType) return;

        if (currentHealth <= 0)
        {
            Die();
        }
        else if (currentHealth == 15)
        {
            EnemyType randomEnemyType = TypeSwitch();
            isSwitchingEnemyType = true;
        }
        else if (currentHealth == 30)
        {
            EnemyType randomEnemyType = TypeSwitch();
            isSwitchingEnemyType = true;
        }
        else if (currentHealth == 45)
        {
            EnemyType randomEnemyType = TypeSwitch();
            isSwitchingEnemyType = true;
        }
        else if (currentHealth == 60)
        {
            EnemyType randomEnemyType = TypeSwitch();
            isSwitchingEnemyType = true;
        }
        else if (currentHealth == 80)
        {
            Debug.Log("DamageDone");
            EnemyType randomEnemyType = TypeSwitch();
            isSwitchingEnemyType = true;
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    EnemyType TypeSwitch()
    {
        int randomIndex = random.Next(enemyTypes.Length);
        return enemyTypes[randomIndex];
    }

    private void SwitchEnemyTypeWithDelay()
    {
        enemyType = TypeSwitch();
        isSwitchingEnemyType = false;
    }

    private void PerformActionsBasedOnEnemyType()
    {
        if (isSwitchingEnemyType) return;

        switch (enemyType)
        {
            case EnemyType.TypeA: // -----------------------------A
                
                // Setting Weapons
                weaponAObject.SetActive(true);
                weaponBObject.SetActive(false);
                weaponCObject.SetActive(false);
                weaponDObject.SetActive(false);

                //Setting Body
                bodyAObject.SetActive(true);
                bodyBObject.SetActive(false);
                bodyCObject.SetActive(false);
                bodyDObject.SetActive(false);

                // Perform actions for TypeA
                // 1 change colors done
                // 2 change guns wip
                
                break;

            case EnemyType.TypeB: // ----------------------------B
                
                // Setting Weapons
                weaponAObject.SetActive(false);
                weaponBObject.SetActive(true);
                weaponCObject.SetActive(false);
                weaponDObject.SetActive(false);

                //Setting Body
                bodyAObject.SetActive(false);
                bodyBObject.SetActive(true);
                bodyCObject.SetActive(false);
                bodyDObject.SetActive(false);

                break;

            case EnemyType.TypeC: // ----------------------------C

                // Setting Weapons
                weaponAObject.SetActive(false);
                weaponBObject.SetActive(false);
                weaponCObject.SetActive(true);
                weaponDObject.SetActive(false);

                //Setting Body
                bodyAObject.SetActive(false);
                bodyBObject.SetActive(false);
                bodyCObject.SetActive(true);
                bodyDObject.SetActive(false);

                break;

            case EnemyType.Indestructible: //--------------------D

                // Setting Weapons
                weaponAObject.SetActive(false);
                weaponBObject.SetActive(false);
                weaponCObject.SetActive(false);
                weaponDObject.SetActive(true);

                //Setting Body
                bodyAObject.SetActive(false);
                bodyBObject.SetActive(false);
                bodyCObject.SetActive(false);
                bodyDObject.SetActive(true);

                isSwitchingEnemyType = true;
                Invoke("SwitchEnemyTypeWithDelay", 1.5f);
                break;

        }
    }

    

    /*
    void Shoot()
    {
        foreach (Transform firePoint in firePoints)
        {
                       
                Instantiate(bulletPrefab, firePoint.position, Quaternion.identity); // Create a bullet
                //StartCoroutine(ShootSecondBulletWithDelay(firePoint)); //prepare second bullet
                nextShoot = Time.time + fireRate; // Update the next fire time
            
        }
    }

    private IEnumerator ShootSecondBulletWithDelay(Transform firePoint)
    {
        yield return new WaitForSeconds(fireDelay);
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity); // Create the second bullet
    }*/


    private void OnTriggerEnter(Collider other) // detect if I'm hit and if I should die
    {
        if (other.transform.IsChildOf(transform))
        {
            Debug.Log("I'm Hit");

            if (other.gameObject.CompareTag(weaponA) && enemyType == EnemyType.TypeA)
            {
                currentHealth -= damageAmount;
            }

            if (other.gameObject.CompareTag(weaponB) && enemyType == EnemyType.TypeB)
            {
                currentHealth -= damageAmount;
            }

            if (other.gameObject.CompareTag(weaponC) && enemyType == EnemyType.TypeC)
            {
                currentHealth -= damageAmount;
            }

            else
            {
                return;
            }

        }

    }


}