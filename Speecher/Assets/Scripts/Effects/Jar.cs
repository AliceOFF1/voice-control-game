using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jar : MonoBehaviour
{  

	[SerializeField] private AudioSource JarSound;

	AudioSource audioSource; 
  
    void Start()
    {
    	audioSource = GetComponent<AudioSource>(); 

    }

    
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.name.Equals("Player"))  
         
         {
        	JarSound.Play(); 
         } 
    }

}
