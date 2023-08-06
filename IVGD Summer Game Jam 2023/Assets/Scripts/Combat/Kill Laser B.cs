using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillLaserB : MonoBehaviour
{
    public GameObject ownSelf;

    void OnTriggerEnter(Collider targetObj)
    {
        if (targetObj.gameObject.tag == "WeaponB")
            Object.Destroy(this.ownSelf);


    }
}
