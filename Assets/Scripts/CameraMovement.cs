using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public Vector2 minBounds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 targetPosition = player.position + offset;

            float clampedX = Mathf.Max(targetPosition.x, minBounds.x);
            float clampedY = Mathf.Max(targetPosition.y, minBounds.y);

            transform.position = new Vector3(clampedX, clampedY, targetPosition.z);

    }
    }
}
