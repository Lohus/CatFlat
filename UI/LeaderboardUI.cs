using UnityEngine;

public class LeaderboardUI : MonoBehaviour
{
    [SerializeField] LBPlayerUI[] panels;

    public async void OnEnable()
    {
        Debug.Log("[CatFlatLog] Show leaderboard UI");
        PlayerData player = await PYG2.instance.GetPlayerDataAsync();
        if (player.name != "unauthorized")
        {
            if(player.rank > 3)
            {
                panels[3].gameObject.SetActive(true);
                panels[3].SetPlayerData(player.name, player.score, player.photo);
            }
        }
        PlayerData[] players = await PYG2.instance.GetLeaderboardAsync();
        for (int i = 0; i < players.Length; i++)
        {
            panels[i].gameObject.SetActive(true);
            panels[i].SetPlayerData(players[i].name, players[i].score, players[i].photo);
        }
    }
    public void OnDisable()
    {
        for (int i = 0; i < panels.Length; i++)
        {
            if (panels[i].isActiveAndEnabled)
            {
                panels[i].gameObject.SetActive(false);
            }
        }
    }
}