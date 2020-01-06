namespace HappyDogShow.Services.Infrastructure.Models
{
    public interface IHandlerEntryEntity : IEntityWithID
    {
        IDogShowEntity DogShow { get; set; }
        IHandlerRegistration Handler { get; set; }
        IDogRegistration Dog { get; set; }
        IHandlerClassEntity Class { get; set; }
        string Number { get; set; }
    }
}
