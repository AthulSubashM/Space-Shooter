using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public GameObject player;

    public float minSpin = 1f;
    public float maxSpin = 5f;
    public float minThrust = 0.1f;
    public float maxThrust = 1f;
    int health;

    private float spinSpeed;
    // Start is called before the first frame update
    void Start()
    {
        spinSpeed = Random.Range(minSpin, maxSpin);
        float thrust = Random.Range(minThrust,maxThrust);

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.mass = transform.localScale.x * 0.5f;
        rb.AddForce(transform.forward * thrust, ForceMode.Impulse);
        health = 5;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            health--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(health < 0)
        {
            Destroy(gameObject);
            Debug.Log("Destroyed");
        }
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }
}
