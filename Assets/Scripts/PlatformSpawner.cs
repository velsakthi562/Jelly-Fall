using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

    public GameObject platform;
    public GameObject spikePlatform;
    public GameObject[] movingPlatforms;
    public GameObject breakablePlatform;

    public float platformSpawnTimer;
    private float currentPlatformSpawnTimer;

    private int platformSpawnCount;

    public float minX = -2f;
    public float maxX = 2f;

    private bool isGameOver;

    public void SetGameOver(bool value)
    {
        isGameOver = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentPlatformSpawnTimer = platformSpawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
            SpawnPlatforms();
    }

    void SpawnPlatforms()
    {

        currentPlatformSpawnTimer += Time.deltaTime;

        if(currentPlatformSpawnTimer >= platformSpawnTimer) {

            platformSpawnCount++;

            Vector3 temp = transform.position;
            temp.x = Random.Range(minX, maxX);

            GameObject newPlatform = null;

            if(platformSpawnCount < 2)
            {

                newPlatform = Instantiate(platform, temp, Quaternion.identity);

            }
            else if(platformSpawnCount == 2)
            { 

                if(Random.Range(0, 2) > 0)
                {

                    newPlatform = Instantiate(platform, temp, Quaternion.identity);

                }
                else
                {

                    newPlatform = Instantiate(
                    movingPlatforms[Random.Range(0, movingPlatforms.Length)],
                        temp, Quaternion.identity);

                }

            }
            else if(platformSpawnCount == 3)
            {

                if (Random.Range(0, 2) > 0)
                {

                    newPlatform = Instantiate(platform, temp, Quaternion.identity);

                }
                else
                {

                    newPlatform = Instantiate(spikePlatform, temp, Quaternion.identity);

                }

            }
            else if (platformSpawnCount == 4)
            {

                if (Random.Range(0, 2) > 0)
                {

                    newPlatform = Instantiate(platform, temp, Quaternion.identity);

                } else {

                    newPlatform = Instantiate(breakablePlatform, temp, Quaternion.identity);

                }

                platformSpawnCount = 0;

            }

            if(newPlatform)
                newPlatform.transform.parent = transform;

            currentPlatformSpawnTimer = 0f;

        } 

    }


} 









































