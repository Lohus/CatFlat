using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] Button replay, home, rewarded;
    void Start()
    {
        //replay.onClick.AddListener(() => LoadScene("GameScene"));
        replay.onClick.AddListener(() => RewardedButton());
        home.onClick.AddListener(() => LoadScene("MainMenu"));

        void LoadScene(string nameScene)
        {
            PYG2.instance.ShowFullAds();
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
            SceneManager.LoadScene(nameScene);
        }
    }

    void RewardedButton()
    {
        GameObject[] platforms =  GameObject.FindGameObjectsWithTag("Platform");
        GameObject lowestPlatform = null;
        float lowestY = Mathf.Infinity;
        foreach (GameObject platform in platforms)
        {
            float currentY = platform.transform.position.y;
            if (currentY < lowestY)
            {
                lowestY = currentY;
                lowestPlatform = platform;
            }
        }
        Player.instance.transform.position = lowestPlatform.transform.position + new UnityEngine.Vector3(0, 1, 0);
    }
}
