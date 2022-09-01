using System.Collections;
using System.Collections.Generic; 
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeecherMovement : MonoBehaviour
{  
	private KeywordRecognizer keywordRecognizer; 
	private Dictionary <string, System.Action> systemActions = new Dictionary<string, System.Action>();  

  private Rigidbody2D rb; 
	private SpriteRenderer sr;  

	private float flipper; 

	public float speed = 10f;

	public Transform Target; 


    void Start()
    { 
       rb = GetComponent<Rigidbody2D>(); 
       sr = GetComponent<SpriteRenderer>(); 
       flipper = 0f;
       systemActions.Add("back", Back);  
       systemActions.Add("go", Go); 
       systemActions.Add("stop", Stop); 

       keywordRecognizer = new KeywordRecognizer(systemActions.Keys.ToArray()); 
	     keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
	     keywordRecognizer.Start();
    }  


    private void RecognizedSpeech(PhraseRecognizedEventArgs speech) 
    {
    	systemActions[speech.text].Invoke();
    }


    // Update is called once per frame
    private void Back()
    {
       	flipper = 1f; 
       	transform.rotation = Quaternion.Euler(0,180f,0);
    } 

    private void Go()
    {
       	flipper = -1f;  
       	transform.rotation = Quaternion.Euler(0,0,0); 
    }  

     private void Stop()
    {
       	flipper = 0f; 
    }   


    public void Update() 
    { 

    

    	if (flipper > 0) 
    	{
    		transform.position += new Vector3 (-0.05f,0,0) * speed * Time.deltaTime;  
    	}

    	if (flipper < 0) 
    	{
    		transform.position += new Vector3 (0.05f,0,0) * speed * Time.deltaTime;
    	} 

    	if (flipper == 0f) 
    	{
    		transform.position += new Vector3 (0,0,0) * speed * Time.deltaTime;  
    	} 
    }	 


     private void OnTriggerEnter2D(Collider2D collision) 
    {
      if(collision.gameObject.tag.Equals("DieTrigger")) 
      { 
        Stop();
      } 
    }  
    
}


