using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rage : MonoBehaviour
{
    // Variables

    public EnemyController enemy;
    public float moddedSpeed;
    public float speedCap;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<EnemyController>();
        moddedSpeed = enemy.moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float speedFactor = 2 - (enemy.health / enemy.maxHealth);
        enemy.moveSpeed = moddedSpeed * speedFactor;
        if (speedFactor > 1.5f)
        {
            speedFactor = 1.5f;
        }
    }
}
