using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCreator : MonoBehaviour
{  

	public GameObject Rock; 
	public GameObject TriggerCreator;

	public void Start()
	{ 
		TriggerCreator.SetActive(true);
	}
    

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        

    	if (collision.CompareTag("Player")) 
    	{ 
    		Instantiate (Rock, Rock.transform.position, Quaternion.identity);
    		TriggerCreator.SetActive(false);
       	}
    } 
    
}
