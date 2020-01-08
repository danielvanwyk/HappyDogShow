using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Data
{
    public class ShowHandlerClassJudge
    {
        public int ID { get; set; }
        public DogShow DogShow { get; set; }
        public HandlerClass HandlerClass { get; set; }
        public Judge Judge { get; set; }
    }
}
