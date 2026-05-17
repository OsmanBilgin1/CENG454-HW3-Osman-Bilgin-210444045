using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private EnemyPool enemyPool;
    [SerializeField] private Transform spawnPoint;

    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float timeBetweenEnemies = 0.5f;

    private float countdown = 2f;
    private int waveIndex = 0;

    private void OnEnable()
    {
        EnemyEvents.OnEnemyReachedEnd += HandleEnemyReachedEnd;
        EnemyEvents.OnEnemyDied += HandleEnemyReachedEnd;
    }

    private void OnDisable()
    {
        EnemyEvents.OnEnemyReachedEnd -= HandleEnemyReachedEnd;
        EnemyEvents.OnEnemyDied -= HandleEnemyReachedEnd;
    }

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        WaveEvents.RaiseCountdownChanged(countdown);
    }

    private IEnumerator SpawnWave()
    {
        waveIndex++;

        WaveEvents.RaiseWaveStarted(waveIndex);

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
    }

    private void SpawnEnemy()
    {
        Enemy enemy = enemyPool.GetEnemy(spawnPoint.position, spawnPoint.rotation);
        WaveEvents.RaiseEnemySpawned(enemy);
    }

    private void HandleEnemyReachedEnd(Enemy enemy)
    {
        enemyPool.ReturnEnemy(enemy);
    }
}