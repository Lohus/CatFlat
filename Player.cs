
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public static Player instance;
    [SerializeField] GameBalance gameBalance;
    private Rigidbody2D rb2D;
    private SpriteRenderer sr;
    private float horizontalVelocity = 80;
    private float maxHorizontalSpeed = 3;
    private float maxVerticalSpeed = 50;
    public float velocityY;
    [SerializeField] private Sprite stay, jump;
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
        if (gameBalance == null)
        {
            Debug.LogError("Settings is not assigned in Inspector for " + gameObject.name);
            return;
        }
        else
        {
            maxVerticalSpeed = gameBalance.maxVerticalSpeed;
            horizontalVelocity = gameBalance.horizontalVelocity;
            maxHorizontalSpeed = gameBalance.maxHorizontalSpeed; 
        }
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Controll();
        ControlVerticalSpeed();
        velocityY = rb2D.velocity.y;
        EnableBoxColider();
        ChangeSpriteVertical();
        ChangeSpriteHorizontal();
    }

    void ChangeSpriteHorizontal()
    {
        if (rb2D.velocity.x < 0)
        {
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;
        }
    }
    void Controll()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb2D.AddForce(Vector2.left * horizontalVelocity * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb2D.AddForce(Vector2.right * horizontalVelocity * Time.deltaTime);
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

    void ChangeSpriteVertical()
    {
        if (velocityY > 0)
        {
            sr.sprite = jump;
        }
        else
        {
            sr.sprite = stay;
        }
    }
     void ControlVerticalSpeed()
    {
        if (rb2D.velocity.y <= -maxVerticalSpeed)
        {
            Debug.Log("MaxSpeed");
            rb2D.velocity = new Vector2(rb2D.velocity.x, -maxVerticalSpeed);
        }
    }        
}
