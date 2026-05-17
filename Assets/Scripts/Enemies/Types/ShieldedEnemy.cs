using UnityEngine;
 
public class ShieldedEnemy : Enemy
{
    [Header("Armor")]
    public float armorReduction = 0.5f;
 
    protected override void OnAwake()
    {
        moveSpeed = 5f;
        baseHealth = 200f;
    }
 
 
    protected override float ChangeIncomingDamage(float damage)
{
    return damage * armorReduction;
}
}