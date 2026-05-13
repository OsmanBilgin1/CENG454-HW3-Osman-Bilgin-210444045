using UnityEngine;

public class WaypointMovementStrategy : MonoBehaviour, IEnemyMovementStrategy
{
    private Transform target;
    private int waypointIndex = 0;

    public void Initialize(Transform enemyTransform)
    {
        ResetMovement();

        if (Waypoints.points != null && Waypoints.points.Length > 0)
        {
            target = Waypoints.points[0];
        }
    }

    public bool Move(Transform enemyTransform, float speed)
    {
        if (target == null)
        {
            return true;
        }

        Vector3 dir = target.position - enemyTransform.position;
        enemyTransform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(enemyTransform.position, target.position) <= 0.4f)
        {
            return GetNextWaypoint();
        }

        return false;
    }

    private bool GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            return true;
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
        return false;
    }

    public void ResetMovement()
    {
        waypointIndex = 0;
        target = null;
    }
}