
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button playButton, leaderboardButton, menuButton;
    [SerializeField] GameObject mainMenu, leaderboard;
    [SerializeField] TextMeshProUGUI score;

    void Start()
    {
        playButton.onClick.AddListener(LoadScene);
        leaderboardButton.onClick.AddListener(OpenLeaderBoard);
        menuButton.onClick.AddListener(OpenMainMenu);
        PYG2.instance.GameReady(); // YG API load
    }
    void LoadScene()
    {
        PYG2.instance.ShowFullAds();
        SceneManager.LoadScene("GameScene");
    }
    void OpenLeaderBoard()
    {
        PYG2.instance.ShowFullAds();
        mainMenu.SetActive(false);
        leaderboard.SetActive(true);
    }
    void OpenMainMenu()
    {
        leaderboard.SetActive(false);
        mainMenu.SetActive(true);
    }

}
