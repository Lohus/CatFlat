using UnityEngine;
using UnityEngine.UI;

public class StopButton: MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    private Button stop;
    private bool pause = false;
    void Awake()
    {
        stop = gameObject.GetComponent<Button>();
        stop.onClick.AddListener(PauseGame);
    }
    void PauseGame()
    {
        if (!pause)
        {
            Time.timeScale = 0;
            menuPanel.SetActive(true);
            gameObject.SetActive(true);
            pause = true;
        }
        else
        {
            menuPanel.SetActive(false);
            Time.timeScale = 1;
            pause = false;
        }
    }
}