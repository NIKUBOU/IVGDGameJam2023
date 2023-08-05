using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float timer = 20f;

    public GameObject ownLaser;
    public GameObject explosion;
    public Transform explosionSpawningPoint;


    private void Update()
    {
        if (timer > 0)
        {
            timer -= Random.Range(.01f, .025f);

        }

        else if (timer < 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);

            //GameObject newExplosion = GameObject.Instantiate<GameObject>(explosion, explosionSpawningPoint);
            //newExplosion.transform.parent = null;

            Object.Destroy(this.ownLaser);

        }

    }





}
