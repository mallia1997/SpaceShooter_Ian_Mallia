using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private GameObject _enemyContainer;

    [SerializeField]
    private GameObject[] _powerupPrefabs;

    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        // infinite while loop
        // create new enemy objects
        // wait for 3 seconds
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8.5f, 8.5f), 7f, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.SetParent(_enemyContainer.transform);

            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator SpawnPowerupRoutine()
    {
        // spawn a powerup every 5 - 7 seconds
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8.5f, 8.5f), 7f, 0);

            // will calculate an index between 0 and powerup length - 1
            int index = Random.Range(0, _powerupPrefabs.Length);
            Instantiate(_powerupPrefabs[index], posToSpawn, Quaternion.identity);

            yield return new WaitForSeconds(Random.Range(5, 8));
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
