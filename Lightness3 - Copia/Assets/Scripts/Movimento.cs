using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    public float speed;
    public bool isMoving = false;
    public GameObject luz;

    

    private void Start()
    {
   
    }

    private void Movement()
    {
        Vector2 movement = Vector2.zero;
        if (Input.GetAxis("Vertical") != 0)
        {
            movement = new Vector2(0, Input.GetAxis("Vertical"));
            isMoving = true;
        }
        else if (Input.GetAxis("Horizontal") != 0)
        {
            movement = new Vector2(Input.GetAxis("Horizontal"), 0);
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        transform.Translate(movement * speed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        LightCreation Light = luz.GetComponent<LightCreation>();
        
        if (Light.lightOn == true)
        {
            speed = 0;
        }
        else
        {
            speed = 10;
            Movement();
        }
        
    }
}
