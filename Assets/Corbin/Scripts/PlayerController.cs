using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Health
    [SerializeField] float health = 100f;
    [SerializeField] float maxHealth = 100f;
    public static float playerDamage = 20f;

    //Player
    Rigidbody2D rb;
    BoxCollider2D bc;

    //Movement
    public float walkspeed;
    float speedLimiter;
    float horizontalInput;
    float verticalInput;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();

        speedLimiter = Mathf.Sqrt(walkspeed * ((horizontalInput * horizontalInput) + (verticalInput * verticalInput)));
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        rb.gravityScale = 0.0f;
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
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
