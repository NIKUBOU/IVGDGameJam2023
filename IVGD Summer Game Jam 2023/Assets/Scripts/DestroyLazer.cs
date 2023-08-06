using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLazer: MonoBehaviour
{ 
    void OnCollisionEnter(Collision targetObj)
    {
        if (targetObj.gameObject.tag == "WeaponA")
            Destroy(targetObj.gameObject);

        if (targetObj.gameObject.tag == "WeaponX")
            Destroy(targetObj.gameObject);

        if (targetObj.gameObject.tag == "WeaponC")
            Destroy(targetObj.gameObject);
    }

}
