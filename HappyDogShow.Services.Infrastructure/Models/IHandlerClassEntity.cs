﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Models
{
    public interface IHandlerClassEntity : IEntityWithID
    {
        string Name { get; set; }
        string Description { get; set; }
    }
}
