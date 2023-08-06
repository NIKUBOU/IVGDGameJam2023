using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillLaserC : MonoBehaviour
{
    public GameObject ownSelf;

    void OnTriggerEnter(Collider targetObj)
    {
        if (targetObj.gameObject.tag == "WeaponC")
            Object.Destroy(this.ownSelf);


    }
}
