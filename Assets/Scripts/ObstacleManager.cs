using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject pit;
    public GameObject ground;
    public GameObject obstacle;
    public GameObject player;
    public float segmentWidth = 8.5f;
    public float spawnDistance = 30f;

    private float nextSpawnX = 0f;
    private float positiongroundY = -10.9f;
    private float positionpitY = -6.475f;
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
            nextSpawnX = player.transform.position.x;
        }

        if (startRandom && player.transform.position.x + spawnDistance > nextSpawnX) {
        SpawnSegment(nextSpawnX);
        nextSpawnX += segmentWidth;
    }       
    }
    
    void SpawnSegment(float xPos) {
        float roll = Random.value; // 0.0 to 1.0

        if (roll < 0.4f) {
            // 40% chance
            Instantiate(ground, new Vector2(xPos + 1f, positiongroundY), Quaternion.identity);
        } else if (roll < 0.70f) {
            // 30% chance
            Instantiate(pit, new Vector2(xPos - 1f, positionpitY), Quaternion.identity);
        } else {
            // 30% chance
            Instantiate(obstacle, new Vector2(xPos + 1f, positiongroundY), Quaternion.identity);
        }

    }
}
