using System.Threading.Tasks;
using HappyDogShow.Services.Infrastructure.Models;

namespace HappyDogShow.Services.Infrastructure.Services
{
    public interface IEntityUpdateService<U>
        where U : class, IEntityWithID
    {
        Task UpdateEntityAsync(U entity);
    }
}
