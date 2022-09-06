using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSoundController : MonoBehaviour
{

    [SerializeField] private AudioSource GlassSound;
    [SerializeField] private AudioSource DieSound;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collider)

    {
        if (collider.GetComponent<Player>() != null)

        {
           
            GlassSound.Play();
            DieSound.Play();

        }

    }

    
}
