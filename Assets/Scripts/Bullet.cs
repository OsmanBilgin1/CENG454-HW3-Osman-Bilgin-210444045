using UnityEngine;

public class Bullet : MonoBehaviour 
{
    private Transform target;

    public float speed = 70f;
    public float damage = 50f;
    public GameObject impactEffect;
    
    public void Seek(Transform _target)
    {
        target = _target;

    }

    void Update() 
    {
        if (target == null || !target.gameObject.activeInHierarchy)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;


        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {

        if (impactEffect != null)
        {
            GameObject effectIns = Instantiate(
                impactEffect,
                transform.position,
                transform.rotation
            );

            Destroy(effectIns, 2f);
        }
        
        Enemy enemy = target.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}