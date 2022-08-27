using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDieTrigger : MonoBehaviour
{  
	public GameObject DieEffect;

	[SerializeField] private AudioSource GlassSound;
	[SerializeField] private AudioSource DieSound;

	AudioSource audioSource; 
  
    void Start()
    {
    	audioSource = GetComponent<AudioSource>(); 
        DieEffect.SetActive(false);
    }

    
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.name.Equals("Player"))  
         
         {
         	DieEffect.SetActive(true); 
         	GlassSound.Play();
         	DieSound.Play();
         } 
    }

    

}