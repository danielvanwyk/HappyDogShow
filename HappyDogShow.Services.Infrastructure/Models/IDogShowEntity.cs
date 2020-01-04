using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Services.Infrastructure.Models
{
    public interface IDogShowEntity : IEntityWithID
    {
        string DogShowName { get; set; }
        DateTime ShowDate { get; set; }
        string Venue { get; set; }
    }
}
