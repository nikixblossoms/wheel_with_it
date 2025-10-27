using UnityEngine;

public class BuildingSpawn : MonoBehaviour
{
    public GameObject building1;
    public GameObject building2;
    public GameObject building3;
    public GameObject building4;
    public GameObject lamp1;
    public GameObject lamp2;
    public GameObject player;
    public float segmentWidth = 8f;
    public float spawnDistance = 30f;

    private float nextSpawnX = 0f;
    private float positiongroundY = -3f;
    private bool startRandom = false;
    public float targetPosX = 120f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!startRandom && player.transform.position.x >= targetPosX)
        {
            startRandom = true;
            nextSpawnX = player.transform.position.x + 10f;
        }

        if (startRandom && player.transform.position.x + spawnDistance > nextSpawnX)
        {
            SpawnSegment(nextSpawnX);
            nextSpawnX += segmentWidth;
        }
    }

    void SpawnSegment(float xPos)
    {
        float roll = Random.value; // 0.0 to 1.0

        if (roll < 0.12)
        {
            Instantiate(building1, new Vector2(xPos, positiongroundY), Quaternion.identity);
        }
        else if (roll < 0.24)
        {
            Instantiate(building2, new Vector2(xPos, positiongroundY), Quaternion.identity);
        }
        else if (roll < 0.36)
        {
            Instantiate(building3, new Vector2(xPos, positiongroundY), Quaternion.identity);
        }
        else if (roll < 0.48)
        {
            Instantiate(building4, new Vector2(xPos, positiongroundY), Quaternion.identity);
        }
        else if (roll < 0.60)
        {
            Instantiate(lamp1, new Vector2(xPos, positiongroundY), Quaternion.identity);
        }
        else if (roll < 0.72)
        {
            Instantiate(lamp2, new Vector2(xPos, positiongroundY), Quaternion.identity);
        }
        else
        {
            nextSpawnX += segmentWidth;
        }
    }
}

