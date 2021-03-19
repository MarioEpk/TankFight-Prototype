using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private bool isPlayerAlive = true;
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject Death;


    private void Awake()
    {
       

        StartCoroutine(SpawnEnemy(enemyPrefab));
    }


    private void Update()
    {
        OnPlayerDeath();
    }

    IEnumerator SpawnEnemy(GameObject prefab)
    {
        while (isPlayerAlive)
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


    // activating Death object on player's death, giving the player an option to restart
    private void OnPlayerDeath()
    {
        if (isPlayerAlive) return;
        Death.SetActive(true);
    }


    public void SetIsAlive(bool isAlive)
    {
        isPlayerAlive = isAlive;
    }
}
