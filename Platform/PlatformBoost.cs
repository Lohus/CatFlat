using UnityEngine;

public class PlatformBoost : MonoBehaviour, IPlatfromEffect
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
            force = gameBalance.baseForce; 
        }
    }
    public void ApplyEffect(Collision2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * force);
        Debug.Log("Add Force: " + force);
    }
}