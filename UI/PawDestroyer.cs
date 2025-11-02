using System.Collections;
using UnityEngine;

public class PawDestroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}