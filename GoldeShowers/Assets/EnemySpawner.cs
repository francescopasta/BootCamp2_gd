using UnityEngine;
using System.Collections.Generic;

public class RandomSpawner : MonoBehaviour
{
    public GameObject spawnablePrefab; 
    public float spawnInterval = 2f; 
    public Vector3 spawnArea = new Vector3(10, 0, 10); 
    public int maxSpawnedObjects = 10; 

    private List<GameObject> spawnedObjects = new List<GameObject>(); 

    private void Start()
    {
        InvokeRepeating(nameof(SpawnObject), 0f, spawnInterval);
    }

    private void SpawnObject()
    {
        if (spawnedObjects.Count >= maxSpawnedObjects)
        {
            Debug.Log("Maximum number of spawned objects reached.");
            return;
        }

        Vector3 randomPosition = new Vector3(
            Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
            Random.Range(-spawnArea.y / 2, spawnArea.y / 2),
            Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
        );

        GameObject spawnedObject = Instantiate(spawnablePrefab, transform.position + randomPosition, Quaternion.identity);
        spawnedObjects.Add(spawnedObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, spawnArea);
    }

    private void Update()
    {
        spawnedObjects.RemoveAll(item => item == null);
    }
}