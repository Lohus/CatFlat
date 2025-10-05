using System;
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

    // Update is called once per frame
    void Update()
    {
        UpScore();
        scoreTx.text = "Score: " + score;
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
        Time.timeScale = 0;
        menuPanel.SetActive(true);
    }
}
