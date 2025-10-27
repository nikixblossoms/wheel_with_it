using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject pit;
    public GameObject ground;
    public GameObject obstacle;
    public GameObject stairs;
    public GameObject pit_fuel;
    public GameObject ground_fuel;
    public GameObject obstacle_fuel;
    public GameObject stairs_fuel;
    public GameObject pit_money;
    public GameObject ground_money;
    public GameObject obstacle_money;
    public GameObject stairs_money;
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
            nextSpawnX = player.transform.position.x + 5f;
        }

        if (startRandom && player.transform.position.x + spawnDistance > nextSpawnX) {
        SpawnSegment(nextSpawnX);
        nextSpawnX += segmentWidth;
    }       
    }
    
    void SpawnSegment(float xPos) {
        float roll = Random.value; // 0.0 to 1.0

        if (roll < 0.4f){
            // 40% chance
            float subroll = Random.value;
            if (roll < 0.3f)
            {
                Instantiate(ground, new Vector2(xPos + 1f, positiongroundY), Quaternion.identity);

            }
            else if (roll < 0.6f)
            {
                Instantiate(ground_fuel, new Vector2(xPos + 1f, positiongroundY), Quaternion.identity);
            }
            else
            {
                Instantiate(ground_money, new Vector2(xPos + 1f, positiongroundY), Quaternion.identity);

            }        
        } else if (roll < 0.70f) {
            // 30% chance
            float subroll = Random.value;
            if (roll < 0.3f)
            {
                Instantiate(pit, new Vector2(xPos - 1f, positionpitY), Quaternion.identity);

            }
            else if (roll < 0.6f)
            {
                Instantiate(pit_fuel, new Vector2(xPos - 1f, positionpitY), Quaternion.identity);
            }
            else
            {
                Instantiate(pit_money, new Vector2(xPos - 1f, positionpitY), Quaternion.identity);

            }

        } else if (roll < 0.85f) {
            // 15% chance
            float subroll = Random.value;
            if (roll < 0.3f)
            {
                Instantiate(obstacle, new Vector2(xPos + 1f, positiongroundY), Quaternion.identity);

            }
            else if (roll < 0.6f)
            {
                Instantiate(obstacle_fuel, new Vector2(xPos + 1f, positiongroundY), Quaternion.identity);
            }
            else
            {
                Instantiate(obstacle_money, new Vector2(xPos + 1f, positiongroundY), Quaternion.identity);

            }
        } else {  
            // 15% chance
            float subroll = Random.value;
            if (roll < 0.3f)
            {
                Instantiate(stairs, new Vector2(xPos + 1f, positiongroundY), Quaternion.identity);

            }
            else if (roll < 0.6f)
            {
                Instantiate(stairs_fuel, new Vector2(xPos + 1f, positiongroundY), Quaternion.identity);
            }
            else
            {
                Instantiate(stairs_money, new Vector2(xPos + 1f, positiongroundY), Quaternion.identity);

            }        
        }
    }
}
