using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    [SerializeField] GameBalance gameBalance;
    private float speed;
    private float borderX;
    private Vector3 startPos;
    private float offsetX;
    void Start()
    {
        if (gameBalance == null)
        {
            Debug.LogError("Settings is not assigned in Inspector for " + gameObject.name);
            return;
        }
        else
        {
            speed = gameBalance.speedPlatform;
            borderX = gameBalance.offsetX; 
        }
        offsetX = transform.position.x;
        startPos = new Vector3(0, transform.position.y, 0);
    }
    void Update()
    {
        float offset = Mathf.Sin(Time.time + offsetX) * borderX;
        transform.position = startPos + new Vector3(offset * speed, 0, 0);
    }
}