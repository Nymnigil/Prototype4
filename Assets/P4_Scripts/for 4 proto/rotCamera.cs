using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotCamera : MonoBehaviour
{
    public int speed = 10;
    private float horizGo;

    // Update is called once per frame
    void FixedUpdate()
    {
        horizGo = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizGo*Time.deltaTime*speed);
        
        if (Input.GetKey("escape")) 
        {
            Application.Quit();
        }
    }
}
