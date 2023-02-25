using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereGo : MonoBehaviour
{
    public float speed=10;
    public Rigidbody playerRb;
    private float Vert;
    public GameObject FocalPoint;
    public bool hasPower = false;
    private Rigidbody enemyRb;
    public int powerAway = 5;
    private Vector3 goAway;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        FocalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        
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
            Debug.Log("we have got the Power");
            StartCoroutine(PowerupCoroutine());
            Debug.Log("what about Power");
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy")&&hasPower) 
        {
            Debug.Log("we used the Power");
            enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            goAway = (collision.gameObject.transform.position-transform.position).normalized;
            enemyRb.AddForce(goAway* powerAway, ForceMode.Impulse);
           
        }

    }

    IEnumerator PowerupCoroutine()
    {
        yield return new WaitForSeconds(5);
        hasPower = false;
        Debug.Log("we losed the Power");
    }
}
