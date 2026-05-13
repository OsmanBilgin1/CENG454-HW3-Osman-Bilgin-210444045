using System;

public static class WaveEvents
{
    public static event Action<float> OnCountdownChanged;
    public static event Action<int> OnWaveStarted;
    public static event Action<Enemy> OnEnemySpawned;

    public static void RaiseCountdownChanged(float countdown)
    {
        OnCountdownChanged?.Invoke(countdown);
    }

    public static void RaiseWaveStarted(int waveIndex)
    {
        OnWaveStarted?.Invoke(waveIndex);
    }

    public static void RaiseEnemySpawned(Enemy enemy)
    {
        OnEnemySpawned?.Invoke(enemy);
    }
}