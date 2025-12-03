using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] Button replay, home;
    void Start()
    {
        replay.onClick.AddListener(() => LoadScene("GameScene"));
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
}
