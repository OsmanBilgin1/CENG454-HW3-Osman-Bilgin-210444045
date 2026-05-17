using UnityEngine;
public class MiniEnemy : Enemy
{
    [Header("Lightweight Stats")]
    public float speedMultiplier = 1.5f;
    public float damageMultiplier = 1.25f;
 
    protected override void OnAwake()
    {
        moveSpeed *= speedMultiplier;
        baseHealth = 60f;
    }
 
    protected override float ChangeIncomingDamage(float damage)
    {
        return damage * damageMultiplier;
    }
 
 
}