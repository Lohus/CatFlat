using UnityEngine;
using UnityEngine.UIElements;

public class GeneratePlatform : MonoBehaviour
{
    [SerializeField] GameObject platform;
    private float offsetX = 2.2f; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exit" + other.name);
        if (other.gameObject.GetComponent<Platform>())
        {
            Debug.Log("Instantiate");
            Instantiate(platform, new Vector3(Random.Range(-offsetX, offsetX), transform.position.y, transform.position.z), transform.rotation);
        }
    }
}
