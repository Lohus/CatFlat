
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button playButton, leaderboardButton, menuButton;
    [SerializeField] GameObject mainMenu, leaderboard;

    void Start()
    {
        playButton.onClick.AddListener(LoadScene);
        leaderboardButton.onClick.AddListener(OpenLeaderBoard);
        menuButton.onClick.AddListener(OpenMainMenu);
    }
    void LoadScene()
    {
        SceneManager.LoadScene("GameScene");
    }
    void OpenLeaderBoard()
    {
        mainMenu.SetActive(false);
        leaderboard.SetActive(true);
    }
    void OpenMainMenu()
    {
        leaderboard.SetActive(false);
        mainMenu.SetActive(true);
    }
}
