using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Elevator : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> systemActions = new Dictionary<string, System.Action>();

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private float flipper;

    public float speed = 10f;

    public bool Acivate;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        Acivate = false;
        flipper = 0f;
        systemActions.Add("up", Up);
        systemActions.Add("down", Down);
        systemActions.Add("pause", Pause);

        keywordRecognizer = new KeywordRecognizer(systemActions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        systemActions[speech.text].Invoke();
    }


    // Update is called once per frame
    private void Down()
    {
        flipper = 1f;
    }

    private void Up()
    {
        flipper = -1f;
    }

    private void Pause()
    {
        flipper = 0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Acivate = true;
            Debug.Log("crasava");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Acivate = false;
            Debug.Log("crasava");
        }
    }


    public void Update()
    {
        if (Acivate == true && flipper > 0)
        {
            transform.position += new Vector3(0, -0.05f, 0) * speed * Time.deltaTime;
        }

        if (Acivate == true && flipper < 0)
        {
            transform.position += new Vector3(0, 0.05f, 0) * speed * Time.deltaTime;
        }

        if (flipper == 0f)
        {
            transform.position += new Vector3(0, 0, 0) * speed * Time.deltaTime;
        }
    }


}
