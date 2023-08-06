using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyB : MonoBehaviour
{
    public GameObject ownEnnemy;

    void OnTriggerEnter(Collider targetObj)
    {
        if (targetObj.gameObject.tag == "WeaponB")
            Destroy(targetObj.gameObject);


    }
}
