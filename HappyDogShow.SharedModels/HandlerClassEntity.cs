using HappyDogShow.Services.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.SharedModels
{
    public class HandlerClassEntity : IHandlerClassEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
    }
}
