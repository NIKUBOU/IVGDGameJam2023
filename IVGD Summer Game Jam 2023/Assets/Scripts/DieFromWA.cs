using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieFromWA : MonoBehaviour
{
    public GameObject ownEnnemy;

    void OnTriggerEnter(Collider targetObj)
    {
        if (targetObj.gameObject.tag == "WeaponA")
            Destroy(targetObj.gameObject);

    }
}
