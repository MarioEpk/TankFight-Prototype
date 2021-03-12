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
        Instantiate(enemyPrefab);
        //enemyPrefab.transform.position = GenerateRandomSpawnPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(10);
        Instantiate(enemyPrefab);
        enemyPrefab.transform.position = GenerateRandomSpawnPosition();
    }

    private Vector2 GenerateRandomSpawnPosition()
    {
        float locX = Random.Range(-10, 10);
        float locY = Random.Range(-10, 10);

        return new Vector2(locX, locY);

    }
}
