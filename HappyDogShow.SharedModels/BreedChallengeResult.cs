﻿using HappyDogShow.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Models;

namespace HappyDogShow.SharedModels
{
    public class BreedChallengeResult : ValidatableBindableBase, IBreedChallengeResult
    {
        public int Id { get; set; }
        public string Challenge { get; set; }
        public string Placing { get; set; }
        public string EntryNumber { get; set; }
        public bool Print { get; set; }
        public int ShowId { get; set; }
        public int JudgingOrder { get; set; }
        public string ShowName { get; set; }
        public string BreedName { get; set; }
        public string BreedGroupName { get; set; }
        public string RelatedBreedGroupChallengeName { get; set; }
    }
}
