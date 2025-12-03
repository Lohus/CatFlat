using System.Threading.Tasks;
using UnityEngine;
using YG;
using YG.Utils.LB;

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
        _ = UpdateLeaderboardAsync();
    }
    public void ShowFullAds()
    {
        YG2.InterstitialAdvShow();
    }
    public async Task SaveRecordsAsync(int records)
    {
        Debug.Log("[CatFlatLog] Start save records");
        while (lBData == null)
        {
            await Task.Yield();
        }
        if (records > lBData.currentPlayer.score)
        {
            YG2.SetLeaderboard(nameLeaderboard, records);
            Debug.Log("[CatFlatLog] Records " + records + " added on leadeborad");
        }
        else
        {
            Debug.Log("[CatFlatLog] Records " + records + " small than leaderboard " + lBData.currentPlayer.score);
        }
        _ = UpdateLeaderboardAsync();
    }

    public async Task<PlayerData[]> GetLeaderboardAsync()
    {
        Debug.Log("[CatFlatLog] Gettings Players data");
        while (lBData == null)
        {
            await Task.Yield();
        }
        PlayerData[] playersLB = new PlayerData[lBData.players.Length];
        for (int i = 0; i < playersLB.Length; i++)
        {
            playersLB[i].name = lBData.players[i].name;
            playersLB[i].photo = lBData.players[i].photo;
            playersLB[i].score = lBData.players[i].score;
            playersLB[i].rank = lBData.players[i].rank;
        }
        Debug.Log("[CatFlatLog] Send Players data for " + playersLB.Length);
        return playersLB;
    }

    public async Task<PlayerData> GetPlayerDataAsync()
    {
        Debug.Log("[CatFlatLog] Gettings Player data");
        await WaitLBData();
        PlayerData player = new PlayerData();
        if (YG2.player.auth == true)
        {
            player.name = YG2.player.name;
            player.photo = YG2.player.photo;
            player.rank = lBData.currentPlayer.rank;
            player.score = lBData.currentPlayer.score;
        }
        Debug.Log("[CatFlatLog] Send Player data");
        return player;
    }

    async Task UpdateLeaderboardAsync() // Async get leaderboard data
    {
        Debug.Log("[CatFlatLog] Getting LBData");
        var taskLBData = new TaskCompletionSource<LBData>();
        YG2.onGetLeaderboard += LBDataReceived;
        YG2.GetLeaderboard(nameLeaderboard, countLeaders, 1);
        await taskLBData.Task;
        void LBDataReceived(LBData newLBData)
        {
            lBData = newLBData;
            taskLBData.SetResult(newLBData);
            YG2.onGetLeaderboard -= LBDataReceived;
            Debug.Log("[CatFlatLog] LBData is get");
        }
    }

    async Task WaitLBData()
    {
        Debug.Log("[CatFlatLog] Wait LBData");
        while(lBData == null)
        {
            await Task.Yield();
        }
        Debug.Log("[CatFlatLog] LBData exist");
    }

    public void GameReady()
    {
        YG2.GameReadyAPI();
    }
}