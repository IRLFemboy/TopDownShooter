using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Variables

    public GameObject player;
    public Vector2 tether;
    public float distanceLimiterX;
    public float distanceLimiterY;
    public Vector2 distanceLimiter;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("MIDDERBEAD");
    }

    // Update is called once per frame
    void Update()
    {
        tether = transform.parent.gameObject.transform.position;
        //transform.Translate(new Vector2((player.transform.position.x - transform.position.x) + tether.transform.position.x, (player.transform.position.y - transform.position.y) + tether.transform.position.y));
        transform.position = (player.transform.position - transform.position).normalized * distanceLimiter + tether;
        /*
        if (transform.position.x > distanceLimiterX)
        {
            transform.position = new Vector2(distanceLimiterX, transform.position.y);
        }
        if (transform.position.y > distanceLimiterY)
        {
            transform.position = new Vector2(transform.position.x, distanceLimiterY);
        }
        */
        Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }
}
