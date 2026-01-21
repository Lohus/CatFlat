using UnityEngine.Events;

public static class GameEvents
{
    public static UnityEvent OnPlayerDeath = new UnityEvent();
    public static UnityEvent PauseGame = new UnityEvent();
    public static UnityEvent ResumeGame = new UnityEvent();
    public static UnityEvent RewardGame = new UnityEvent();
    
}