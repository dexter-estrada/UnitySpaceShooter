using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject laser;
    public float speed = 5;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(laser, transform.position, Quaternion.identity);
        }
    }
    
    void FixedUpdate()
    {
        /*if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector2.up * speed);
        }*/
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);
    }

    // void, int, float, boolean, String ("Hi I'm a string"), Rigidbody2D
    public int GetHealth()
    {
        return 0;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        // Damage player
        
        // Destroy other object
        if (enemy != null)
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
