using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyC : MonoBehaviour
{
    public GameObject ownEnnemy;

    void OnTriggerEnter(Collider targetObj)
    {
        /*if (targetObj.gameObject.tag == "WeaponC")
            Destroy(targetObj.gameObject);*/


    }
    
}
