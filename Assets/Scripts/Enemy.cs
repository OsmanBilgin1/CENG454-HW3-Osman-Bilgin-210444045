using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private IEnemyMovementStrategy movementStrategy;

    private void Awake()
    {
        movementStrategy = GetComponent<IEnemyMovementStrategy>();
    }

    private void OnEnable()
    {
        movementStrategy?.Initialize(transform);
    }

    private void Update()
    {
        if (movementStrategy == null)
        {
            return;
        }

        bool reachedEnd = movementStrategy.Move(transform, speed);

        if (reachedEnd)
        {
            EnemyEvents.RaiseEnemyReachedEnd(this);
            gameObject.SetActive(false);
        }
    }

    public void ResetEnemy()
    {
        movementStrategy?.ResetMovement();
    }
}