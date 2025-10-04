using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (other.gameObject.GetComponent<Platform>())
        {
            Destroy(other.gameObject);
        }
    }
}