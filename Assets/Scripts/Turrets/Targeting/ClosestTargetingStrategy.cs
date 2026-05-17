using UnityEngine;
using System.Collections.Generic;

public class ClosestTargetingStrategy : MonoBehaviour, ITargetingStrategy
{
    public Transform FindTarget(Vector3 turretPosition, float range, IReadOnlyList<Enemy> activeEnemies)
    {
        Transform nearest = null;
        float shortestDistance = Mathf.Infinity;

        foreach (Enemy enemy in activeEnemies)
        {
            if (enemy == null || !enemy.gameObject.activeInHierarchy) continue;

            float distance = Vector3.Distance(turretPosition, enemy.transform.position);

            if (distance < shortestDistance && distance <= range)
            {
                shortestDistance = distance;
                nearest = enemy.transform;
            }
        }

        return nearest;
    }
}