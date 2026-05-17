using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public float speed = 10f;
    public float maxHealth = 100f;
    private float currentHealth;
    private bool isDead = false;
    
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
        if (movementStrategy == null || isDead)
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

    public void TakeDamage(float amount)
    {
        if (isDead)
        {
            return;
        }
        currentHealth -= amount;
        
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        EnemyEvents.RaiseEnemyDied(this);
        gameObject.SetActive(false);
    }

    public void ResetEnemy()
    {
        currentHealth = maxHealth;
        isDead = false;
        movementStrategy?.ResetMovement();

    }
}