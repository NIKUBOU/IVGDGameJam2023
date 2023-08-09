using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    //powerUp
    [Header("PowerUP")]
    public bool isInvincibleActivated;
    public bool isKillThemAllActivated;
    public bool isWeaponActivated;
    public bool isHealActivated;

    private float invincibilityTimer = 0f; // for invicible
    public string[] enemyTagsToDestroy = { "EnemyA", "EnemyB", "EnemyC" }; // for kill them all

    public AudioSource audioPowerUp;

    public ShmupManager shmupManager; //added crapcode

    //end game
    [Header("gameover")]
    public bool isGameOver;
    public bool bossIsDead;


    //Scoreing
    [Header("Scoreing")]
    public int score;
    public int highscore;
    public int pointPerPowerUp = 500;
    public int pointPerEnemyDestroyed = 100;
    public int pointPerBossDestroyed = 1000;
    public TMP_Text textScore;
    public TMP_Text highTextScore;


    // Start is called before the first frame update
    void Start()
    {
        //safeguardGameManager
        DontDestroyOnLoad(gameObject);


        Reset();

        ScoreSetup();
    }

    void Reset()
    {
        isGameOver = false;
        Time.timeScale = 1;
        score = 0;
        UpdateScoreText();

        isInvincibleActivated = false;
        isKillThemAllActivated = false;
        isWeaponActivated = false;
        isHealActivated = false;
        bossIsDead = false;
    }


    // Update is called once per frame
    void Update()
    {
        //scoreing
        if (score > highscore)
        {
            highscore = score;
        }
               
        
        

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

        if (bossIsDead)
        {
            Invoke("LoadGameOver", 0.5f);
            bossIsDead=false;
        }
            

        //added crapcode
        if (shmupManager.PlayerCurrentLife <= 0)
        {
            LoadGameOver();
        }

    }

    void LateUpdate()
    {
        ScoreSetup();
        UpdateScoreText(); // update the score UI
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

    public void GiveMeEnemyPoint()
    {
        score += pointPerEnemyDestroyed;
    }

    public void GiveMeBossPoint()
    {
        score += pointPerBossDestroyed;
    }
    #endregion






    #region PowerUp
    public void ActivateInvincibility(float duration)
    {
        isInvincibleActivated = true;
        invincibilityTimer = duration;
        score += pointPerPowerUp;

        audioPowerUp.Play();
    }
    public void ActivateWeapon()
    {
        isWeaponActivated = true;  // to gather to know if I have two weapon
        score += pointPerPowerUp;

        audioPowerUp.Play();
    }
    public void ActivateHeal()
    {
        isHealActivated = true;  // to gather if i'm healed
        score += pointPerPowerUp;
        //shmupManager.PlayerCurrentLife = shmupManager.PlayerMaxLife; //added crapcode

        audioPowerUp.Play();
    }
    public void ActivateKillThemAll()
    {
        isKillThemAllActivated = true;  // don't touch already working NUKE
        score += pointPerPowerUp;

        audioPowerUp.Play();

        foreach (string tag in enemyTagsToDestroy)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);

            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
                GiveMeEnemyPoint();
            }
        }
    }

    void StopHeal()
    {
        isHealActivated = false;
    }

    #endregion


    #region SceneManagement
    public void LoadControllScene()
    {
        SceneManager.LoadScene("ControlsScreen");
        Time.timeScale = 1;
        isGameOver = false;
        //Invoke("ScoreSetup", 0.5f);
        Reset();
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
        Reset();
        //Invoke("ScoreSetup", 0.5f);
    }

    public void LoadCombatScene()
    {
        SceneManager.LoadScene("MainLevel");
        //Invoke("ScoreSetup", 0.5f);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOverScene");
        //Invoke("ScoreSetup", 0.5f);
    }

    #endregion


    


}

