using UnityEngine;
using System.Collections.Generic;

public interface ITargetingStrategy
{
    Transform FindTarget(Vector3 turretPosition, float range, IReadOnlyList<Enemy> activeEnemies);
}
