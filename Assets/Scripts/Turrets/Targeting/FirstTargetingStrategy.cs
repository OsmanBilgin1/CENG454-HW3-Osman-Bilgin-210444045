using UnityEngine;
using System.Collections.Generic;

public class FirstTargetingStrategy : MonoBehaviour, ITargetingStrategy
{
    public Transform FindTarget(Vector3 turretPosition, float range, IReadOnlyList<Enemy> activeEnemies)
    {
        Transform firstEnemy = null;
        float furthestDistanceTraveled = -1f;

        foreach (Enemy enemy in activeEnemies)
        {
            if (enemy == null || !enemy.gameObject.activeInHierarchy) continue;

            float distanceToTurret = Vector3.Distance(turretPosition, enemy.transform.position);
            if (distanceToTurret > range) continue;

            
            Transform finalWaypoint = Waypoints.points[Waypoints.points.Length - 1];
            float distanceToEnd = Vector3.Distance(enemy.transform.position, finalWaypoint.position);

            
            if (furthestDistanceTraveled == -1f || distanceToEnd < furthestDistanceTraveled)
            {
                furthestDistanceTraveled = distanceToEnd;
                firstEnemy = enemy.transform;
            }
        }

        return firstEnemy;
    }
}