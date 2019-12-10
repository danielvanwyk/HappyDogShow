namespace HappyDogShow.Infrastructure.Models
{
    public interface IDirtyAwareEntity
    {
        bool IsDirty { get; set; }
        void MarkEntityAsClean();
    }
}
