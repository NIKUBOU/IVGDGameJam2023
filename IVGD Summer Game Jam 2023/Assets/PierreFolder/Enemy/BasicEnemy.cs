using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    
    [Header("MyEnemyType")]
    [SerializeField] private bool TypeA; 
    [SerializeField] private bool TypeB;
    [SerializeField] private bool TypeC;

    private string weaponA = "WeaponA"; //set the tag
    private string weaponB = "WeaponB"; // set the tag
    private string weaponC = "WeaponC"; // set the tag


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other) // detect if I'm hit and if I should die
    {
        if (other.transform.IsChildOf(transform))
        {
            Debug.Log("I'm Hit");

            if (other.gameObject.CompareTag(weaponA) && TypeA)
            {
                Debug.Log("I should Die form A");
                Destroy(gameObject);
            }
            
            if (other.gameObject.CompareTag(weaponB) && TypeB)
            {
                Debug.Log("I should Die form B");
                Destroy(gameObject);
            }
            
            if (other.gameObject.CompareTag(weaponC) && TypeC)
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
