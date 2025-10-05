using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    private float speed = 1f;
    private float borderX = 2.2f;
    private Vector3 startPos;
    private float offsetX;
    void Start()
    {
        offsetX = transform.position.x;
        startPos = new Vector3(0, transform.position.y, 0);
    }
    void Update()
    {
        float offset = Mathf.Sin(Time.time + offsetX) * borderX;
        transform.position = startPos + new Vector3(offset, 0, 0);
    }
}