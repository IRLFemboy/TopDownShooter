using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Variables

    public float moveSpeed;
    public float lifeTime;
    public float damage;
    public Vector2 spawnPos;
    public Vector2 target;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;
        target = new Vector2(GameObject.Find("MIDDERBEAD").transform.position.x, GameObject.Find("MIDDERBEAD").transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime * (target - spawnPos).normalized);
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(-damage);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
