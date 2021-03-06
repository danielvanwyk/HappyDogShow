﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Entries
{
    public class FormNameConstants
    {
        public static class Entries
        {
            public static class EntriesList
            {
                public static string ViewName = "EntriesList";
            }
            public static class EntriesByClassList
            {
                public static string ViewName = "EntriesByClassList";
            }
            public static class NewEntry
            {
                public static string ViewName = "NewEntry";
            }
            public static class MultipleNewEntry
            {
                public static string ViewName = "MultipleNewEntry";
            }
            public static class EditEntry
            {
                public static string ViewName = "EditEntry";
            }
        }

        public static class BreedEntryResults
        {
            public static class CaptureResults
            {
                public static string ViewName = "CaptureBreedEntryResults";
            }
        }

        public static class Results
        {
            public static class Breed
            {
                public static string ViewName = "ViewOrCaptureBreedResults";
            }
            public static class BreedGroup
            {
                public static string ViewName = "ViewOrCaptureBreedGroupResults";
            }
            public static class InShow
            {
                public static string ViewName = "ViewOrCaptureInShowResults";
            }
            public static class Handler
            {
                public static string ViewName = "ViewOrCaptureHandlerResults";
            }
        }
    }
}
