using HappyDogShow.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.SharedModels
{
    public class BreedEntryClassEntry : ValidatableBindableBase, IBreedEntryClassEntry
    {
        public static int colsperrow = 5;
        public int Id { get; set; }
        public string ShowName { get; set; }
        public int ShowId { get; set; }
        public DateTime ShowDate { get; set; }
        public string BreedGroupName { get; set; }
        public int BreedGroupId { get; set; }
        public string BreedName { get; set; }
        public int BreedId { get; set; }
        public string GenderName { get; set; }
        public int GenderId { get; set; }
        public string DogName { get; set; }
        public int DogId { get; set; }
        public string DogRegistrationNumber { get; set; }
        public DateTime DogDOB { get; set; }
        public string EntryNumber { get; set; }
        public string EnteredClassName { get; set; }
        public int EnteredClassMaxAgeInMonths { get; set; }
        public int EnteredClassMinAgeInMonths { get; set; }
        public int DogAgeInMonthsAtTimeOfShow
        {
            get
            {
                return DogDOB.DiffMonths(ShowDate);
            }
        }

        public bool IsOutOfAgeRange
        {
            get
            {
                return DetermineIfDogAgeIsOutOfRangeBasedOnClassMinAndMaxDates(DogAgeInMonthsAtTimeOfShow, EnteredClassMinAgeInMonths, EnteredClassMaxAgeInMonths);
            }
        }

        public static bool DetermineIfDogAgeIsOutOfRangeBasedOnClassMinAndMaxDates(int dogAgeInMonthsAtTimeOfShow, int minAgeInMonths, int maxAgeInMonths)
        {
            bool result = false;

            if ((minAgeInMonths == 0) && (maxAgeInMonths == 0))
                result = false;
            else
            {
                if ((dogAgeInMonthsAtTimeOfShow >= minAgeInMonths) && (dogAgeInMonthsAtTimeOfShow <= maxAgeInMonths))
                    result = false;
                else
                    result = true;
            }

            return result;
        }

        private string result;
        public string Result
        {
            get { return result; }
            set { SetProperty(ref result, value); }
        }



        public string ReportGroupingKey
        {
            get { return string.Format("{0}.{1}.{2}.{3}.{4}", ShowName, BreedGroupName, BreedName, GenderName, EnteredClassName); }
        }

        public string ReportSortingKey
        {
            get { return string.Format("{0}.{1}.{2}.{3}.{4}.{5}", ShowName, BreedGroupName, BreedName, GenderName, EnteredClassName, EntryNumber.PadLeft(4, '0')); }
        }

        public int ReportingRank { get; set; }

        public int ReportingRankRow
        {
            get
            {
                return ReportingRank / colsperrow;
            }
        }

        public int ReportingRankColumn
        {
            get
            {
                int result = ReportingRank % colsperrow;

                if (ReportingRankRow == 0)
                    result--;

                return result;
            }
        }

        public int JudgingOrder { get; set; }

        public string BreedGroupJudgeName { get; set; }
        public string BreedJudgeName { get; set; }
        public string ActualJudgeName
        {
            get
            {
                if (string.IsNullOrEmpty(BreedJudgeName))
                    return BreedGroupJudgeName;

                return BreedJudgeName;
            }
        }

        public List<string> Namesss { get; set; }

        public BreedEntryClassEntry()
        {
            Namesss = new List<string>();
            Namesss.Add("Gracie");
            Namesss.Add("Gaia");
        }
    }
}
