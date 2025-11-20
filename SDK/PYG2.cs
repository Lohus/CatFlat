using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.TextCore.Text;
using YG;
using YG.Utils.LB;

public class PYG2 : MonoBehaviour, ISDK
{
    public static PYG2 instance;
    private string nameLeaderboard = "MaxScore";
    private LBData lBData;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        YG2.GetLeaderboard(nameLeaderboard, 3, 1);
    }
    public void AwakeInterstitialAds()
    {
        // Нписать реализцию позже
    }
    public void SaveRecords(int records)
    {
        if (lBData != null)
        {
            if (records > lBData.currentPlayer.score) YG2.SetLeaderboard(nameLeaderboard, records);
        }
    }

    public PlayerData[] ShowLeaderboard()
    {
        if (lBData == null)
        {
            Debug.Log("LBData is null");
        }
        PlayerData[] playersLB = new PlayerData[3];
        for (int i = 0; i < playersLB.Length; i++)
        {
            playersLB[i].name = lBData.players[i].name;
            playersLB[i].photo = lBData.players[i].photo;
            playersLB[i].score = lBData.players[i].score;
            playersLB[i].rank = lBData.players[i].rank;
        }
        return playersLB;
    }

    async Task UpdateLeaderboardAsync()
    {
        var taskLBData = new TaskCompletionSource<LBData>();
        YG2.onGetLeaderboard += LBDataReceived;
        YG2.GetLeaderboard(nameLeaderboard, 3, 1);
        await taskLBData.Task;
        void LBDataReceived(LBData newLBData)
        {
            lBData = newLBData;
            taskLBData.SetResult(newLBData);
            YG2.onGetLeaderboard -= LBDataReceived;
        }
    }

}

public struct PlayerData
{
    public string name;
    public string photo;
    public int score;
    public int rank;
}