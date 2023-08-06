using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayWithinBoundingBox : MonoBehaviour
{
    public Vector3 minimum;
    public Vector3 maximum;

    public bool ignoreX;
    public bool ignoreY;
    public bool ignoreZ;

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("boundaryCheckUpdate");
        Vector3 position = transform.position;

        if (!ignoreX)
        {
            if (position.x < minimum.x)
            {
                position.x = minimum.x;
            }

            if (position.x > maximum.x)
            {
                position.x = maximum.x;
            }
        }

        if (!ignoreY)
        {
            if (position.y < minimum.y)
            {
                position.y = minimum.y;
            }

            if (position.y > maximum.y)
            {
                position.y = maximum.y;
            }
        }

        if (!ignoreZ)
        {
            if (position.z < minimum.z)
            {
                position.z = minimum.z;
            }

            if (position.z > maximum.z)
            {
                position.z = maximum.z;
            }
        }
        
        transform.position = position;
    }
}
