using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPinkBullet : MonoBehaviour
{
    public GameObject ownSelf;


    void OnTriggerEnter(Collider targetObj)
    {
        if (targetObj.gameObject.tag == "Player")
            Object.Destroy(this.ownSelf);



    }
}
