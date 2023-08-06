using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBossA : MonoBehaviour
{
    public Boss boss;

    public GameObject ownSelf;

    void OnTriggerEnter(Collider targetObj)
    {
        if (targetObj.gameObject.tag == "WeaponA")
            boss.GetDamage();


    }
}
