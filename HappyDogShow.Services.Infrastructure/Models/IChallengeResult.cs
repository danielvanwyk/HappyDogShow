namespace HappyDogShow.Services.Infrastructure.Models
{
    public interface IChallengeResult : IEntityWithID
    {
        string Challenge { get; set; }
        string Placing { get; set; }
        string EntryNumber { get; set; }
        bool Print { get; set; }
        int ShowId { get; set; }
        int JudgingOrder { get; set; }
        string ShowName { get; set; }
    }
}
