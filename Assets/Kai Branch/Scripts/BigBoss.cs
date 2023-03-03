using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoss : MonoBehaviour
{
    // Variables

    public float actionTime, bossCounter = 7.5f;
    public EnemyController enemy;

    public GameObject cans;
    public GameObject cansSpawn;

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
        int index = Random.Range(0, 4);
        Debug.Log("Skill " + (index + 1) +  " activates!");
        // Dash attack
        if (index == 0)
        {
            Vector2 dashPos = GameObject.Find("MIDDERBEAD").transform.position;
            transform.Translate(dashPos - new Vector2(transform.position.x, transform.position.y).normalized);
        }
        // Tri-Triple Projectiles
        if (index >= 1)
        {
            StartCoroutine(CanSpam());
        }
    }

    public IEnumerator CanSpam()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Instantiate(cans, cansSpawn.transform.position, cans.transform.rotation);
                yield return new WaitForSeconds(.1f);
            }
            yield return new WaitForSeconds(.5f);
        }
        StopCoroutine(CanSpam());
    }
}
