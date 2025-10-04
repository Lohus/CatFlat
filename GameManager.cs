using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTx;
    Transform playerTr;
    private int score = 0;
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
}
