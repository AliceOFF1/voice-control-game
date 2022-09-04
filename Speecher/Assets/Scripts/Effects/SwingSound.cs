using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingSound : MonoBehaviour
{

    public GameObject trigger;

    [SerializeField] private AudioSource LaughSound;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))

        {
            LaughSound.Play();
            Destroy(trigger, 10f);
        }
    }

}

