using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrusters : MonoBehaviour
{
    public Vector3 scale = new Vector3(40, 1, 1);
    public Vector3 position = new Vector3(3.2f, 2.4f, -8.4f);
    public Vector3 rotation = new Vector3(0f, 195f, 0f);

    public Vector3 boostScale = new Vector3(100, 20, 1);
    public Vector3 boostPosition = new Vector3(2.7f, 2.4f, -8.4f);
    public Vector3 boostRotation = new Vector3(0, 180, 0);
    public float lifeTime = 5;
    public float speed = 50;
    

    private float BoostInput;
    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        var main = ps.main;

        BoostInput = Input.GetAxis("Fire3");
        if(BoostInput == 0)
        {
            main.startLifetime = 3;
            main.simulationSpeed = 10;

            transform.localScale = scale;
            transform.localPosition = position;
            transform.localRotation = Quaternion.Euler(rotation);
        }
        else
        {
            main.startLifetime = lifeTime;
            main.simulationSpeed = speed;

            transform.localScale = boostScale;
            transform.localPosition = boostPosition;
            transform.localRotation = Quaternion.Euler(boostRotation);
        }
    }
}
