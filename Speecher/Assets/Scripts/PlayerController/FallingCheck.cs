using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            Debug.Log(FallingPoint.rb.velocity.y);
        }

        if (collision.gameObject.tag.Equals("Ground") && FallingPoint.rb.velocity.y < -5)
        {
            Debug.Log("Damage");
        }
    }
}
