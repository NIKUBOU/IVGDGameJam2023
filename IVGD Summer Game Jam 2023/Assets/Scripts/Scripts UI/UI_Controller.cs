using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Controller : MonoBehaviour
{
    public ShmupManager shmupManager;

    public RawImage bg1;
    public RawImage bg2;
    public RawImage bg3;


    // Start is called before the first frame update
    void Start()
    {
        //hide stuff at start
        bg1.enabled = false;
        bg2.enabled = false;
        bg3.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        //set Backgrounds
        if (shmupManager.FrogSelected == 1)
        {
            bg1.enabled = true;
            bg2.enabled = false;
            bg3.enabled = false;

        }

        if (shmupManager.FrogSelected == 2)
        {
            bg1.enabled = false;
            bg2.enabled = true;
            bg3.enabled = false;

        }

        if (shmupManager.FrogSelected == 3)
        {
            bg1.enabled = false;
            bg2.enabled = false;
            bg3.enabled = true;

        }



    }
}
