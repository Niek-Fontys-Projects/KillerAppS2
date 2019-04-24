namespace ModelLayer.General_Interfaces
{
    public interface IRating
    {
        string UserName { get; }
        string RiddleName { get; }
        int Score { get; }
    }
}
