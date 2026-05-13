using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private int initialPoolSize = 10;

    private readonly Queue<Enemy> pool = new Queue<Enemy>();

    private void Awake()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            CreateEnemy();
        }
    }

    private Enemy CreateEnemy()
    {
        Enemy enemy = Instantiate(enemyPrefab, transform);
        enemy.gameObject.SetActive(false);
        pool.Enqueue(enemy);
        return enemy;
    }

    public Enemy GetEnemy(Vector3 position, Quaternion rotation)
    {
        if (pool.Count == 0)
        {
            CreateEnemy();
        }

        Enemy enemy = pool.Dequeue();

        enemy.transform.position = position;
        enemy.transform.rotation = rotation;
        enemy.ResetEnemy();
        enemy.gameObject.SetActive(true);

        return enemy;
    }

    public void ReturnEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
        pool.Enqueue(enemy);
    }
}