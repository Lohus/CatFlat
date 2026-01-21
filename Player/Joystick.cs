using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float maxMoveSpeed = 10f;     
    public float sensitivity = 0.015f;   
    public float deadZone = 20f;

    private Rigidbody2D rb;

    private Vector2 inputStartPos;
    private bool inputActive;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ProcessInput();
    }

    void ProcessInput()
    {
        if (IsInputDown())
        {
            inputStartPos = GetInputPosition();
            inputActive = true;
        }

        if (IsInputUp())
        {
            inputActive = false;
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (inputActive)
        {
            Vector2 currentPos = GetInputPosition();
            float deltaX = currentPos.x - inputStartPos.x;

            // deadzone
            if (Mathf.Abs(deltaX) < deadZone)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                return;
            }

            float direction = Mathf.Sign(deltaX);
            float intensity = Mathf.Clamp01(Mathf.Abs(deltaX) * sensitivity);

            float horizontalSpeed = intensity * maxMoveSpeed * direction;

            rb.velocity = new Vector2(horizontalSpeed, rb.velocity.y);
        }
    }

    bool IsInputDown()
    {
        return Input.GetMouseButtonDown(0)
            || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began);
    }

    bool IsInputUp()
    {
        return Input.GetMouseButtonUp(0)
            || (Input.touchCount > 0 &&
                (Input.GetTouch(0).phase == TouchPhase.Ended ||
                 Input.GetTouch(0).phase == TouchPhase.Canceled));
    }

    Vector2 GetInputPosition()
    {
        if (Input.touchCount > 0)
            return Input.GetTouch(0).position;

        return Input.mousePosition;
    }

    void LateUpdate()
    {
        WrapAround();
    }

    void WrapAround()
    {
        Vector3 pos = transform.position;

        float left = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        float right = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        if (pos.x < left)
            pos.x = right;
        else if (pos.x > right)
            pos.x = left;

        transform.position = pos;
    }
}


