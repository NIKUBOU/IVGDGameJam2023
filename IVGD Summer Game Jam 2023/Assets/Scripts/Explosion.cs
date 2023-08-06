using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{


    public float timer = 20f;



    private void Update()
    {
        if (timer > 0)
        {
            timer -= Random.Range(.01f, .025f);

        }

        else if (timer < 0)
        {

            Destroy(gameObject);

        }


    }
}