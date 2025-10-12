using UnityEngine;

public class PlatformBoost : MonoBehaviour, IPlatfromEffect
{
    private float force = 300;
    public void ApplyEffect(Collision2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * force);
        Debug.Log("Add Force: " + force);
    }
}