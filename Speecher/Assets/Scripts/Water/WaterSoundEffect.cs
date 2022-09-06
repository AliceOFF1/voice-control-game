using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSoundEffect : MonoBehaviour
{

    [SerializeField] private AudioSource GlassSound;
    [SerializeField] private AudioSource WaterSound;
    [SerializeField] private AudioSource DieSound;

    AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collider)

    {
        if (collider.GetComponent<Player>() != null)

        {

            GlassSound.Play();
            WaterSound.Play();
            DieSound.Play();

        }

    }


}
