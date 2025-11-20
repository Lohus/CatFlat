using UnityEditor.Experimental.RestService;
using UnityEngine;

public interface ISDK
{
    public void AwakeInterstitialAds(); // Full-screen ADS
    public void SaveRecords(int records); // Save records on platforms
    public PlayerData[] ShowLeaderboard();

}