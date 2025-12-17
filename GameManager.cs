using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager instance;
    [SerializeField] Button stopButton;
    [SerializeField] TextMeshProUGUI scoreTx;
    [SerializeField] GameObject menuPanel;
    Transform playerTr;
    private int score = 0;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        playerTr = Player.instance.transform;
    }

    void Update()
    {
        UpScore();
        scoreTx.text = score.ToString();
        UPLevel();
    }

    public void OnEnable()
    {
        GameEvents.OnPlayerDeath.AddListener(PlayerDead);
        GameEvents.PauseGame.AddListener(PauseGame);
    }
    public void OnDisable()
    {
       GameEvents.OnPlayerDeath.RemoveListener(PlayerDead);
       GameEvents.PauseGame.RemoveListener(PauseGame); 
    }

    void UpScore()
    {
        int _score = Mathf.RoundToInt(playerTr.position.y * 10);
        if (_score > score)
        {
            score = _score;
        }
    }
    void PlayerDead()
    {
        _ = PYG2.instance.SaveRecordsAsync(score);
    }
    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void UPLevel()
    {
        int level = GeneratePlatform.instance.level;
        if (score > 100 && level == 1)
        {
            GeneratePlatform.instance.level += 1;
        }
        else if (score > 200 && level == 2)
        {
            GeneratePlatform.instance.level += 1;
        }
        else if (score > 300 && level == 3)
        {
            GeneratePlatform.instance.level += 1;
        }
    }
}
