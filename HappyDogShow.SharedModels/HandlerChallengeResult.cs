using HappyDogShow.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.SharedModels
{
    public class HandlerChallengeResult : ValidatableBindableBase, IChallengeResult
    {
        public int Id { get; set; }
        public string Challenge { get; set; }
        public string Placing { get; set; }
        public string EntryNumber { get; set; }
        public bool Print { get; set; }
        public int ShowId { get; set; }
        public string ShowName { get; set; }
        public int JudgingOrder { get; set; }
    }
}
