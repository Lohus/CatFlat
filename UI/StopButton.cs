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
        stop.onClick.AddListener(PauseResumeAction);
    }

    public void OnEnable()
    {
        GameEvents.PauseGame.AddListener(PauseGame);
        GameEvents.ResumeGame.AddListener(ResumeGame);
    }
    public void OnDisable()
    {
        GameEvents.PauseGame.RemoveListener(PauseGame);
        GameEvents.ResumeGame.RemoveListener(ResumeGame);
        stop.onClick.RemoveListener(PauseResumeAction);
    }

    void PauseGame()
    {
        gameObject.SetActive(true);
        imageButton.sprite = resumeGame;
    }
    void ResumeGame()
    {
        imageButton.sprite = pauseGame;
    }
    void PauseResumeAction()
    {
        if (!pause)
        {
            GameEvents.PauseGame?.Invoke();
            pause = true;
        }
        else
        {
            GameEvents.ResumeGame?.Invoke();
            pause = false;
        }
    }

}