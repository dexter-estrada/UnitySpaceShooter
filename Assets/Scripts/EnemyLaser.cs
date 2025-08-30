using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{ 
    public float speed = 5f;
    public float endTimer = 3f;
    private Rigidbody2D rb;
    public float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * speed;
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer >= 3f)
        {
            Destroy(gameObject);
        }
    }
}
