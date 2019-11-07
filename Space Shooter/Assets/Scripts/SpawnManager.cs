using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private GameObject _enemyContainer;
    
    [SerializeField]

    private GameObject [] _PowerupPrefab;

    private bool _stopSpawning = false;

    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }

    // Update is called once per frame
    IEnumerator SpawnEnemyRoutine(){
        //infinite while loop
        //create new enemy objects
        //wait for 3 seconds
        while(_stopSpawning == false )
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8.5f, 8.5f), 7f, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.SetParent(_enemyContainer.transform);
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator SpawnPowerupRoutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8.5f, 8.5f), 7f, 0);
            
            int index = Random.Range(0, _PowerupPrefab.Length);
            Instantiate(_PowerupPrefab[index], posToSpawn, Quaternion.identity);


            yield return new WaitForSeconds(Random.Range(5,8));
        }
        //spawn a powerup every 5 - 7 seconds
    }
    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
