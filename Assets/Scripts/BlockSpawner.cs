using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlockSpawner :MonoBehaviour {

    public GameObject obstacle;
    public GameObject newObstacle;
    public float screenHalfWidthInWorldUnits;
    public float screenHalfHeightInWorldUnits;
    public Vector2 secondsbetweenSpawnMinMax;
    float nextSpawnTime;

    public Vector3 spawnSizeMinMax;
    public float maxAngle;

    // Start is called before the first frame update
    void Start () {
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;
        screenHalfHeightInWorldUnits = Camera.main.orthographicSize;

    }

    // Update is called once per frame
    void Update () {
        if (Time.time > nextSpawnTime) {
            float secondsbetweenSpawn = Mathf.Lerp(secondsbetweenSpawnMinMax.y, secondsbetweenSpawnMinMax.x, Difficulty.GetDifficultPercentage());
            Spawn();
            nextSpawnTime = Time.time + secondsbetweenSpawn;
        }
    }

    public void Spawn () {
        float spawnAngle = Random.Range(-maxAngle, maxAngle);
        float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-screenHalfWidthInWorldUnits, screenHalfWidthInWorldUnits), transform.position.y + (spawnSize / 2f));
        newObstacle = Instantiate(obstacle, randomSpawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
        newObstacle.transform.localScale = Vector3.one * spawnSize;

        newObstacle.transform.parent = transform;
    }
}
