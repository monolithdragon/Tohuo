using System;

public class GameEvents : Singleton<GameEvents>
{
    public event Action OnFireEvent = delegate { };
    public event Action OnStopFireEvent = delegate { };

    public void Fire()
    {
        OnFireEvent?.Invoke();
    }

    public void StopFire()
    {
        OnStopFireEvent?.Invoke();
    }
}
