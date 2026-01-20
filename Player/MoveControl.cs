using UnityEngine;

public class MoveControl : MonoBehaviour
{
    [SerializeField] private float offsetY = 0; // Offset from player
    private Transform playerTr;
    void Start()
    {
        playerTr = Player.instance.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (playerTr.position.y > (transform.position.y - offsetY))
        {
            transform.position = new Vector3(transform.position.x, playerTr.position.y + offsetY, transform.position.z);
        }
    }
}
