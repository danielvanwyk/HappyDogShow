namespace HappyDogShow.Services.Infrastructure.Models
{
    public interface IClubEntity : IEntityWithID
    {
        string Name { get; set; }
    }
}
