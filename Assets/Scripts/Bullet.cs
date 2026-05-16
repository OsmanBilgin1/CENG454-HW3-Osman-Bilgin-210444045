using UnityEngine;

public class Bullet : MonoBehaviour 
{
    private Transform target;

    public float speed = 70f;
    public GameObject impactEffect;
    
    public void Seek(Transform _target)
    {
        target = _target;

        if (target != null)
            Debug.Log("Seek çalıştı. Target: " + target.name);
        else
            Debug.LogWarning("Seek çalıştı ama target null geldi!");
    }

    void Update() 
    {
        if (target == null)
        {
            Debug.LogWarning("Target null. Bullet kendini siliyor: " + gameObject.name);
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        Debug.Log("Bullet distance: " + dir.magnitude + " | move this frame: " + distanceThisFrame);

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        Debug.Log("Bullet hit target!");

        if (impactEffect != null)
        {
            GameObject effectIns = Instantiate(
                impactEffect,
                transform.position,
                transform.rotation
            );

            Destroy(effectIns, 2f);
        }
        else
        {
            Debug.LogWarning("Impact Effect atanmadı!");
        }

        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}