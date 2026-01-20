using UnityEngine;

public class GeneratePlatform : MonoBehaviour
{
    [HideInInspector] public static GeneratePlatform instance;
    [SerializeField] GameObject[] platform;
    [SerializeField] GameBalance gameBalance;
    private float offsetX;
    private float offsetY;
    private float heightPlatform = 0;
    public int level = 1;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
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
            offsetX = gameBalance.offsetX;
            offsetY = gameBalance.offsetY; 
        }
        for (float height = offsetY; height <= transform.position.y; height += offsetY)
        {
            Instantiate(platform[0], new Vector3(Random.Range(-offsetX, offsetX), height, transform.position.z), transform.rotation);
            heightPlatform = height;
        }
    }
    void Update()
    {
        if (transform.position.y - heightPlatform >= offsetY)
        {
            heightPlatform += offsetY;
            int index = Random.Range(0, level);
            Instantiate(platform[index], new Vector3(Random.Range(-offsetX, offsetX), heightPlatform, transform.position.z), transform.rotation);
        } 
    } 
}
