using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAura : MonoBehaviour
{
    // Variables

    public CircleCollider2D aura;
    public float damage;
    
    // Start is called before the first frame update
    void Start()
    {
        aura = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().TakeDamage(damage * Time.deltaTime);
        }
    }
}
