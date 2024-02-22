using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Constspeed = 10;
    public float speed = 80;
    public float turnSpeed = 100;
    public float turnAngle = 40;
    private int health;

    private float HorizontalInput;
    private float VerticalInput;
    private float BoostInput;

    float xTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        health = 10;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            health--;
            Debug.Log("Hit" + health);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(health < 0)
        {
            Destroy(gameObject);
        }
        // Constant speed
        transform.Translate(Vector3.forward * Constspeed * Time.deltaTime);

        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");
        BoostInput = Input.GetAxis("Fire3");

        float xRotation = transform.rotation.eulerAngles.x;
        float zRotation = transform.rotation.eulerAngles.z;

        // Tilt up
        if (VerticalInput == 0)
        {
            xTimer += Time.deltaTime;
            if (xTimer >= 5)
            {
                if (xRotation <= 180 && xRotation > 5)
                {
                    transform.Rotate(Vector3.left * Time.deltaTime * turnSpeed);
                }
                else if (xRotation > 180 && xRotation < 355)
                {
                    transform.Rotate(Vector3.right * Time.deltaTime * turnSpeed);
                }
            }
        }
        else
        {
            xTimer = 0.0f;
            transform.Rotate(Vector3.right * Time.deltaTime * turnSpeed * VerticalInput);
        }

        // Boost forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * BoostInput);

        // Turn
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * HorizontalInput);

        if (HorizontalInput == 0)
        {

            if (zRotation <= 180 && zRotation > 5)
            {
                transform.Rotate(Vector3.back, Time.deltaTime * turnAngle);
            }
            else if (zRotation > 180 && zRotation < 355)
            {
                transform.Rotate(Vector3.forward, Time.deltaTime * turnAngle);
            }

        }
        else
        {
            transform.Rotate(Vector3.forward, Time.deltaTime * turnAngle * HorizontalInput);
        }

    }
}
