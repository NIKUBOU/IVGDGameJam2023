using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueExpire : MonoBehaviour
{
    public float timer = 0f;

    public GameObject ownTongue;
    public ShmupManager shmupManager;


    private void Update()
    {
        if (timer > 0)
        {
            ownTongue.SetActive(true);
            timer -= Random.Range(.01f, .025f);

        }

        if (timer < 0)
        {

            ownTongue.SetActive(false);

        }

        if (shmupManager.FrogSelected == 2)
        {

            timer = 0f;
            ownTongue.SetActive(false);

        }

    }
}
