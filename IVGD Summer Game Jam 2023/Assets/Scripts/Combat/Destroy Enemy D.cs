using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyD : MonoBehaviour
{
    public GameObject ownEnnemy;
    public ShmupManager shmupManager;

 
    void OnTriggerEnter(Collider targetObj)
    {
        if (targetObj.gameObject.tag == "BulletPink")
            shmupManager.PlayerCurrentLife = shmupManager.PlayerCurrentLife - 1;


    }
}
