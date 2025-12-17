using UnityEngine;

public class DestroyZone : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Platform>() || other.CompareTag("Platform"))
        {
            Destroy(other.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            GameEvents.OnPlayerDeath?.Invoke();
            GameEvents.PauseGame?.Invoke();
        }
    }
}