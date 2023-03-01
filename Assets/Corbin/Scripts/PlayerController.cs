using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    //Player
    Rigidbody2D rb;
    BoxCollider2D bc;

    //Movement
    public float walkspeed;
    public float speedLimiter;
    float horizontalInput;
    float verticalInput;


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
}
