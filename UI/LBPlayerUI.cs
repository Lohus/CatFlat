using TMPro;
using UnityEngine;
using YG;

public class LBPlayerUI : MonoBehaviour
{
    [SerializeField] ImageLoadYG imageLoadYG;
    [SerializeField] TextMeshProUGUI playerName, playerScore;
    public void SetPlayerData(string name, int score, string photoURL)
    {
        imageLoadYG.Load(photoURL);
        playerName.text = name;
        playerScore.text = score.ToString();
    }
}