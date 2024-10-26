using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject customer_key; // Drag the customer prefab here
    public int numberOfCustomers = 5; // Set how many customers to spawn
    public Vector3 startPosition = new Vector3(0, 0, 0); // Where the first customer will be spawned
    public float spacing = 2.0f; // Distance between each customer
    public bool horizontalLine = true; // Set to false for vertical line

    void Start()
    {
        SpawnCustomers();
    }

    private void SpawnCustomers()
    {
        for (int i = 0; i < numberOfCustomers; i++)
        {
            Vector3 spawnPosition;

            if (horizontalLine)
            {
                // Spawn customers in a horizontal line (along x-axis)
                spawnPosition = startPosition + new Vector3(i * spacing, 0, 0);
                //spawnPosition = startPosition + new Vector3(i * spacing, 0, i * spacing); //Diagonal line
                //float randomSpacing = Random.Range(1.0f, 3.0f);
                //spawnPosition = startPosition + new Vector3(I * randomSpacing, 0, 0);
            }
            else
            {
                // Spawn customers in a vertical line (along z-axis)
                spawnPosition = startPosition + new Vector3(0, 0, i * spacing);
            }

            Instantiate(customer_key, spawnPosition, Quaternion.identity);
        }
    }
}