
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public static Player instance;
    private Rigidbody2D rb2D;
    private SpriteRenderer sr;
    private float velocity = 80;
    private float maxHorizontalSpeed = 3;
    public float velocityY;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        FlipSprite();
        Controll();
        velocityY = rb2D.velocity.y;
        EnableBoxColider();
    }

    void FlipSprite()
    {
        if (transform.position.x < 0)
        {
            sr.flipX = true;
            //transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f);
        }
        else
        {
            sr.flipX = false;
            //transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }
    }
    void Controll()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb2D.AddForce(Vector2.left * velocity * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb2D.AddForce(Vector2.right * velocity * Time.fixedDeltaTime);
        }
        if (Mathf.Abs(rb2D.velocity.x) > maxHorizontalSpeed)
        {
            rb2D.velocity = new Vector2(Mathf.Sign(rb2D.velocity.x) * maxHorizontalSpeed, rb2D.velocity.y);
        }
    }
    void EnableBoxColider()
    {
        if (velocityY < 0)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
        else
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}
