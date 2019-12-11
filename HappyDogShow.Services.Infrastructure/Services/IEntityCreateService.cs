using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyDogShow.Services.Infrastructure.Models;

namespace HappyDogShow.Services.Infrastructure.Services
{
    public interface IEntityCreateService<U>
        where U : class, IEntityWithID
    {
        Task<int> CreateEntityAsync(U entity) ;
    }
}
