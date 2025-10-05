using UnityEngine;

public class PlatformBreakable : MonoBehaviour, IPlatfromEffect
{
    public void ApplyEffect(Collision2D collision)
    {
        Destroy(gameObject);
    }
}