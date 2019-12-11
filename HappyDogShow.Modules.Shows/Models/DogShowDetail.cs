using HappyDogShow.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Modules.Shows.Models
{
    public class DogShowDetail : ValidatableBindableBase, IDogShowEntity
    {
        public int Id { get; set; }
        public string DogShowName { get; set; }
        public DateTime ShowDate { get; set; }

        public DogShowDetail()
        {
            DogShowName = "enter name please";
            ShowDate = DateTime.Now;
        }
    }
}
