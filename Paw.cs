using System.Collections;
using UnityEngine;

public class Paw : MonoBehaviour
{
    private Rigidbody2D rb2D;

    void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rb2D.velocity = new Vector3(0, -2, 0);
        rb2D.angularVelocity = Random.Range(-30, 30);
    }
}