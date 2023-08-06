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

    private AudioSource audioSource;


    GameManager gameManager;

    public float powerUpDuration = 10f; // for invincible

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        GetComponent<Rigidbody>().velocity = Vector3.down * fallingSpeed;

        audioSource = GetComponent<AudioSource>();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource reference is null.");
            return;
        }


        if (other.gameObject.CompareTag("Player") && myPowerUpType == PowerUpType.Invincible)
        {
           gameManager.ActivateInvincibility(powerUpDuration);
                

           //AudioSource audioSource = GetComponent<AudioSource>();
           if (audioSource != null)
           {
                audioSource.Play(); // Play the audio clip from the AudioSource component
                    
           }


           Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Player") && myPowerUpType == PowerUpType.KillThemAll)
        {
           gameManager.ActivateKillThemAll();
                
           //AudioSource audioSource = GetComponent<AudioSource>();
           if (audioSource != null)
           {
                audioSource.Play(); // Play the audio clip from the AudioSource component
                
           }

            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Player") && myPowerUpType == PowerUpType.Weapon)
        {
            gameManager.ActivateWeapon();
                
            //AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play(); // Play the audio clip from the AudioSource component
            }

            Invoke("SelfDestroy", 1.0f);
        }
         else if (other.gameObject.CompareTag("Player") && myPowerUpType == PowerUpType.Heal)
         {
            gameManager.ActivateHeal();
                

            //AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play(); // Play the audio clip from the AudioSource component
            }

            Destroy(gameObject);
        }

    }

    

}


