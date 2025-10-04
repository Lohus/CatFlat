using UnityEngine;

public class Border : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.position *= new Vector2(-1, 1);
        }
    }
}
