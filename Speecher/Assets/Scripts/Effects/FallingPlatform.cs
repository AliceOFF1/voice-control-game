using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    public float timer;
    private bool Activate;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Activate = false;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))

        {
            timer = 3f;
            Activate = true;

        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))

        {
            timer = 0f;
            Activate = false;

        }

    }



    void FallPlatform()
    {
        rb.isKinematic = false;
    }

    private void Update()
    {
        if (timer > 0 && Activate == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                FallPlatform();
            }
        }
    }

}
