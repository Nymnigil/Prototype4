using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereGo : MonoBehaviour
{
    private float speed=12;
    private Rigidbody playerRb;
    private float Vert;
    private GameObject FocalPoint;
    private bool hasPower = false;
    private Rigidbody enemyRb;
    private int powerAway = 10;
    private Vector3 goAway;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        FocalPoint = GameObject.Find("FocalPoint");
    }

    void FixedUpdate()
    {
        Vert = Input.GetAxis("Vertical");
        playerRb.AddForce(FocalPoint.transform.forward*Vert*speed*Time.deltaTime, ForceMode.VelocityChange);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("stronger"))
        {
            hasPower = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCoroutine());
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy")&&hasPower) 
        {
            enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            goAway = (collision.gameObject.transform.position-transform.position).normalized;
            enemyRb.AddForce(goAway* powerAway, ForceMode.Impulse);  
        }
    }

    IEnumerator PowerupCoroutine()
    {
        yield return new WaitForSeconds(10);
        hasPower = false;
    }
}
