using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    //public int destroyTime = 5;

    //new
    public float timer = 20f;

    /*public void ExplosionStart()
    {
        Destroy(gameObject, destroyTime);
    }*/

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