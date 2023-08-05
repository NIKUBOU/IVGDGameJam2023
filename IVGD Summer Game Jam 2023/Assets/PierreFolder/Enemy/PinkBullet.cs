using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkBullet : MonoBehaviour
{
    [Header("BulletVariable")]
    [SerializeField] private float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = Vector3.down * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
