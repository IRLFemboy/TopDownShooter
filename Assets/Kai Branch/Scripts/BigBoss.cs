using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoss : MonoBehaviour
{
    // Variables

    public float actionTime, bossCounter = 7.5f;
    public EnemyController enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<EnemyController>();
        actionTime = bossCounter;
    }

    // Update is called once per frame
    void Update()
    {
        actionTime -= Time.deltaTime;
        if (actionTime <= 0)
        {
            SkillCharge();
            actionTime = bossCounter;
        }
    }

    public void SkillCharge()
    {
        Debug.Log("Skill Activates!");
        int index = Random.Range(0, 4);
        // Dash attack
        if (index >= 0)
        {
            Vector2 dashPos = GameObject.Find("MIDDERBEAD").transform.position;
            transform.Translate(dashPos - new Vector2(transform.position.x, transform.position.y).normalized);
        }
    }
}
