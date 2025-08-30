using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1;
    public GameObject laser;
    public float timer = 0f;
    String state = "Right"; // Right, Left, Down, Up
    private Rigidbody2D rb;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.x > 7)
        {
            state = "Left";
        }

        if (transform.position.x < -7)
        {
            state = "Right";
        }
        
        timer += Time.deltaTime;
        if (timer >= 2f)
        {
            Instantiate(laser);
            timer = 0f;
        }
    }

    private void FixedUpdate()
    {
        // right side x = 7
        if (state == "Right")
        {
            rb.velocity = Vector2.right * speed;
        }

        if (state == "Left")
        {
            rb.velocity = Vector2.left * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerLaser laser = other.GetComponent<PlayerLaser>();

        if (laser != null)
        {
            // Decrease Health
            
            // if Health == 0, destroy self and get a point
            Destroy(laser.gameObject);
            Destroy(gameObject);
        }
    }
}
