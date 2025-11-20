using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.TextCore.Text;
using YG;
using YG.Utils.LB;

public struct PlayerData
{
    public string name;
    public string photo;
    public int score;
    public int rank;
}

public class PYG2 : MonoBehaviour, ISDK
{
    public static PYG2 instance;
    private string nameLeaderboard = "MaxScore";
    private int countLeaders = 3;
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
        YG2.GetLeaderboard(nameLeaderboard, countLeaders, 1);
    }
    public void AwakeInterstitialAds()
    {
        // Нписать реализцию позже
    }
    public async Task SaveRecordsAsync(int records)
    {
        while (lBData == null)
        {
            await Task.Yield();
        }
        if (records > lBData.currentPlayer.score)
        {
            YG2.SetLeaderboard(nameLeaderboard, records);
        }
        UpdateLeaderboardAsync();
    }

    public async Task<PlayerData[]> ShowLeaderboard()
    {
        while (lBData == null)
        {
            await Task.Yield();
        }
        PlayerData[] playersLB = new PlayerData[countLeaders];
        for (int i = 0; i < playersLB.Length; i++)
        {
            playersLB[i].name = lBData.players[i].name;
            playersLB[i].photo = lBData.players[i].photo;
            playersLB[i].score = lBData.players[i].score;
            playersLB[i].rank = lBData.players[i].rank;
        }
        return playersLB;
    }

    async Task UpdateLeaderboardAsync() // Async get leaderboard data
    {
        var taskLBData = new TaskCompletionSource<LBData>();
        YG2.onGetLeaderboard += LBDataReceived;
        YG2.GetLeaderboard(nameLeaderboard, countLeaders, 1);
        await taskLBData.Task;
        void LBDataReceived(LBData newLBData)
        {
            lBData = newLBData;
            taskLBData.SetResult(newLBData);
            YG2.onGetLeaderboard -= LBDataReceived;
        }
    }
}