using HappyDogShow.Services.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Services
{
    public interface IJudgesService
    {
        Task<List<IJudgeAssignmentInformation>> GetListOfAllTheJudgesForShowAsync<T>(int dogShowId) where T : IJudgeAssignmentInformation, new();
    }
}
