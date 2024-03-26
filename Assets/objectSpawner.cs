using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private float spawnRange = 10;
    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        StartCoroutine(SpawnObjectsRoutine());
        IEnumerator SpawnObjectsRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                SpawnObjectsRandom();
            }
        }
    }

    void SpawnObjectsRandom()
    {
        float randomX = Random.Range(-spawnRange, spawnRange);
        float spawnY = spawnRange; 
        GameObject newObject = Instantiate(objectPrefab, new Vector3(randomX, spawnY, 0), Quaternion.identity);
        Destroy(newObject, 10);
        newObject.transform.eulerAngles = new Vector3(0, 0, 45);


        Rigidbody2D rb = newObject.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = newObject.AddComponent<Rigidbody2D>();
        }
        rb.gravityScale = .5f;

    }
}
