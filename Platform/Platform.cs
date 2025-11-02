using System.Numerics;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] GameObject stepParticle;
    private Transform playerTr;
    void Start()
    {
        if (Player.instance != null)
        {
            playerTr = Player.instance.transform;
        }
        else
        {
            Debug.Log("Player is not exist");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.contacts[0];
        if (collision.gameObject.GetComponent<Player>() && CheckHeight(collision.transform, transform) && contact.normal.y == - 1f && Player.instance.velocityY <= 0)
        {
            Instantiate(stepParticle, gameObject.transform.position, transform.rotation);
            foreach (IPlatfromEffect effect in GetComponents<IPlatfromEffect>())
            {
                effect.ApplyEffect(collision);
            }
        }
    }

    bool CheckHeight(Transform player, Transform platform)
    {
        if ((player.position - platform.position).y > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}