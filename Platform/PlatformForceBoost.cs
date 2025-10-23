using UnityEngine;

public class PlatformForceBoost : MonoBehaviour, IPlatfromEffect
{
    [SerializeField] GameBalance gameBalance;
    private float force;
    void Start()
    {
        if (gameBalance == null)
        {
            Debug.LogError("Settings is not assigned in Inspector for " + gameObject.name);
            return;
        }
        else
        {
            force = gameBalance.greatForce; 
        }
    }
    public void ApplyEffect(Collision2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * force);
    }
}