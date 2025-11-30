using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager instance;
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

    void UpScore()
    {
        int _score = Mathf.RoundToInt(playerTr.position.y * 10);
        if (_score > score)
        {
            score = _score;
        }
    }
    public void PlayerDead()
    {
        _ = PYG2.instance.SaveRecordsAsync(score);
        Time.timeScale = 0;
        menuPanel.SetActive(true);
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
