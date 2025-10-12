using UnityEngine;

public class PlatformBreakable : MonoBehaviour, IPlatfromEffect
{
    public void ApplyEffect(Collision2D collision)
    {
        DestroyPlatfrom();
    }

    void DestroyPlatfrom()
    {
        //gameObject.GetComponent<BoxCollider2D>().enabled = false;
        foreach (Transform child in transform)
        {
            child.gameObject.AddComponent<BoxCollider2D>().isTrigger = true;
            Rigidbody2D rb = child.gameObject.AddComponent<Rigidbody2D>();
            rb.gravityScale = Random.Range(1, 3);
            child.SetParent(null);
        }
        gameObject.AddComponent<Rigidbody2D>().gravityScale = Random.Range(1, 3);
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }
}