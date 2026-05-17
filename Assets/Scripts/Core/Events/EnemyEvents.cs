using System;

public static class EnemyEvents
{
    public static event Action<Enemy> OnEnemyReachedEnd;
    public static event Action<Enemy> OnEnemyDied;

    public static void RaiseEnemyReachedEnd(Enemy enemy)
    {
        OnEnemyReachedEnd?.Invoke(enemy);
    }

    public static void RaiseEnemyDied(Enemy enemy)
    {
        OnEnemyDied?.Invoke(enemy);
    }
}