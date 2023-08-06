using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShmupManager : MonoBehaviour
{

    //player health
    public float PlayerCurrentLife = 3;
    public float PlayerMaxLife = 3;

    //slected frog ID
    public int FrogSelected = 1;

    //switch frogs
    public GameObject Frog1;
    public GameObject Frog2;
    public GameObject Frog3;
    public GameObject EmptyFrog1;
    public GameObject EmptyFrog2;
    public GameObject EmptyFrog3;
    private Vector3 tempPosition1;
    private Vector3 tempPosition2;
    private Vector3 tempPosition3;

    //projectiles
    public GameObject lazerPrefab1;
    public GameObject lazerPrefab2;
    public GameObject lazerPrefab3;
    public Transform lazerSpawningPoint;

    public TongueExpire tongueExpire;

    //audio
    public AudioSource audioSourceFire1;
    public AudioSource audioSourceFire2;
    public AudioSource audioSourceFire3;
    public AudioSource audioSourceSwitch1;
    public AudioSource audioSourceSwitch2;
    public AudioSource audioSourceSwitch3;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Press space to switch Players
        if (Input.GetKeyDown(KeyCode.LeftShift) && FrogSelected <= 2 && PlayerCurrentLife >= 1)
        {
            FrogSelected = FrogSelected + 1;

        }

        else if (Input.GetKeyDown(KeyCode.LeftShift) && FrogSelected == 3 && PlayerCurrentLife >= 1)
        {
            FrogSelected = 1;
        }

        SetFrogPosition();

        //fire laser
        if (Input.GetKeyDown(KeyCode.Space) && FrogSelected == 1 && PlayerCurrentLife >= 1)
        {

            tongueExpire.timer = 5f;
            audioSourceFire1.Play();

        }

        if (Input.GetKeyDown(KeyCode.Space) && FrogSelected == 2 && PlayerCurrentLife >= 1)
        {
            GameObject newLazer = GameObject.Instantiate<GameObject>(lazerPrefab2, lazerSpawningPoint);
            newLazer.transform.parent = null;
            audioSourceFire2.Play();
        }

        if (Input.GetKeyDown(KeyCode.Space) && FrogSelected == 3 && PlayerCurrentLife >= 1)
        {
            GameObject newLazer = GameObject.Instantiate<GameObject>(lazerPrefab3, lazerSpawningPoint);
            newLazer.transform.parent = null;
            audioSourceFire3.Play();
        }

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
            audioSourceSwitch1.Play();
        }

        if (FrogSelected == 2 && PlayerCurrentLife >= 1)
        {
            Frog1.transform.position = tempPosition2;
            Frog2.transform.position = tempPosition3;
            Frog3.transform.position = tempPosition1;
            audioSourceSwitch2.Play();
        }

        if (FrogSelected == 3 && PlayerCurrentLife >= 1)
        {
            Frog1.transform.position = tempPosition3;
            Frog2.transform.position = tempPosition1;
            Frog3.transform.position = tempPosition2;
            audioSourceSwitch3.Play();
        }


    }

    void OnTriggerEnter(Collider targetObj)
    {
        if (targetObj.gameObject.tag == "BulletPink")
            PlayerCurrentLife -= 1;

    }

    /*public void PlayerGetDamage()
    {
        PlayerCurrentLife -= 1;
    }*/


}
