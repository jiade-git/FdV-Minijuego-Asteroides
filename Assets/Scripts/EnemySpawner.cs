using System.Numerics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{


    public GameObject asteroidPrefab;

    public float spawnRatePerMinute = 30f;

    public float spawnRateIncrement = 1f;

    public float xLimit;


    private float spawnNext = 0;


    
    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnNext)
        {
            spawnNext = Time.time + 60 / spawnRatePerMinute;

            spawnRatePerMinute += spawnRateIncrement;

            float rand = Random.Range(-xLimit, xLimit);

            UnityEngine.Vector2 spawnPosition = new UnityEngine.Vector2(rand, 8.5f);

            GameObject asteroide = PoolAsteroides.SharedInstance.GetPooledObject();
            if (asteroide != null)
            {
                asteroide.transform.position = spawnPosition;
                asteroide.transform.rotation = UnityEngine.Quaternion.identity;
                asteroide.SetActive(true);
            }

        }
    }
}
