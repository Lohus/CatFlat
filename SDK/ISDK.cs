using System.Threading.Tasks;

public interface ISDK
{
    public void ShowFullAds(); // Full-screen ADS
    public void GameReady();
    public Task SaveRecordsAsync(int records); // Save records on platforms
    public Task<PlayerData[]> GetLeaderboardAsync();
    public Task<PlayerData> GetPlayerDataAsync();

}