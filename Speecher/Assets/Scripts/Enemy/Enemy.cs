using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health;
    public float speed;
    public GameObject deathEffect;
    public int damage;
    private float stopTime;
    public float startStopTime;
    public float normalSpeed;
    private Player player;
    private Animator anim;
    public Transform attackPos;
    public LayerMask playeres;
    public float attackRange;


    private void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
        normalSpeed = speed;
    }

    private void Update()
    {

        if (health <= 0)
        {
            Destroy(gameObject);
        }


    }


    public void TakeDamage(int damage)
    {
        health -= damage;
    }


}
