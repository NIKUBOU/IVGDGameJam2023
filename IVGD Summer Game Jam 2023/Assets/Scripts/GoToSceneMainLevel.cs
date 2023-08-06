using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GoToSceneMainLevel : MonoBehaviour
{


    public void Replay()
    {
        SceneManager.LoadScene("MainLevel");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("MainLevel");

        }
    }
}