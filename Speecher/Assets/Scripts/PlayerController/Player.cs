using System.Collections;
using System.Collections.Generic; 
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Player : MonoBehaviour
{ 

	private KeywordRecognizer keywordRecognizer; 
	private Dictionary <string, System.Action> systemActions = new Dictionary<string, System.Action>();  

	public Transform attackPos;
	public LayerMask enemy;
	public float attackRange;
	public int damage; 
  public float health;
	public Animator anim; 
  public GameObject DestroyPoint;  

  public VectorValue pos;


  public bool PauseGame; 
  public GameObject DieWindow; 

  public GameObject FireEffect;
  public GameObject ParticleWaterDie; 

  public GameObject TriggerCreator;


	

    void Start() 
    {  
      transform.position = pos.initialValue;

       systemActions.Add("fire", Fire); 

       DestroyPoint.SetActive(false); 

       keywordRecognizer = new KeywordRecognizer(systemActions.Keys.ToArray()); 
	   keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
	   keywordRecognizer.Start();

     FireEffect.SetActive(true);
     ParticleWaterDie.SetActive(false);
    }  


    private void RecognizedSpeech(PhraseRecognizedEventArgs speech) 
    {
    	systemActions[speech.text].Invoke();
    }  
   
    // Update is called once per frame
    void Fire()
    { 
       
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
        for (int i = 0; i < enemies.Length; i++)
        {
        	enemies[i].GetComponent<Enemy>().TakeDamage(damage);
        } 

        StartCoroutine(DoDestroy());
    } 

    IEnumerator DoDestroy() 
   {
      DestroyPoint.SetActive(true);
      yield return new WaitForSeconds(4f); 
      DestroyPoint.SetActive(false); 
     
   }  


    void OnDrawGizmosSelected() 
    { 
    	if (attackPos == null)
    	return;

    	Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }  


    void OnCollisionEnter2D (Collision2D coll) 
   {
      if(coll.gameObject.tag =="Elevator") 
      {
         transform.parent = coll.gameObject.transform;
      } 

      if (coll.gameObject.tag =="ChekPoint") 
      {
         SavePlayer();
      } 

      if (coll.gameObject.tag =="DieTrigger") 
      {
         Die();
      }   
    }  

    public void OnTriggerEnter2D(Collider2D collision) 
    {
      if (collision.CompareTag("ChekPoint")) 
      {
         SavePlayer();
      }  

      if(collision.gameObject.tag.Equals("DieTrigger")) 
      { 
        ParticleWaterDie.SetActive(true);
      } 
    }   


     public void SavePlayer() 
   {
      SaveSystem.SavePlayer(this); 
   } 

   public void LoadPlayer() 
   {
      PlayerData data = SaveSystem.LoadPlayer(); 

      Vector3 position; 
      position.x = data.position[0]; 
      position.y = data.position[1]; 
      position.z = data.position[2]; 
      transform.position = position;  

      DieWindow.SetActive(false); 
  	  Time.timeScale = 1f; 
  	  PauseGame = false;
      FireEffect.SetActive(true);
      ParticleWaterDie.SetActive(false); 
      TriggerCreator.SetActive(true);

    } 

    void Die() 
    {
      DieWindow.SetActive(true);
      FireEffect.SetActive(false);
      ParticleWaterDie.SetActive(true);
    }


}
