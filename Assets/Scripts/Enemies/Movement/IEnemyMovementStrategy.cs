using UnityEngine;

public interface IEnemyMovementStrategy
{
    void Initialize(Transform enemyTransform);
    bool Move(Transform enemyTransform, float speed);
    void ResetMovement();
}