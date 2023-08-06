using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    //powerUp
    public bool isInvincibleActivated;
    public bool isKillThemAllActivated;
    public bool isWeaponActivated;
    public bool isHealActivated;

    private float invincibilityTimer = 0f; // for invicible
    public string[] enemyTagsToDestroy = { "EnemyA", "EnemyB", "EnemyC" }; // for kill them all

    //end game
    public bool isGameOver;


    //Scoreing
    public int score;
    public int highscore;
    public int pointPerPowerUp = 500;
    public int pointPerEnemyDestroyed = 100;
    public TMP_Text textScore;
    public TMP_Text highTextScore;


    // Start is called before the first frame update
    void Start()
    {
        //safeguardGameManager
        DontDestroyOnLoad(gameObject);

        //resetgameover
        isGameOver = false;
        Time.timeScale = 1;
        score = 0;
        UpdateScoreText();

        //Reset PowerUp on start
        isInvincibleActivated = false;
        isKillThemAllActivated = false;
        isWeaponActivated = false;
        isHealActivated = false;

        ScoreSetup();
    }


    // Update is called once per frame
    void Update()
    {
        
        //scoreing
        if (score > highscore)
        {
            highscore = score;
        }
               
        UpdateScoreText(); // update the score UI
        

        // kill Invincible powerUp after x time
        if (isInvincibleActivated)
        {
            if (invincibilityTimer <= Time.timeSinceLevelLoad)
                isInvincibleActivated = false;

            else if (invincibilityTimer > Time.timeSinceLevelLoad)
                invincibilityTimer -= Time.deltaTime;
        }


        if (isHealActivated)  //should autokill the heal
        {
            Invoke("StopHeal", 2.0f);
        }
    }



    #region Score
    private void UpdateScoreText() //update the score
    {
        if (textScore != null)
            textScore.text = score.ToString();
        
        if(highTextScore != null)
            highTextScore.text = highscore.ToString();
    }

    private void ScoreSetup()
    {
        if (textScore == null)
        {
            //Debug.Log("lookingfortxt");
            GameObject textScoreObject = GameObject.FindGameObjectWithTag("textScore");

            if (textScoreObject != null)
            {
                textScore = textScoreObject.GetComponent<TMP_Text>();
            }
        }

        if (highTextScore == null)
        {
            //Debug.Log("lookingfortxt");
            GameObject highTextScoreObject = GameObject.FindGameObjectWithTag("highTextScore");

            if (highTextScoreObject != null)
            {
                highTextScore = highTextScoreObject.GetComponent<TMP_Text>();
            }
        }
    }
    #endregion


    void StartCombat()
    {
        //when tutorial completed activate the wave manager && hide tuto canevas
    }




    #region PowerUp
    public void ActivateInvincibility(float duration)
    {
        isInvincibleActivated = true;
        invincibilityTimer = duration;
        score += pointPerPowerUp;
    }
    public void ActivateWeapon()
    {
        isWeaponActivated = true;  // to gather to know if I have two weapon
        score += pointPerPowerUp;
    }
    public void ActivateHeal()
    {
        isHealActivated = true;  // to gather if i'm healed
        score += pointPerPowerUp;
    }
    public void ActivateKillThemAll()
    {
        isKillThemAllActivated = true;  // don't touch already working NUKE
        score += pointPerPowerUp;

        foreach (string tag in enemyTagsToDestroy)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);

            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
                score += pointPerEnemyDestroyed;
            }
        }
    }

    void StopHeal()
    {
        isHealActivated = false;
    }

    #endregion


    #region SceneManagement
    public void LoadMainLevelScene()
    {
        SceneManager.LoadScene("MainLevel");
        Time.timeScale = 1;
        isGameOver = false;
        Invoke("ScoreSetup", 2.0f);
    }

    public void CloseGame()
    {
        Application.Quit();
    }


    #endregion


    


}

