using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPoint : MonoBehaviour
{

    public static Rigidbody2D rb;
    public float moveInput;
    public float speed;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }
}
