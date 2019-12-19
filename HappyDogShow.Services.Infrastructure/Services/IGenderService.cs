using HappyDogShow.Services.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Services
{
    public interface IGenderService
    {
        Task<List<IGenderEntity>> GetListAsync<T>() where T : IGenderEntity, new();
    }
}
