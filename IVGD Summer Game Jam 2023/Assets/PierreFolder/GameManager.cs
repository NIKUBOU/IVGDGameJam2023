using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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


    // Start is called before the first frame update
    void Start()
    {
        //safeguardGameManager
        DontDestroyOnLoad(gameObject);

        //resetgameover
        isGameOver = false;
        Time.timeScale = 1;

        //Reset PowerUp on start
        isInvincibleActivated = false;
        isKillThemAllActivated = false;
        isWeaponActivated = false;
        isHealActivated = false;
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
    }

    void StopHeal()
    {
        isHealActivated = false;
    }


    void StartGame()
    {
        //Start Game
        Time.timeScale = 1;
        isGameOver = false;

        //main menu start button load the game scene on the toto canevas
    }

    void StartCombat()
    {
        //when tutorial completed activate the wave manager && hide tuto canevas
    }


    #region PowerUp
    public void ActivateInvincibility(float duration)
    {
        isInvincibleActivated = true;
        invincibilityTimer = duration;
    }
    public void ActivateWeapon()
    {
        isWeaponActivated = true;  // to gather to know if I have two weapon
    }
    public void ActivateHeal()
    {
        isHealActivated = true;  // to gather if i'm healed
    }
    public void ActivateKillThemAll()
    {
        isKillThemAllActivated = true;  // don't touch already working NUKE

        foreach (string tag in enemyTagsToDestroy)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);

            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
        }
    }
    #endregion

}

