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

	

    void Start()
    {  

       systemActions.Add("fire", Fire); 

       DestroyPoint.SetActive(false); 

       keywordRecognizer = new KeywordRecognizer(systemActions.Keys.ToArray()); 
	   keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
	   keywordRecognizer.Start();
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
      yield return new WaitForSeconds(0.1f); 
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
    } 

    
}
