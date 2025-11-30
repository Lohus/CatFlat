using System.Threading.Tasks;

public interface ISDK
{
    public void AwakeInterstitialAds(); // Full-screen ADS
    public Task SaveRecordsAsync(int records); // Save records on platforms
    public Task<PlayerData[]> GetLeaderboardAsync();
    public Task<PlayerData> GetPlayerDataAsync();

}