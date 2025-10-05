using UnityEngine;

public class GeneratePlatform : MonoBehaviour
{
    [SerializeField] GameObject[] platform;
    private float offsetX = 2.2f;
    private float offsetY = 0.4f;
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exit" + other.name);
        if (other.gameObject.GetComponent<Platform>())
        {
            Debug.Log("Instantiate");
            int index = Random.Range(0, platform.Length);
            Instantiate(platform[index], new Vector3(Random.Range(-offsetX, offsetX), transform.position.y - offsetY, transform.position.z), transform.rotation);
        }
    }
}
