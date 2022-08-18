using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int spawnNum = 1;
    [SerializeField] float spawnRadius = 5f;
    [SerializeField] float spawnCooldown;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    /// <summary>
    /// ìGèoåªÇÃCoroutine
    /// </summary>
    /// <returns></returns>
    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            for(var i = 0; i < spawnNum; i++)
            {
                var distanceVector = new Vector3(Random.Range(spawnRadius - 1, spawnRadius), 0);
                var spawnPositionFromPlayer = Quaternion.Euler(0, Random.Range(0, 360f), 0) * distanceVector;
                var spawnPosition = player.transform.position + spawnPositionFromPlayer;
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }
            yield return new WaitForSeconds(spawnCooldown);
        }
    }
}
