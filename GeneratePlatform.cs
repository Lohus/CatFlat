using UnityEngine;

public class GeneratePlatform : MonoBehaviour
{
    [SerializeField] GameObject[] platform;
    private float offsetX = 2.2f;
    private float offsetY = 0.35f;

    void Start()
    {
        for (float height = (1 - offsetY); height <= 10.5; height += (1 - offsetY))
        {
            Instantiate(platform[0], new Vector3(Random.Range(-offsetX, offsetX), height, transform.position.z), transform.rotation);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (!Application.isPlaying) return;
        Debug.Log("Exit" + other.name);
        if (other.gameObject.GetComponent<Platform>())
        {
            Debug.Log("Instantiate");
            int index = Random.Range(0, platform.Length);
            Instantiate(platform[index], new Vector3(Random.Range(-offsetX, offsetX), transform.position.y - offsetY, transform.position.z), transform.rotation);
        }
    }
}
