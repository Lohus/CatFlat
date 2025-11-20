using UnityEditor.Experimental.RestService;
using UnityEngine;

public interface ISDK
{
    public void AwakeInterstitialAds(); // Full-screen ADS
    public Task SaveRecordsAsync(int records); // Save records on platforms
    public Task<PlayerData[]> ShowLeaderboardAsync();
    public Task<PlayerData> ShowPlayerDataAsync();

}