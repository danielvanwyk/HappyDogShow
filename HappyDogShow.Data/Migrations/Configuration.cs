﻿namespace HappyDogShow.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<HappyDogShow.Data.HappyDogShowContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HappyDogShow.Data.HappyDogShowContext";
        }

        protected override void Seed(HappyDogShow.Data.HappyDogShowContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var maleGenders = context.Genders.Where(g => g.Name == "Male");
            if (maleGenders.Count() == 1)
            {
                maleGenders.First().Name = "Dog";
                context.SaveChanges();
            }

            var femaleGenders = context.Genders.Where(g => g.Name == "Female");
            if (femaleGenders.Count() == 1)
            {
                femaleGenders.First().Name = "Bitch";
                context.SaveChanges();
            }


            var breedGSDs = context.Breeds.Where(b => b.Name == "Belgian Shepherd Dog");

            if (breedGSDs.Count() == 1)
            {
                breedGSDs.First().Name = "Belgian Shepherd Dog (Groenendael)";
                context.SaveChanges();
            }

            context.Sexes.AddOrUpdate(x => x.Name,
                new Sex() { Name = "Male" },
                new Sex() { Name = "Female" }
                );




            context.HandlerClasses.AddOrUpdate(x => x.Name,
                new HandlerClass() { Name = "Child", MinAgeInYears = 8, MaxAgeInYears = 10, Description = "Child Handler" },
                new HandlerClass() { Name = "Junior", MinAgeInYears = 11, MaxAgeInYears = 17, Description = "Junior Handler" },
                new HandlerClass() { Name = "Adult", MinAgeInYears = 18, MaxAgeInYears = 999, Description = "Adult Handler" }
                );






            context.BreedClasses.AddOrUpdate(x => x.Name,
                new BreedClass() { JudgingOrder = 1, Name = "Baby Puppy", MinAgeInMonths = 4, MaxAgeInMonths = 5, Description = "For dogs of four (4) under six (6) months of age on the first day of the show (not eligible for CC or BOB)" },
                new BreedClass() { JudgingOrder = 2, Name = "Minor Puppy", MinAgeInMonths = 6, MaxAgeInMonths = 8, Description = "For dogs of six (6) under nine (9) months of age on the first day of the Show." },
                new BreedClass() { JudgingOrder = 3, Name = "Puppy", MinAgeInMonths = 9, MaxAgeInMonths = 11, Description = "For dogs of nine (9) under twelve (12) months of age on the first day of the Show." },
                new BreedClass() { JudgingOrder = 4, Name = "Junior", MinAgeInMonths = 12, MaxAgeInMonths = 17, Description = "For dogs of twelve (12) under eighteen (18) months of age on the first day of the Show." },
                new BreedClass() { JudgingOrder = 5, Name = "Graduate", MinAgeInMonths = 18, MaxAgeInMonths = 23, Description = "For dogs of eighteen (18) under twenty-four (24) months of age on the first day of the Show." },
                new BreedClass() { JudgingOrder = 6, Name = "Open", MinAgeInMonths = 0, MaxAgeInMonths = 0, Description = "For dogs of any Breed therein provided for." },
                new BreedClass() { JudgingOrder = 10, Name = "Champions", MinAgeInMonths = 0, MaxAgeInMonths = 0, Description = "Officially a KUSA Champion – Does not compete for CC" },
                new BreedClass() { JudgingOrder = 7, Name = "SA Bred", MinAgeInMonths = 0, MaxAgeInMonths = 0, Description = "Dogs born in South Africa" },
                new BreedClass() { JudgingOrder = 8, Name = "Veterans", MinAgeInMonths = 84, MaxAgeInMonths = 99999, Description = "Over 7 years of age" },
                new BreedClass() { JudgingOrder = 9, Name = "Neuter Dog", MinAgeInMonths = 0, MaxAgeInMonths = 0, Description = "For dogs of any age that have been castrated for whatever reason (not eligible for CC or BOB)." }
                );

            context.Genders.AddOrUpdate(x => x.Name,
                new Gender() { Name = "Dog" },
                new Gender() { Name = "Bitch" }
                );

            context.Clubs.AddOrUpdate(x => x.Name,
                new Club() { Name = "Overberg Kennel Club" }
                );

            context.BreedGroups.AddOrUpdate(x => x.Name,
                new BreedGroup() { Name = "Gundog" },
                new BreedGroup() { Name = "Herding" },
                new BreedGroup() { Name = "Hound" },
                new BreedGroup() { Name = "Terrier" },
                new BreedGroup() { Name = "Toy" },
                new BreedGroup() { Name = "Utility" },
                new BreedGroup() { Name = "Working" }
                );

            context.SaveChanges();

            var gundogsbg = context.BreedGroups.Where(bg => bg.Name == "Gundog");
            var gundogbg = gundogsbg.First();

            var herdingsbg = context.BreedGroups.Where(bg => bg.Name == "Herding");
            var herdingbg = herdingsbg.First();

            var houndsbg = context.BreedGroups.Where(bg => bg.Name == "Hound");
            var houndbg = houndsbg.First();

            var terriersbg = context.BreedGroups.Where(bg => bg.Name == "Terrier");
            var terrierbg = terriersbg.First();

            var toysbg = context.BreedGroups.Where(bg => bg.Name == "Toy");
            var toybg = toysbg.First();

            var utilitysbg = context.BreedGroups.Where(bg => bg.Name == "Utility");
            var utilitybg = utilitysbg.First();

            var workingsbg = context.BreedGroups.Where(bg => bg.Name == "Working");
            var workingbg = workingsbg.First();

            context.Breeds.AddOrUpdate(x => x.Name,
                new Breed() { Name = "Auvergne Pointer (Braque d' Auvergne)", BreedGroup = gundogbg },
                new Breed() { Name = "Bohemian Wire-haired Pointing Griffon (Cesky Fousek)", BreedGroup = gundogbg },
                new Breed() { Name = "Bracco Italiano (Italian Pointing Dog)", BreedGroup = gundogbg },
                new Breed() { Name = "Brittany Spaniel (Epagneul Bretton)", BreedGroup = gundogbg },
                new Breed() { Name = "English Setter", BreedGroup = gundogbg },
                new Breed() { Name = "Field Spaniel", BreedGroup = gundogbg },
                new Breed() { Name = "German Short-haired Pointer", BreedGroup = gundogbg },
                new Breed() { Name = "German Wire-haired Pointer", BreedGroup = gundogbg },
                new Breed() { Name = "Gordon Setter", BreedGroup = gundogbg },
                new Breed() { Name = "Hungarian Vizsla", BreedGroup = gundogbg },
                new Breed() { Name = "Hungarian Wire-haired Pointer (Vizsla)", BreedGroup = gundogbg },
                new Breed() { Name = "Irish Red & White Setter", BreedGroup = gundogbg },
                new Breed() { Name = "Irish Setter", BreedGroup = gundogbg },
                new Breed() { Name = "Irish Water Spaniel", BreedGroup = gundogbg },
                new Breed() { Name = "Kleiner Münsterländer", BreedGroup = gundogbg },
                new Breed() { Name = "Lagotto Romagnolo", BreedGroup = gundogbg },
                new Breed() { Name = "Large Munsterlander", BreedGroup = gundogbg },
                new Breed() { Name = "Nederlandse Kooikerhondje", BreedGroup = gundogbg },
                new Breed() { Name = "Pointer", BreedGroup = gundogbg },
                new Breed() { Name = "Retriever (Chesapeake Bay)", BreedGroup = gundogbg },
                new Breed() { Name = "Retriever (Curly Coated)", BreedGroup = gundogbg },
                new Breed() { Name = "Retriever (Flat Coated)", BreedGroup = gundogbg },
                new Breed() { Name = "Retriever (Golden)", BreedGroup = gundogbg },
                new Breed() { Name = "Retriever (Labrador)", BreedGroup = gundogbg },
                new Breed() { Name = "Spaniel (American Cocker)", BreedGroup = gundogbg },
                new Breed() { Name = "Spaniel (Clumber)", BreedGroup = gundogbg },
                new Breed() { Name = "Spaniel (Cocker)", BreedGroup = gundogbg },
                new Breed() { Name = "Spaniel (English Springer)", BreedGroup = gundogbg },
                new Breed() { Name = "Spaniel (Welsh Springer)", BreedGroup = gundogbg },
                new Breed() { Name = "Spinone Italiano", BreedGroup = gundogbg },
                new Breed() { Name = "Stabijhoun", BreedGroup = gundogbg },
                new Breed() { Name = "Sussex Spaniel", BreedGroup = gundogbg },
                new Breed() { Name = "Weimaraner", BreedGroup = gundogbg },
                new Breed() { Name = "Wirehaired Slovakian Pointer (Slovenský hrubosrstý Stavač)", BreedGroup = gundogbg },

                new Breed() { Name = "Australian Cattle Dog", BreedGroup = herdingbg },
                new Breed() { Name = "Australian Kelpie", BreedGroup = herdingbg },
                new Breed() { Name = "Australian Shepherd", BreedGroup = herdingbg },
                new Breed() { Name = "Bearded Collie", BreedGroup = herdingbg },
                new Breed() { Name = "Beauce Sheep Dog", BreedGroup = herdingbg },
                new Breed() { Name = "Belgian Shepherd Dog (Groenendael)", BreedGroup = herdingbg },
                new Breed() { Name = "Belgian Shepherd Dog (Tervueren)", BreedGroup = herdingbg },
                new Breed() { Name = "Belgian Shepherd Dog (Malinois)", BreedGroup = herdingbg },
                new Breed() { Name = "Belgian Shepherd Dog (Laekenois)", BreedGroup = herdingbg },
                new Breed() { Name = "Border Collie", BreedGroup = herdingbg },
                new Breed() { Name = "Bouvier des Flandres", BreedGroup = herdingbg },
                new Breed() { Name = "Briard", BreedGroup = herdingbg },
                new Breed() { Name = "Cane Da Pastore Bergamasco", BreedGroup = herdingbg },
                new Breed() { Name = "Cane da Pastore Maremmano - Abruzzese (Maremma and the Abruzzes Sheepdpog)", BreedGroup = herdingbg },
                new Breed() { Name = "Collie (Rough)", BreedGroup = herdingbg },
                new Breed() { Name = "Collie (Smooth)", BreedGroup = herdingbg },
                new Breed() { Name = "Dutch Shepherd Dog", BreedGroup = herdingbg },
                new Breed() { Name = "Komondor", BreedGroup = herdingbg },
                new Breed() { Name = "Kuvasz", BreedGroup = herdingbg },
                new Breed() { Name = "Lancashire Heeler", BreedGroup = herdingbg },
                new Breed() { Name = "Miniature American Shepherd", BreedGroup = herdingbg },
                new Breed() { Name = "Mudi", BreedGroup = herdingbg },
                new Breed() { Name = "Norwegian Buhund", BreedGroup = herdingbg },
                new Breed() { Name = "Old English Sheepdog", BreedGroup = herdingbg },
                new Breed() { Name = "Picardy Sheepdog", BreedGroup = herdingbg },
                new Breed() { Name = "Polish Lowland Sheepdog", BreedGroup = herdingbg },
                new Breed() { Name = "Puli", BreedGroup = herdingbg },
                new Breed() { Name = "Pumi", BreedGroup = herdingbg },
                new Breed() { Name = "Pyrenean Sheepdog Long - Haired", BreedGroup = herdingbg },
                new Breed() { Name = "Samoyed", BreedGroup = herdingbg },
                new Breed() { Name = "Shetland Sheepdog", BreedGroup = herdingbg },
                new Breed() { Name = "Suomenlapinkoira", BreedGroup = herdingbg },
                new Breed() { Name = "Swedish Vallhund", BreedGroup = herdingbg },
                new Breed() { Name = "Welsh Corgi (Cardigan)", BreedGroup = herdingbg },
                new Breed() { Name = "Welsh Corgi (Pembroke)", BreedGroup = herdingbg },
                new Breed() { Name = "White Swiss Shepherd Dog", BreedGroup = herdingbg },

                new Breed() { Name = "Afghan Hound", BreedGroup = houndbg },
                new Breed() { Name = "American English Coonhound", BreedGroup = houndbg },
                new Breed() { Name = "Azawakh", BreedGroup = houndbg },
                new Breed() { Name = "Basenji", BreedGroup = houndbg },
                new Breed() { Name = "Basset Fauve de Bretagne", BreedGroup = houndbg },
                new Breed() { Name = "Basset Griffon Vendeen (Petit)", BreedGroup = houndbg },
                new Breed() { Name = "Basset Hound", BreedGroup = houndbg },
                new Breed() { Name = "Bavarian Mountain Scent Hound (Bayerischer Gebirgsschweisshund)", BreedGroup = houndbg },
                new Breed() { Name = "Beagle", BreedGroup = houndbg },
                new Breed() { Name = "Bloodhound", BreedGroup = houndbg },
                new Breed() { Name = "Bluetick Coonhound", BreedGroup = houndbg },
                new Breed() { Name = "Borzoi - Russian Hunting Sighthound", BreedGroup = houndbg },
                new Breed() { Name = "Coarse-haired Styrian Hound", BreedGroup = houndbg },
                new Breed() { Name = "Dachshund (Long-haired)", BreedGroup = houndbg },
                new Breed() { Name = "Dachshund (Miniature Long-haired)", BreedGroup = houndbg },
                new Breed() { Name = "Dachshund (Miniature Smooth-haired)", BreedGroup = houndbg },
                new Breed() { Name = "Dachshund (Miniature Wire-haired)", BreedGroup = houndbg },
                new Breed() { Name = "Dachshund (Smooth-haired)", BreedGroup = houndbg },
                new Breed() { Name = "Dachshund (Wire-haired)", BreedGroup = houndbg },
                new Breed() { Name = "Deerhound", BreedGroup = houndbg },
                new Breed() { Name = "English Foxhound", BreedGroup = houndbg },
                new Breed() { Name = "Finnish Spitz", BreedGroup = houndbg },
                new Breed() { Name = "Grand Basset Griffon Vendeen", BreedGroup = houndbg },
                new Breed() { Name = "Greyhound", BreedGroup = houndbg },
                new Breed() { Name = "Hamiltonstövare", BreedGroup = houndbg },
                new Breed() { Name = "Irish Wolfhound", BreedGroup = houndbg },
                new Breed() { Name = "Norman Artesien Basset (Basset Artésien Normand)", BreedGroup = houndbg },
                new Breed() { Name = "Norwegian Elkhound Black", BreedGroup = houndbg },
                new Breed() { Name = "Norwegian Elkhound Grey", BreedGroup = houndbg },
                new Breed() { Name = "Otterhound", BreedGroup = houndbg },
                new Breed() { Name = "Pharaoh Hound", BreedGroup = houndbg },
                new Breed() { Name = "Podenco Ibicenco (Ibizan Hound)", BreedGroup = houndbg },
                new Breed() { Name = "Rhodesian Ridgeback", BreedGroup = houndbg },
                new Breed() { Name = "Saluki", BreedGroup = houndbg },
                new Breed() { Name = "Sloughi", BreedGroup = houndbg },
                new Breed() { Name = "Spanish Greyhound", BreedGroup = houndbg },
                new Breed() { Name = "Thai Ridgeback Dog", BreedGroup = houndbg },
                new Breed() { Name = "Whippet", BreedGroup = houndbg },

                new Breed() { Name = "Airedale Terrier", BreedGroup = terrierbg },
                new Breed() { Name = "American Staffordshire Terrier", BreedGroup = terrierbg },
                new Breed() { Name = "Australian Terrier", BreedGroup = terrierbg },
                new Breed() { Name = "Bedlington Terrier", BreedGroup = terrierbg },
                new Breed() { Name = "Border Terrier", BreedGroup = terrierbg },
                new Breed() { Name = "Brazilian Terrier", BreedGroup = terrierbg },
                new Breed() { Name = "Bull Terrier", BreedGroup = terrierbg },
                new Breed() { Name = "Bull Terrier (Miniature)", BreedGroup = terrierbg },
                new Breed() { Name = "Cairn Terrier", BreedGroup = terrierbg },
                new Breed() { Name = "Czech Terrier", BreedGroup = terrierbg },
                new Breed() { Name = "Dandie Dinmont Terrier", BreedGroup = terrierbg },
                new Breed() { Name = "Fox Terrier (Smooth)", BreedGroup = terrierbg },
                new Breed() { Name = "Fox Terrier (Wire)", BreedGroup = terrierbg },
                new Breed() { Name = "Irish Glen of Imaal Terrier", BreedGroup = terrierbg },
                new Breed() { Name = "Irish Soft Coated Wheaten Terrier", BreedGroup = terrierbg },
                new Breed() { Name = "Irish Terrier", BreedGroup = terrierbg },
                new Breed() { Name = "Jack Russell Terrier", BreedGroup = terrierbg },
                new Breed() { Name = "Kerry Blue Terrier", BreedGroup = terrierbg },
                new Breed() { Name = "Lakeland Terrier", BreedGroup = terrierbg },
                new Breed() { Name = "Manchester Terrier", BreedGroup = terrierbg },
                new Breed() { Name = "Norfolk Terrier", BreedGroup = terrierbg },
                new Breed() { Name = "Norwich Terrier", BreedGroup = terrierbg },
                new Breed() { Name = "Parson Russell Terrier", BreedGroup = terrierbg },
                new Breed() { Name = "Scottish Terrier", BreedGroup = terrierbg },
                new Breed() { Name = "Sealyham Terrier", BreedGroup = terrierbg },
                new Breed() { Name = "Skye Terrier", BreedGroup = terrierbg },
                new Breed() { Name = "Staffordshire Bull Terrier", BreedGroup = terrierbg },
                new Breed() { Name = "Welsh Terrier", BreedGroup = terrierbg },
                new Breed() { Name = "West Highland White Terrier", BreedGroup = terrierbg },

                new Breed() { Name = "Affenpinscher", BreedGroup = toybg },
                new Breed() { Name = "Australian Silky Terrier", BreedGroup = toybg },
                new Breed() { Name = "Bichon Frisé", BreedGroup = toybg },
                new Breed() { Name = "Biewer Terrier", BreedGroup = toybg },
                new Breed() { Name = "Bolognese", BreedGroup = toybg },
                new Breed() { Name = "Cavalier King Charles Spaniel", BreedGroup = toybg },
                new Breed() { Name = "Chihuahua - Long Coat", BreedGroup = toybg },
                new Breed() { Name = "Chihuahua - Smooth Coat", BreedGroup = toybg },
                new Breed() { Name = "Chinese Crested", BreedGroup = toybg },
                new Breed() { Name = "Coton De Tulear", BreedGroup = toybg },
                new Breed() { Name = "English Toy Terrier (Black & Tan)", BreedGroup = toybg },
                new Breed() { Name = "Griffon Bruxellois", BreedGroup = toybg },
                new Breed() { Name = "Havanese (Bichon Havanais)", BreedGroup = toybg },
                new Breed() { Name = "Italian Greyhound", BreedGroup = toybg },
                new Breed() { Name = "Japanese Chin", BreedGroup = toybg },
                new Breed() { Name = "King Charles Spaniel", BreedGroup = toybg },
                new Breed() { Name = "Löwchen (Little Lion Dog)", BreedGroup = toybg },
                new Breed() { Name = "Maltese", BreedGroup = toybg },
                new Breed() { Name = "Miniature Pinscher", BreedGroup = toybg },
                new Breed() { Name = "Papillon", BreedGroup = toybg },
                new Breed() { Name = "Pekingese", BreedGroup = toybg },
                new Breed() { Name = "Pomeranian", BreedGroup = toybg },
                new Breed() { Name = "Pug", BreedGroup = toybg },
                new Breed() { Name = "Toy Fox Terrier", BreedGroup = toybg },
                new Breed() { Name = "Yorkshire Terrier", BreedGroup = toybg },

                new Breed() { Name = "Akita", BreedGroup = utilitybg },
                new Breed() { Name = "Boston Terrier", BreedGroup = utilitybg },
                new Breed() { Name = "Bulldog", BreedGroup = utilitybg },
                new Breed() { Name = "Canaan Dog", BreedGroup = utilitybg },
                new Breed() { Name = "Chow Chow", BreedGroup = utilitybg },
                new Breed() { Name = "Dalmatian", BreedGroup = utilitybg },
                new Breed() { Name = "French Bulldog", BreedGroup = utilitybg },
                new Breed() { Name = "German Spitz (Mittel)", BreedGroup = utilitybg },
                new Breed() { Name = "Japanese Spitz", BreedGroup = utilitybg },
                new Breed() { Name = "Keeshond", BreedGroup = utilitybg },
                new Breed() { Name = "Lhasa Apso", BreedGroup = utilitybg },
                new Breed() { Name = "Miniature Schnauzer", BreedGroup = utilitybg },
                new Breed() { Name = "Peruvian Hairless Dog", BreedGroup = utilitybg },
                new Breed() { Name = "Poodle (Miniature)", BreedGroup = utilitybg },
                new Breed() { Name = "Poodle (Standard)", BreedGroup = utilitybg },
                new Breed() { Name = "Poodle (Toy)", BreedGroup = utilitybg },
                new Breed() { Name = "Schipperke", BreedGroup = utilitybg },
                new Breed() { Name = "Shar Pei", BreedGroup = utilitybg },
                new Breed() { Name = "Shiba", BreedGroup = utilitybg },
                new Breed() { Name = "Shih Tzu", BreedGroup = utilitybg },
                new Breed() { Name = "Tibetan Spaniel", BreedGroup = utilitybg },
                new Breed() { Name = "Tibetan Terrier", BreedGroup = utilitybg },
                new Breed() { Name = "Xoloitzcuintle (Hairless Variety & Coated Variety)", BreedGroup = utilitybg },

                new Breed() { Name = "Alaskan Malamute", BreedGroup = workingbg },
                new Breed() { Name = "American Akita", BreedGroup = workingbg },
                new Breed() { Name = "Appenzell Cattle Dog", BreedGroup = workingbg },
                new Breed() { Name = "Bernese Mountain Dog", BreedGroup = workingbg },
                new Breed() { Name = "Boerboel", BreedGroup = workingbg },
                new Breed() { Name = "Boxer", BreedGroup = workingbg },
                new Breed() { Name = "Bullmastiff", BreedGroup = workingbg },
                new Breed() { Name = "Canadian Eskimo Dog", BreedGroup = workingbg },
                new Breed() { Name = "Cane Corso Italiano", BreedGroup = workingbg },
                new Breed() { Name = "Caucasian Shepherd Dog", BreedGroup = workingbg },
                new Breed() { Name = "Central Asia Shepherd Dog", BreedGroup = workingbg },
                new Breed() { Name = "Do-Khyi (Tibetan Mastiff)", BreedGroup = workingbg },
                new Breed() { Name = "Dobermann", BreedGroup = workingbg },
                new Breed() { Name = "Dogo Argentino", BreedGroup = workingbg },
                new Breed() { Name = "Dogo Canario", BreedGroup = workingbg },
                new Breed() { Name = "Dogue de Bordeaux", BreedGroup = workingbg },
                new Breed() { Name = "Estrela Mountain Dog", BreedGroup = workingbg },
                new Breed() { Name = "Fila Brasileiro", BreedGroup = workingbg },
                new Breed() { Name = "German Pinscher", BreedGroup = workingbg },
                new Breed() { Name = "German Shepherd Dog", BreedGroup = workingbg },
                new Breed() { Name = "Giant Schnauzer", BreedGroup = workingbg },
                new Breed() { Name = "Great Dane", BreedGroup = workingbg },
                new Breed() { Name = "Great Swiss Mountain Dog (Grosser Schweizer Sennenhund)", BreedGroup = workingbg },
                new Breed() { Name = "Greenland Dog", BreedGroup = workingbg },
                new Breed() { Name = "Hovawart", BreedGroup = workingbg },
                new Breed() { Name = "Kangal Çoban Köpeği (Kangal Shepherd Dog)", BreedGroup = workingbg },
                new Breed() { Name = "Landseer (ECT)", BreedGroup = workingbg },
                new Breed() { Name = "Leonberger", BreedGroup = workingbg },
                new Breed() { Name = "Mastiff", BreedGroup = workingbg },
                new Breed() { Name = "Mastino Napoletano (Neapolitan Mastiff)", BreedGroup = workingbg },
                new Breed() { Name = "Newfoundland", BreedGroup = workingbg },
                new Breed() { Name = "Portuguese Water Dog", BreedGroup = workingbg },
                new Breed() { Name = "Pyrenean Mountain Dog", BreedGroup = workingbg },
                new Breed() { Name = "Rottweiler", BreedGroup = workingbg },
                new Breed() { Name = "Russian Black Terrier", BreedGroup = workingbg },
                new Breed() { Name = "Saint Bernard", BreedGroup = workingbg },
                new Breed() { Name = "Schnauzer", BreedGroup = workingbg },
                new Breed() { Name = "Siberian Husky", BreedGroup = workingbg },
                new Breed() { Name = "Tosa", BreedGroup = workingbg }
            );

            context.Judges.AddOrUpdate(x => x.Name,
                new Judge() { Name = "Liz Raubenheimer" },
                new Judge() { Name = "Nicky Robertson" },
                new Judge() { Name = "Sue Carter" },
                new Judge() { Name = "Bianca Teixeira (Brazil)" },
                new Judge() { Name = "Leoni Kroff" },
                new Judge() { Name = "Dale Fabian" },
                new Judge() { Name = "Ian Holdsworth" },
                new Judge() { Name = "Vanessa Nicolau" }
                );

            context.DogShows.AddOrUpdate(x => x.Name,
                new DogShow() { Name = "Overberg Kennel Club Show 1", ShowDate = new DateTime(2020, 1, 11) },
                new DogShow() { Name = "Overberg Kennel Club Show 2", ShowDate = new DateTime(2020, 1, 11) }
                );

            context.SaveChanges();

            var firstShow = context.DogShows.Where(bg => bg.Name == "Overberg Kennel Club Show 1").First();
            var secondShow = context.DogShows.Where(bg => bg.Name == "Overberg Kennel Club Show 2").First();

            var lizRaubenheimer = context.Judges.Where(c => c.Name == "Liz Raubenheimer").First();
            var nickyRobertson = context.Judges.Where(c => c.Name == "Nicky Robertson").First();
            var sueCarter = context.Judges.Where(c => c.Name == "Sue Carter").First();
            var bianca = context.Judges.Where(c => c.Name == "Bianca Teixeira (Brazil)").First();
            var leoni = context.Judges.Where(c => c.Name == "Leoni Kroff").First();
            var dale = context.Judges.Where(c => c.Name == "Dale Fabian").First();
            var ian = context.Judges.Where(c => c.Name == "Ian Holdsworth").First();
            var vanessa = context.Judges.Where(c => c.Name == "Vanessa Nicolau").First();

            context.ShowGroupJudges.AddOrUpdate(x => x.ID,
                new ShowGroupJudge() { ID = 1, DogShow = firstShow, BreedGroup = gundogbg, Judge = sueCarter },
                new ShowGroupJudge() { ID = 2, DogShow = firstShow, BreedGroup = herdingbg, Judge = ian },
                new ShowGroupJudge() { ID = 3, DogShow = firstShow, BreedGroup = terrierbg, Judge = bianca },
                new ShowGroupJudge() { ID = 4, DogShow = firstShow, BreedGroup = houndbg, Judge = dale },
                new ShowGroupJudge() { ID = 5, DogShow = firstShow, BreedGroup = toybg, Judge = lizRaubenheimer },
                new ShowGroupJudge() { ID = 6, DogShow = firstShow, BreedGroup = utilitybg, Judge = vanessa },
                new ShowGroupJudge() { ID = 7, DogShow = firstShow, BreedGroup = workingbg, Judge = nickyRobertson }
                );

            context.ShowGroupJudges.AddOrUpdate(x => x.ID,
                new ShowGroupJudge() { ID = 8, DogShow = secondShow, BreedGroup = gundogbg, Judge = lizRaubenheimer },
                new ShowGroupJudge() { ID = 9, DogShow = secondShow, BreedGroup = herdingbg, Judge = nickyRobertson },
                new ShowGroupJudge() { ID = 10, DogShow = secondShow, BreedGroup = terrierbg, Judge = leoni },
                new ShowGroupJudge() { ID = 11, DogShow = secondShow, BreedGroup = houndbg, Judge = sueCarter },
                new ShowGroupJudge() { ID = 12, DogShow = secondShow, BreedGroup = toybg, Judge = dale },
                new ShowGroupJudge() { ID = 13, DogShow = secondShow, BreedGroup = utilitybg, Judge = bianca },
                new ShowGroupJudge() { ID = 14, DogShow = secondShow, BreedGroup = workingbg, Judge = ian }
                );

            context.SaveChanges();

            var bassethound = context.Breeds.Where(c => c.Name == "Basset Hound").First();
            var shiba = context.Breeds.Where(c => c.Name == "Shiba").First();

            context.ShowBreedJudges.AddOrUpdate(x => x.ID,
                new ShowBreedJudge() { ID = 1, DogShow = secondShow, Breed = bassethound, Judge = bianca },
                new ShowBreedJudge() { ID = 2, DogShow = secondShow, Breed = shiba, Judge = nickyRobertson }
                );

            context.SaveChanges();

            context.ShowChallenges.AddOrUpdate(x => x.Name,
                new ShowChallenge() { JudgingOrder = 1, Name = "Best in Show", Abbreviation = "BIS" },
                new ShowChallenge() { JudgingOrder = 2, Name = "Best Puppy in Show", Abbreviation = "BPIS" },
                new ShowChallenge() { JudgingOrder = 3, Name = "Best Junior in Show", Abbreviation = "BJIS" },
                new ShowChallenge() { JudgingOrder = 4, Name = "Best Veteran in Show", Abbreviation = "BVIS" },
                new ShowChallenge() { JudgingOrder = 5, Name = "Best Baby Puppy in Show", Abbreviation = "BBPIS" },
                new ShowChallenge() { JudgingOrder = 6, Name = "Best Neuter in Show", Abbreviation = "BNIS" }
                );

            context.SaveChanges();

            ShowChallenge bis = context.ShowChallenges.Where(c => c.Abbreviation == "BIS").First();
            ShowChallenge bpis = context.ShowChallenges.Where(c => c.Abbreviation == "BPIS").First();
            ShowChallenge bjis = context.ShowChallenges.Where(c => c.Abbreviation == "BJIS").First();
            ShowChallenge bvis = context.ShowChallenges.Where(c => c.Abbreviation == "BVIS").First();
            ShowChallenge bbpis = context.ShowChallenges.Where(c => c.Abbreviation == "BBPIS").First();
            ShowChallenge bnis = context.ShowChallenges.Where(c => c.Abbreviation == "BNIS").First();

            context.BreedGroupChallenges.AddOrUpdate(x => x.Name,
                new BreedGroupChallenge() { JudgingOrder = 1, Name = "Best in Group", Abbreviation = "BIG", ShowChallenge = bis },
                new BreedGroupChallenge() { JudgingOrder = 2, Name = "Best Puppy in Group", Abbreviation = "BPIG", ShowChallenge = bpis },
                new BreedGroupChallenge() { JudgingOrder = 3, Name = "Best Junior in Group", Abbreviation = "BJIG", ShowChallenge = bjis },
                new BreedGroupChallenge() { JudgingOrder = 4, Name = "Best Veteran in Group", Abbreviation = "BVIG", ShowChallenge = bvis },
                new BreedGroupChallenge() { JudgingOrder = 5, Name = "Best Baby Puppy in Group", Abbreviation = "BBPIG", ShowChallenge = bbpis },
                new BreedGroupChallenge() { JudgingOrder = 6, Name = "Best Neuter in Group", Abbreviation = "BNIG", ShowChallenge = bnis }
                );

            context.SaveChanges();

            BreedGroupChallenge big = context.BreedGroupChallenges.Where(c => c.Abbreviation == "BIG").First();
            BreedGroupChallenge bpig = context.BreedGroupChallenges.Where(c => c.Abbreviation == "BPIG").First();
            BreedGroupChallenge bjig = context.BreedGroupChallenges.Where(c => c.Abbreviation == "BJIG").First();
            BreedGroupChallenge bvig = context.BreedGroupChallenges.Where(c => c.Abbreviation == "BVIG").First();
            BreedGroupChallenge bbpig = context.BreedGroupChallenges.Where(c => c.Abbreviation == "BBPIG").First();
            BreedGroupChallenge bnig = context.BreedGroupChallenges.Where(c => c.Abbreviation == "BNIG").First();

            context.BreedChallenges.AddOrUpdate(x => x.Name,
    new BreedChallenge() { JudgingOrder = 1, Abbreviation = "", Name = "Dog CC (2 points)", BreedGroupChallenge = null },
    new BreedChallenge() { JudgingOrder = 2, Abbreviation = "", Name = "Dog CC (1 point)", BreedGroupChallenge = null },
    new BreedChallenge() { JudgingOrder = 3, Abbreviation = "", Name = "Dog RCC", BreedGroupChallenge = null },
    new BreedChallenge() { JudgingOrder = 4, Abbreviation = "", Name = "Bitch CC (2 points)", BreedGroupChallenge = null },
    new BreedChallenge() { JudgingOrder = 5, Abbreviation = "", Name = "Bitch CC (1 point)", BreedGroupChallenge = null },
    new BreedChallenge() { JudgingOrder = 6, Abbreviation = "", Name = "Bitch RCC", BreedGroupChallenge = null },
    new BreedChallenge() { JudgingOrder = 7, Abbreviation = "BOB", Name = "Best of Breed", BreedGroupChallenge = big },
    new BreedChallenge() { JudgingOrder = 8, Abbreviation = "RBOB", Name = "Reserve Best of Breed", BreedGroupChallenge = null },
    new BreedChallenge() { JudgingOrder = 9, Abbreviation = "BPIB", Name = "Best Puppy", BreedGroupChallenge = bpig },
    new BreedChallenge() { JudgingOrder = 10, Abbreviation = "BJIB", Name = "Best Junior", BreedGroupChallenge = bjig },
    new BreedChallenge() { JudgingOrder = 11, Abbreviation = "BVIB", Name = "Best Veteran", BreedGroupChallenge = bvig },
    new BreedChallenge() { JudgingOrder = 12, Abbreviation = "BBPIB", Name = "Best Baby Puppy", BreedGroupChallenge = bbpig },
    new BreedChallenge() { JudgingOrder = 13, Abbreviation = "BNIB", Name = "Best Neuter", BreedGroupChallenge = bnig }
    );

            context.ShowInShowChallengeJudges.AddOrUpdate(x => x.ID,
                new ShowInShowChallengeJudge() { ID = 1, DogShow = firstShow, ShowChallenge = bis, Judge = dale},
                new ShowInShowChallengeJudge() { ID = 2, DogShow = firstShow, ShowChallenge = bpis, Judge = dale },
                new ShowInShowChallengeJudge() { ID = 3, DogShow = firstShow, ShowChallenge = bjis, Judge = dale },
                new ShowInShowChallengeJudge() { ID = 4, DogShow = firstShow, ShowChallenge = bvis, Judge = dale },
                new ShowInShowChallengeJudge() { ID = 5, DogShow = firstShow, ShowChallenge = bbpis, Judge = dale },
                new ShowInShowChallengeJudge() { ID = 6, DogShow = firstShow, ShowChallenge = bnis, Judge = dale },
                new ShowInShowChallengeJudge() { ID = 7, DogShow = secondShow, ShowChallenge = bis, Judge = nickyRobertson },
                new ShowInShowChallengeJudge() { ID = 8, DogShow = secondShow, ShowChallenge = bpis, Judge = nickyRobertson },
                new ShowInShowChallengeJudge() { ID = 9, DogShow = secondShow, ShowChallenge = bjis, Judge = nickyRobertson },
                new ShowInShowChallengeJudge() { ID = 10, DogShow = secondShow, ShowChallenge = bvis, Judge = nickyRobertson },
                new ShowInShowChallengeJudge() { ID = 11, DogShow = secondShow, ShowChallenge = bbpis, Judge = nickyRobertson },
                new ShowInShowChallengeJudge() { ID = 12, DogShow = secondShow, ShowChallenge = bnis, Judge = nickyRobertson }
            );

            var childHandlerClass = context.HandlerClasses.Where(c => c.Name == "Child").First();
            var juniorHandlerClass = context.HandlerClasses.Where(c => c.Name == "Junior").First();

            context.ShowHandlerClassJudges.AddOrUpdate(x => x.ID,
                new ShowHandlerClassJudge() { ID = 1, DogShow = firstShow, HandlerClass = childHandlerClass, Judge = lizRaubenheimer },
                new ShowHandlerClassJudge() { ID = 2, DogShow = firstShow, HandlerClass = juniorHandlerClass, Judge = lizRaubenheimer },
                new ShowHandlerClassJudge() { ID = 3, DogShow = secondShow, HandlerClass = childHandlerClass, Judge = ian },
                new ShowHandlerClassJudge() { ID = 4, DogShow = secondShow, HandlerClass = juniorHandlerClass, Judge = ian }
                );
        }
    }
}
