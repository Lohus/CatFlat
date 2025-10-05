using UnityEngine;

public class DestroyZone : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Platform>())
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.GetComponent<Player>())
        {
            GameManager.instance.PlayerDead();
        }
    }
}