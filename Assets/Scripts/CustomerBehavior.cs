using UnityEngine;
using UnityEngine.UI;

public class CustomerBehavior : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Movement speed in meters per second")]
    public float moveSpeed = 3f;

    [SerializeField]
    [Tooltip("Target Transform to move towards")]
    public Transform targetPoint;


    private bool isMoving = true; // To check if the sprite is currently moving
    public GameObject[] bubblePrefab; // Reference to the bubble prefab

    void Update()
    {
        if (isMoving)
        {
            // Move towards the target point
            float step = moveSpeed * Time.deltaTime; // Calculate distance to move
            transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, step);

            // Check if the sprite has reached the target position
            if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
            {
                // Stop moving and generate the query
                isMoving = false;
                GenerateBubble();
            }
        }
    }

    void GenerateBubble()
    {
        int rand = Random.Range(0, bubblePrefab.Length); // Get a random prefab index
        GameObject bubble = Instantiate(bubblePrefab[rand], transform.position, Quaternion.identity); // Instantiate at customer position

        // Adjust bubble position above the customer by modifying its transform directly afterward
        bubble.transform.position = new Vector3(transform.position.x - 1, transform.position.y + 2, transform.position.z);

    }
}