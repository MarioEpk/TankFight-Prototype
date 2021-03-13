using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    [SerializeField]
    private GameObject enemyPrefab;
    void Start()
    {
        StartCoroutine(SpawnEnemy(enemyPrefab));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    IEnumerator SpawnEnemy(GameObject prefab)
    {
        while (true)
        {
            Instantiate(prefab);
            prefab.transform.position = GenerateRandomSpawnPosition();
            yield return new WaitForSeconds(5f);
        }
    }

    private Vector2 GenerateRandomSpawnPosition()
    {
        float locX = Random.Range(-10, 10);
        float locY = Random.Range(-10, 10); 

        return new Vector2(locX, locY);

    }
}
