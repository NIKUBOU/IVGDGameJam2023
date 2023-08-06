using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBossB : MonoBehaviour
{
    public Boss boss;

    public GameObject ownSelf;

    void OnTriggerEnter(Collider targetObj)
    {
        if (targetObj.gameObject.tag == "WeaponB")
            boss.GetDamage();


    }
}
