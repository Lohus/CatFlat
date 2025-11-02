
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button play;

    void Start()
    {
        play.onClick.AddListener(LoadScene);
    }
    void LoadScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
