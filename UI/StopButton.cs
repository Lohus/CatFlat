using UnityEngine;
using UnityEngine.UI;

public class StopButton: MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    [SerializeField] Sprite pauseGame, resumeGame;
    private Button stop;
    private Image imageButton;
    private bool pause = false;
    void Awake()
    {
        stop = gameObject.GetComponent<Button>();
        imageButton = gameObject.GetComponent<Image>();
        stop.onClick.AddListener(() => GameEvents.PauseGame?.Invoke());
    }

    public void OnEnable()
    {
        GameEvents.PauseGame.AddListener();
    }
    public void OnDisable()
    {
        GameEvents.PauseGame.RemoveListener();
        stop.onClick.RemoveListener(() => GameEvents.PauseGame?.Invoke());
    }

    void PauseGame()
    {
        imageButton.sprite = resumeGame;
    }
    void PauseGame()
    {
        if (!pause)
        {
            Time.timeScale = 0;
            menuPanel.SetActive(true);
            gameObject.SetActive(true);
            imageButton.sprite = resumeGame;
            pause = true;
        }
        else
        {
            menuPanel.SetActive(false);
            Time.timeScale = 1;
            imageButton.sprite = pauseGame;
            pause = false;
        }
    }

}