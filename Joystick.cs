using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    public float moveSpeed = 5f; // скорость движения игрока
    private Rigidbody2D rb;

    private Vector2 startTouchPos;   // точка начала касания
    private bool isTouching;         // касание активно

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        // === ПК (мышь) ===
        if (Input.GetMouseButtonDown(0))
        {
            startTouchPos = Input.mousePosition;
            isTouching = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isTouching = false;
            rb.velocity = new Vector2(0, rb.velocity.y); // остановить горизонтальное движение
        }

        // === Телефон (тач) ===
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouchPos = touch.position;
                    isTouching = true;
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    isTouching = false;
                    rb.velocity = new Vector2(0, rb.velocity.y);
                    break;
            }
        }

        // === Обработка движения ===
        if (isTouching)
        {
            Vector2 currentPos = Input.touchCount > 0 ? (Vector2)Input.GetTouch(0).position : (Vector2)Input.mousePosition;
            float deltaX = currentPos.x - startTouchPos.x;

            // Если движение заметное, то задаем направление
            float direction = Mathf.Sign(deltaX);
            float absDelta = Mathf.Abs(deltaX);

            if (absDelta > 10f) // минимальный порог движения
            {
                rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
    }
}

