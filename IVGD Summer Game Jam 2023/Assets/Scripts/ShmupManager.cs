using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShmupManager : MonoBehaviour
{

    public float PlayerCurrentLife = 3;
    public float PlayerMaxLife = 3;


    public int FrogSelected = 1;

    public GameObject Frog1;
    public GameObject Frog2;
    public GameObject Frog3;
    public GameObject EmptyFrog1;
    public GameObject EmptyFrog2;
    public GameObject EmptyFrog3;

    private Vector3 tempPosition1;
    private Vector3 tempPosition2;
    private Vector3 tempPosition3;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Press space to switch Players
        if (Input.GetKeyDown(KeyCode.Space) && FrogSelected <= 2 && PlayerCurrentLife >= 1)
        {
            FrogSelected = FrogSelected + 1;

        }

        else if (Input.GetKeyDown(KeyCode.Space) && FrogSelected == 3 && PlayerCurrentLife >= 1)
        {
            FrogSelected = 1;
        }

        SetFrogPosition();


    }


    //switch frog position to coordinate of emptyfrog objects
    private void SetFrogPosition()
    {
        tempPosition1 = EmptyFrog1.transform.position;
        tempPosition2 = EmptyFrog2.transform.position;
        tempPosition3 = EmptyFrog3.transform.position;


        if (FrogSelected == 1 && PlayerCurrentLife >= 1)
        {
            Frog1.transform.position = tempPosition1;
            Frog2.transform.position = tempPosition2;
            Frog3.transform.position = tempPosition3;
        }

        if (FrogSelected == 2 && PlayerCurrentLife >= 1)
        {
            Frog1.transform.position = tempPosition2;
            Frog2.transform.position = tempPosition3;
            Frog3.transform.position = tempPosition1;
        }

        if (FrogSelected == 3 && PlayerCurrentLife >= 1)
        {
            Frog1.transform.position = tempPosition3;
            Frog2.transform.position = tempPosition1;
            Frog3.transform.position = tempPosition2;
        }


    }





}
