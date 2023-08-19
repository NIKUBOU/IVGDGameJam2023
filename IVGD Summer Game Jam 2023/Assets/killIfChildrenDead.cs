using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killIfChildrenDead : MonoBehaviour
{
    private List<Transform> childObjects = new List<Transform>();

    void Start()
    {
        foreach (Transform child in transform)
        {
            childObjects.Add(child);
        }
    }

    void Update()
    {
        for (int i = childObjects.Count -1; i >= 0; i--)
        {
            if(childObjects[i] != null)
            {
                childObjects.RemoveAt(i);
            }
        }
    }


}
