using HappyDogShow.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.SharedModels
{
    public class HandlerRegistrationDetail : ValidatableBindableBase, IHandlerRegistration
    {
        public int Id { get; set; }

        private int sexId;
        public int SexId
        {
            get { return sexId; }
            set { SetProperty(ref sexId, value); }
        }

        public string SexName { get; set; }

        private DateTime dateofbirth;
        public DateTime DateOfBirth
        {
            get { return dateofbirth; }
            set
            {
                SetProperty(ref dateofbirth, value);
                OnPropertyChanged("DOBYear");
                OnPropertyChanged("DOBMonth");
                OnPropertyChanged("DOBDay");
            }
        }

        public string DOB
        {
            get { return DateOfBirth.ToString("yyyy-MM-dd"); }
        }

        private string dobYear;
        [Required]
        public string DOBYear
        {
            get
            {
                if ((dateofbirth.Year > 1) && (dateofbirth.Year.ToString() != dobYear))
                    dobYear = dateofbirth.Year.ToString();

                return dobYear;
            }
            set
            {
                dobYear = value;
                UpdateDOB();
            }
        }

        private string dobMonth;
        [Required]
        public string DOBMonth
        {
            get
            {
                if ((dateofbirth.Month > 1) && (dateofbirth.Month.ToString() != dobMonth))
                    dobMonth = dateofbirth.Month.ToString();

                return dobMonth;
            }
            set
            {
                dobMonth = value;
                UpdateDOB();
            }
        }
        private string dobDay;
        [Required]
        public string DOBDay
        {
            get
            {
                if ((dateofbirth.Day > 1) && (dateofbirth.Day.ToString() != dobDay))
                    dobDay = dateofbirth.Day.ToString();

                return dobDay;
            }
            set
            {
                dobDay = value;
                UpdateDOB();
            }
        }


        private string surname;
        [Required]
        public string Surname
        {
            get { return surname; }
            set { SetProperty(ref surname, value); }
        }

        private string title;
        [Required]
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private string firstName;
        [Required]
        public string FirstName
        {
            get { return firstName; }
            set { SetProperty(ref firstName, value); }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set { SetProperty(ref address, value); }
        }

        private string postalcode;
        public string PostalCode
        {
            get { return postalcode; }
            set { SetProperty(ref postalcode, value); }
        }

        private string tel;
        public string Tel
        {
            get { return tel; }
            set { SetProperty(ref tel, value); }
        }

        private string cell;
        public string Cell
        {
            get { return cell; }
            set { SetProperty(ref cell, value); }
        }

        private string fax;
        public string Fax
        {
            get { return fax; }
            set { SetProperty(ref fax, value); }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }


        private void UpdateDOB()
        {
            try
            {
                DateOfBirth = new DateTime(int.Parse(dobYear), int.Parse(dobMonth), int.Parse(dobDay));
            }
            catch
            {

            }
        }


    }
}
