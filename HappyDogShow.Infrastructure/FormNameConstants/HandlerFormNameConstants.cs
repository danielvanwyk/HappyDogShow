using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Infrastructure.FormNameConstants
{
    public class HandlerFormNameConstants
    {
        public static class Handlers
        {
            public static class HandlersList
            {
                public static string ViewName = "HandlersList";
            }
            public static class NewHandler
            {
                public static string ViewName = "NewHandler";
            }
            public static class EditHandler
            {
                public static string ViewName = "EditHandler";
            }
        }

        public static class HandlerEntries
        {
            public static class EntriesList
            {
                public static string ViewName = "HandlerEntriesList";
            }
            public static class MultipleNewEntry
            {
                public static string ViewName = "MultipleNewHandlerEntry";
            }
            public static class EditEntry
            {
                public static string ViewName = "EditHandlerEntry";
            }
        }
    }
}
