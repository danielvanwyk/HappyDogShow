using HappyDogShow.Services.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.SharedModels
{
    public class JudgeAssignmentInformation : IJudgeAssignmentInformation
    {
        public string JudgeName { get; set; }
        public string AssignedTo { get; set; }
    }
}
