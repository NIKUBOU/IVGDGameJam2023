using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PowerUp;


public class PowerUp : MonoBehaviour
{
    public enum PowerUpType
    {
        Invincible,
        KillThemAll,
        Weapon,
        Heal,
    }

    [Header("PowerUpVariable")]
    [SerializeField] private PowerUpType myPowerUpType;
    [SerializeField] private float fallingSpeed;


    GameManager gameManager;

    public float powerUpDuration = 10f; // for invincible

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        GetComponent<Rigidbody>().velocity = Vector3.down * fallingSpeed;
    }

    
    private void OnTriggerEnter(Collider other)
    {
                
            if (other.gameObject.CompareTag("Player") && myPowerUpType == PowerUpType.Invincible)
            {
                gameManager.ActivateInvincibility(powerUpDuration);
                Destroy(gameObject);
            }
            else if (other.gameObject.CompareTag("Player") && myPowerUpType == PowerUpType.KillThemAll)
            {
                gameManager.ActivateKillThemAll();
                Destroy(gameObject);
            }
            else if (other.gameObject.CompareTag("Player") && myPowerUpType == PowerUpType.Weapon)
            {
                gameManager.ActivateWeapon();
                Destroy(gameObject); 
            }
            else if (other.gameObject.CompareTag("Player") && myPowerUpType == PowerUpType.Heal)
            {
            gameManager.ActivateHeal();
                Destroy(gameObject); 
            }
                    
        
    }

}


