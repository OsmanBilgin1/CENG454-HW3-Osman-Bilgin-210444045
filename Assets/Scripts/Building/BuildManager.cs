using UnityEngine;

public class BuildManager : MonoBehaviour 
{
    public static BuildManager instance;

    public GameObject standardTurretPrefab;
    [SerializeField] private BulletPool bulletPool;

    private GameObject turretToBuild;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    void Start()
    {
        turretToBuild = standardTurretPrefab;
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public GameObject BuildTurret(Vector3 position, Quaternion rotation)
    {
        GameObject turretGO = Instantiate(turretToBuild, position, rotation);

        Turret turret = turretGO.GetComponent<Turret>();
        if (turret != null)
        {
            turret.SetBulletPool(bulletPool);
        }

        return turretGO;
    }
}