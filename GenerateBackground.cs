using UnityEngine;

public class GenerateBackground : MonoBehaviour
{
    void Update()
    {
        if (gameObject.transform.position.y <= Player.instance.transform.position.y)
        {
            gameObject.transform.position = gameObject.transform.position + new Vector3(0, 5, 0);
        } 
    }
}
