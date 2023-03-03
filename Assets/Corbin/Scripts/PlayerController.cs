using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Health
    [SerializeField] float health = 100f;
    [SerializeField] float maxHealth = 100f;

    //Player
    Rigidbody2D rb;
    BoxCollider2D bc;

    //Movement
    public float walkspeed;
    float speedLimiter = .7f;
    float horizontalInput;
    float verticalInput;
    Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        rb.gravityScale = 0.0f;

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        if(horizontalInput != 0 || verticalInput != 0)
        {
            if (horizontalInput != 0 && verticalInput != 0)
            {
                horizontalInput *= speedLimiter;
                verticalInput *= speedLimiter;
            }
            
            rb.velocity = new Vector2(horizontalInput * walkspeed, verticalInput * walkspeed);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
