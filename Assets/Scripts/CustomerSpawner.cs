using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Reference to the customer prefab")]
    public GameObject customerPrefab;

    [SerializeField]
    [Tooltip("Point where the customer will be spawned")]
    public Transform spawnPoint;

    [SerializeField]
    [Tooltip("Time between each spawn in seconds")]
    public float spawnInterval = 3f;

    private float timer; // To countdown

    private int cusnum = 0; // number of customers

    void Start()
    {
        // Initialize the timer
        timer = spawnInterval;
    }

    void Update()
    {
        // Countdown the timer
        timer -= Time.deltaTime;

        // Check if it's time to spawn a new customer
        if (timer <= 0f && cusnum == 0)
        {
            SpawnCustomer();
            cusnum++;
            timer = spawnInterval; // Reset the timer
        }
    }

    void SpawnCustomer()
    {
        // Instantiates a new customer at the spawn point
        Instantiate(customerPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}