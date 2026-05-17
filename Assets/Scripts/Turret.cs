using UnityEngine;

public class Turret : MonoBehaviour {

	private Transform target;

    [Header("Attributes")]
	public float range = 15f;
    public float fireRate = 1f;
    private float fireCountDown = 0f;

    [Header("Unity Setup Fields")]
	public string enemyTag = "Enemy";

	public Transform partToRotate;
	public float turnSpeed = 10f;

    [SerializeField] private BulletPool bulletPool;
    public Transform firePoint;

	private ITargetingStrategy targetingStrategy;

    void Awake()
    {
        targetingStrategy = GetComponent<ITargetingStrategy>();
    }


    // Use this for initialization
    void Start () {
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}
	
	void UpdateTarget ()
	{
		if (targetingStrategy == null)
		{
			target = null;
			return;
		}

		GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag(enemyTag);
		var enemies = new System.Collections.Generic.List<Enemy>();
		foreach (var go in enemyObjects)
		{
			var enemy = go.GetComponent<Enemy>();
            if (enemy != null) enemies.Add(enemy);
		}

		target = targetingStrategy.FindTarget(transform.position, range, enemies);
	}

	// Update is called once per frame
	void Update () {
		if (target == null)
		{
			return;
		}

		if (!target.gameObject.activeInHierarchy)
		{
			target = null;
			return;
		}
		//Target lock on
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);

        if (fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;

        }

        fireCountDown -= Time.deltaTime;

	}

    void Shoot()
	{
		Bullet bullet = bulletPool.GetBullet(firePoint.position, firePoint.rotation);
    	bullet.Seek(target);
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}
}