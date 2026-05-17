using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private int initialPoolSize = 20;

    private readonly Queue<Bullet> pool = new Queue<Bullet>();

    private void Awake()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            CreateBullet();
        }
    }

    private Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(bulletPrefab, transform);
        bullet.gameObject.SetActive(false);
        bullet.SetPool(this);
        pool.Enqueue(bullet);
        return bullet;
    }

    public Bullet GetBullet(Vector3 position, Quaternion rotation)
    {
        if (pool.Count == 0)
        {
            CreateBullet();
        }

        Bullet bullet = pool.Dequeue();

        bullet.transform.position = position;
        bullet.transform.rotation = rotation;
        bullet.gameObject.SetActive(true);

        return bullet;
    }

    public void ReturnBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        pool.Enqueue(bullet);
    }
}