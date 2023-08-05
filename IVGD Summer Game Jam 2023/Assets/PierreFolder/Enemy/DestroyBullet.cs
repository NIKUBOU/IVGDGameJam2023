using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BulletPink"))
        {
            Destroy(other.gameObject); // Destroy PinkBullet
        }
    }
}
