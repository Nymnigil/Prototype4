using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGo : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody enemyRb;
    public GameObject player;
    private Vector3 direct;
    public int destroyPoint = -3;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Sphere");
    }

    void FixedUpdate()
    {
        direct = (player.transform.position-transform.position).normalized;
        enemyRb.AddForce(direct*speed);
        if (transform.position.y< destroyPoint)
        {
            Destroy(gameObject);
        }
    }
}
