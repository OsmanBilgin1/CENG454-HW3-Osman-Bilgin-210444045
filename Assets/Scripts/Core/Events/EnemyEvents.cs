using System;

public static class EnemyEvents
{
    public static event Action<Enemy> OnEnemyReachedEnd;

    public static void RaiseEnemyReachedEnd(Enemy enemy)
    {
        OnEnemyReachedEnd?.Invoke(enemy);
    }
}