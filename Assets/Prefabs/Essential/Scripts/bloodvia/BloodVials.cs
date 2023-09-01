using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodVials : MonoBehaviour
{

    public int value;

    AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.collectible);

            Destroy(gameObject);
            BloodVialsCollectibles.instance.IncreaseBloodVials(value);
        }
    }

}

