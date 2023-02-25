using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotCamera : MonoBehaviour
{
    public int speed = 10;
    private float horizGo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizGo = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizGo*Time.deltaTime*speed);
    }

}
