using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnnemyA : MonoBehaviour
{
    public GameObject ownSelf;

    void OnTriggerEnter(Collider targetObj)
    {
        if (targetObj.gameObject.tag == "WeaponA")
        Object.Destroy(this.ownSelf);


    }
}
