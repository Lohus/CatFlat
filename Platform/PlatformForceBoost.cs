using UnityEngine;

public class PlatformForceBoost : MonoBehaviour, IPlatfromEffect
{
    private float force = 500;
    public void ApplyEffect(Collision2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * force);
    }
}