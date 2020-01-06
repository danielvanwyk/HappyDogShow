using HappyDogShow.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.SharedModels
{
    public class HandlerEntry : ValidatableBindableBase, IHandlerEntryEntity
    {
        public int Id { get; set; }

        private IDogRegistration dog;
        public IDogRegistration Dog
        {
            get { return dog; }
            set { SetProperty(ref dog, value); }
        }

        private IDogShowEntity dogShow;
        public IDogShowEntity DogShow
        {
            get { return dogShow; }
            set { SetProperty(ref dogShow, value); }
        }

        public IHandlerRegistration handler;
        public IHandlerRegistration Handler
        {
            get { return handler; }
            set { SetProperty(ref handler, value); }
        }
        public IHandlerClassEntity handlerClass;
        public IHandlerClassEntity Class
        {
            get { return handlerClass; }
            set { SetProperty(ref handlerClass, value); }
        }
        private string number;
        public string Number
        {
            get
            {
                if (number == null)
                    return "";
                else
                    return number;
            }
            set
            {
                if (value == null)
                    SetProperty(ref number, "");
                else
                    SetProperty(ref number, value);
            }
        }
    }
}
