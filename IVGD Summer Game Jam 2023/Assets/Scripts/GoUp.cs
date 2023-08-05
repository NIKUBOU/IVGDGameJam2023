using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoUp : MonoBehaviour
{
    Rigidbody Rigidbody;
    public float Thrust;
    public Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       rb = GetComponent<Rigidbody>();
       rb.AddForce(0, Thrust, 0, ForceMode.Impulse);

    }
}
