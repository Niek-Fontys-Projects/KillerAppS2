namespace ModelLayer.General_Interfaces
{
    public interface IAnswerSuggestion
    {
        string UserName { get; }
        string RiddleName { get; }
        string Answer { get; }
    }
}
