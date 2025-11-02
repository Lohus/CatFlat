using System.Collections;
using TMPro;
using UnityEngine;

public class PawGenerator : MonoBehaviour
{
    [SerializeField] GameObject paw;
    [SerializeField] GameBalance settings;
    void Start()
    {
        StartCoroutine(GenPaws());
    }
    public IEnumerator GenPaws()
    {
        while(true)
        {
            Instantiate(paw, new Vector3(Random.Range(-settings.offsetX, settings.offsetX), transform.position.y, transform.position.z), transform.rotation);
            yield return new WaitForSeconds(0.5f);
        }
    }
}