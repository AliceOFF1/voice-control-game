using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeLightActivate : MonoBehaviour
{  

	public GameObject trigger;

	[SerializeField] private AudioSource HorrorSound;

	AudioSource audioSource; 
  
    void Start()
    {
    	audioSource = GetComponent<AudioSource>(); 

    }

    
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.name.Equals("Player"))  
         
         {
        	HorrorSound.Play(); 
        	Destroy(trigger, 10f);
         } 
    }

}

    
