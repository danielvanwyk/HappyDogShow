using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace HappyDogShow.Data
{
    public class HappyDogShowContext : DbContext
    {
        public HappyDogShowContext() 
            : base("name=HappyDogShowDBConnectionString")
        {

        }

        public DbSet<DogRegistration> DogRegistrations { get; set; }
        //public DbSet<Address> Addresses { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Gender> Genders { get; set; }
        //public DbSet<Owner> Owners { get; set; }
        //public DbSet<Title> Titles { get; set; }
        public DbSet<BreedGroup> BreedGroups { get; set; }

        public DbSet<Club> Clubs { get; set; }
        public DbSet<DogShow> DogShows { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<DisciplineClass> DisciplineClasses { get; set; }
        public DbSet<DisciplineSize> DisciplineSizes { get; set; }
        public DbSet<DisciplineGrade> DisciplineGrades { get; set; }

        public DbSet<BreedClass> BreedClasses { get; set; }
        public DbSet<BreedEntry> BreedEntries { get; set; }
        public DbSet<BreedClassEntry> BreedClassEntries { get; set; }
        public DbSet<Sex> Sexes { get; set; }
        public DbSet<HandlerRegistration> HandlerRegistrations { get; set; }
        public DbSet<HandlerClass> HandlerClasses { get; set; }
        public DbSet<HandlerEntry> HandlerEntries { get; set; }
        public DbSet<Judge> Judges { get; set; }
        public DbSet<ShowGroupJudge> ShowGroupJudges { get; set; }
        public DbSet<ShowBreedJudge> ShowBreedJudges { get; set; }
        public DbSet<BreedChallenge> BreedChallenges { get; set; }
        public DbSet<BreedGroupChallenge> BreedGroupChallenges { get; set; }
        public DbSet<ShowChallenge> ShowChallenges { get; set; }
        public DbSet<ShowInShowChallengeJudge> ShowInShowChallengeJudges { get; set; }
        public DbSet<ShowHandlerClassJudge> ShowHandlerClassJudges { get; set; }

        public DbSet<BreedChallengeResult> BreedChallengeResults { get; set; }
        public DbSet<BreedGroupChallengeResult> BreedGroupChallengeResults { get; set; }
    }
}
