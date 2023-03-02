using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Variables

    public static event Action<EnemyController> OnEnemyKilled;
    public float health, maxHealth = 60f;
    public float damage = 10f;

    public float moveSpeed = 4f;
    public float attackCool, attackSpeed = 0.75f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        target = GameObject.Find("MIDDERBEAD").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            /*
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            */
            moveDirection = direction;
        }

        if (attackCool > 0)
        {
            attackCool -= Time.deltaTime;
        }
        if (attackCool <= 0)
        {
            attackCool = 0;
        }
    }

    private void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && attackCool == 0)
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
            attackCool = attackSpeed;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            OnEnemyKilled?.Invoke(this);
        }
    }
}
