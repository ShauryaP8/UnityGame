using System.Collections.Generic;
using UnityEngine;

public class InfiniteGroundManager : MonoBehaviour
{
    public GameObject groundPrefab; // The ground section prefab
    public int numberOfGrounds = 5; // How many ground sections to pool
    public float groundLength = 50f; // The length of each ground section

    private float spawnZ = 0.0f; // Z position where the next ground section will be spawned
    private List<GameObject> activeGrounds; // List to keep track of active ground sections
    private Transform playerTransform; // Reference to the player's transform

    void Start()
    {
        activeGrounds = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Make sure your player has the "Player" tag

        // Initialize the ground pool
        for (int i = 0; i < numberOfGrounds; i++)
        {
            SpawnGround(i * groundLength);
        }
    }

    void Update()
    {
        // Check if the player has passed the first ground section
        if (playerTransform.position.z - 50 > (spawnZ - numberOfGrounds * groundLength))
        {
            SpawnGround(spawnZ);
            spawnZ += groundLength;
            DeleteGround();
        }
    }

    private void SpawnGround(float spawnZ)
    {
        GameObject ground = Instantiate(groundPrefab, Vector3.forward * spawnZ, Quaternion.identity);
        activeGrounds.Add(ground);
    }

    private void DeleteGround()
    {
        Destroy(activeGrounds[0]);
        activeGrounds.RemoveAt(0);
    }
}
