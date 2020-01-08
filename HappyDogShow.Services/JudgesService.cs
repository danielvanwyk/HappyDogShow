using HappyDogShow.Data;
using HappyDogShow.Services.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Services;
using HappyDogShow.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services
{
    public class JudgesService : IJudgesService
    {
        public Task<List<IJudgeAssignmentInformation>> GetListOfAllTheJudgesForShowAsync<T>(int dogShowId) where T : IJudgeAssignmentInformation, new()
        {
            Task<List<IJudgeAssignmentInformation>> t = Task<List<IJudgeAssignmentInformation>>.Run(() =>
            {
                List<IJudgeAssignmentInformation> items = GetList<T>(dogShowId);
                return items;
            });

            return t;
        }

        private List<IJudgeAssignmentInformation> GetList<T>(int dogShowId) where T : IJudgeAssignmentInformation, new()
        {
            List<IJudgeAssignmentInformation> items = new List<IJudgeAssignmentInformation>();

            using (var ctx = new HappyDogShowContext())
            {
                var groupJudges = from d in ctx.ShowGroupJudges
                                  where d.DogShow.ID == dogShowId
                                  select new
                                  {
                                      JudgeName = d.Judge.Name,
                                      GroupName = d.BreedGroup.Name
                                  };

                var inShowJudges = from d in ctx.ShowInShowChallengeJudges
                                   where d.DogShow.ID == dogShowId
                                   select new
                                   {
                                       JudgeName = d.Judge.Name,
                                       ChallengeName = d.ShowChallenge.Name
                                   };

                var handlerJudges = from d in ctx.ShowHandlerClassJudges
                                    where d.DogShow.ID == dogShowId
                                    select new
                                    {
                                        JudgeName = d.Judge.Name,
                                        ClassName = d.HandlerClass.Name
                                    };

                foreach (var i in groupJudges)
                {
                    items.Add(new JudgeAssignmentInformation()
                    {
                        JudgeName = i.JudgeName,
                        AssignedTo = i.GroupName
                    });
                }

                foreach (var i in inShowJudges)
                {
                    items.Add(new JudgeAssignmentInformation()
                    {
                        JudgeName = i.JudgeName,
                        AssignedTo = i.ChallengeName
                    });
                }

                foreach (var i in handlerJudges)
                {
                    items.Add(new JudgeAssignmentInformation()
                    {
                        JudgeName = i.JudgeName,
                        AssignedTo = i.ClassName
                    });
                }

            }

            return items;
        }

    }
}
