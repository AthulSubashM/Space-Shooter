using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidField : MonoBehaviour
{
    public Transform asteroidPrefab;
    public int fieldRadius = 1700;
    public int asteroidCount = 2000;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < asteroidCount; i++)
        {
            Transform asteroid = Instantiate(asteroidPrefab, Random.insideUnitSphere * fieldRadius, Random.rotation);
            asteroid.localScale = asteroid.localScale * Random.Range(0.5f, 30);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
