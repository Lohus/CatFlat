public struct PlayerData
{
    public string name;
    public string photo;
    public int score;
    public int rank;
    public readonly bool IsNull()
    {
        return string.IsNullOrEmpty(name) && 
               string.IsNullOrEmpty(photo) && 
               rank == 0 && 
               score == 0;
    }
}