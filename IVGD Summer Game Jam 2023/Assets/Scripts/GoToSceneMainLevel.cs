using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GoToSceneMainLevel : MonoBehaviour
{


    public void GoTo()
    {
        SceneManager.LoadScene("MainLevel");
    }

}