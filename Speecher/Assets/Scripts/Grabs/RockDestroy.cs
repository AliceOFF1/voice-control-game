using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("RockDestroyer"))
        {
            Destroy(gameObject, 0.1f);
        }
    }

}
