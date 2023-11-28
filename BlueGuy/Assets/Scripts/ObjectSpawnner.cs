using System.Collections;
using UnityEngine;

public class SpawnMoveDestroy : MonoBehaviour
{
    public GameObject prefabToSpawn1;
    public GameObject prefabToSpawn2;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public float moveSpeed = 1f;  // Adjust the moveSpeed to control the speed of the movement
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 5f;
    public float destroyAfterSeconds = 3f;

    private void Start()
    {
        StartCoroutine(SpawnMoveAndDestroyLoop());
    }

    IEnumerator SpawnMoveAndDestroyLoop()
    {
        while (true)
        {
            GameObject spawnedPrefab1 = SpawnPrefabAtPosition(prefabToSpawn1, spawnPoint1.position);
            GameObject spawnedPrefab2 = SpawnPrefabAtPosition(prefabToSpawn2, spawnPoint2.position);

            yield return StartCoroutine(MovePrefabsBetweenPoints(spawnedPrefab1.transform, spawnedPrefab2.transform, spawnPoint1, spawnPoint2));
            yield return new WaitForSeconds(destroyAfterSeconds);

            Destroy(spawnedPrefab1);
            Destroy(spawnedPrefab2);

            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
        }
    }

    GameObject SpawnPrefabAtPosition(GameObject prefab, Vector3 position)
    {
        if (prefab != null)
        {
            return Instantiate(prefab, position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Prefab to spawn is not assigned!");
            return null;
        }
    }

    IEnumerator MovePrefabsBetweenPoints(Transform objTransform1, Transform objTransform2, Transform point1, Transform point2)
    {
        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            objTransform1.position = Vector3.Lerp(point1.position, point2.position, elapsedTime);
            objTransform2.position = Vector3.Lerp(point2.position, point1.position, elapsedTime);

            elapsedTime += Time.deltaTime * moveSpeed;
            yield return null;
        }

        // Ensure the objects reach the endpoints exactly
        objTransform1.position = point2.position;
        objTransform2.position = point1.position;

        // Swap points for the return journey
        Transform temp = point1;
        point1 = point2;
        point2 = temp;

        elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            objTransform1.position = Vector3.Lerp(point1.position, point2.position, elapsedTime);
            objTransform2.position = Vector3.Lerp(point2.position, point1.position, elapsedTime);

            elapsedTime += Time.deltaTime * moveSpeed;
            yield return null;
        }

        // Ensure the objects reach the endpoints exactly
        objTransform1.position = point2.position;
        objTransform2.position = point1.position;
    }
}
