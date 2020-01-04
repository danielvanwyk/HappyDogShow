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

        private string regisrationnumber;
        [Required]
        public string RegisrationNumber
        {
            get { return regisrationnumber; }
            set { SetProperty(ref regisrationnumber, value); }
        }

        private int genderId;
        public int GenderId
        {
            get { return genderId; }
            set { SetProperty(ref genderId, value); }
        }

        public string GenderName { get; set; }

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

        private int breedId;
        public int BreedId
        {
            get { return breedId; }
            set { SetProperty(ref breedId, value); }
        }

        public string BreedName { get; set; }

        private string registeredname;
        [Required]
        public string RegisteredName
        {
            get { return registeredname; }
            set { SetProperty(ref registeredname, value); }
        }

        private string qualifications;
        public string Qualifications
        {
            get { return qualifications; }
            set { SetProperty(ref qualifications, value); }
        }

        private string chiportattoonumber;
        [Required]
        public string ChipOrTattooNumber
        {
            get { return chiportattoonumber; }
            set { SetProperty(ref chiportattoonumber, value); }
        }

        private string sire;
        [Required]
        public string Sire
        {
            get { return sire; }
            set { SetProperty(ref sire, value); }
        }

        private string dam;
        [Required]
        public string Dam
        {
            get { return dam; }
            set { SetProperty(ref dam, value); }
        }

        private string bredby;
        [Required]
        public string BredBy
        {
            get { return bredby; }
            set { SetProperty(ref bredby, value); }
        }

        private string colour;
        [Required]
        public string Colour
        {
            get { return colour; }
            set { SetProperty(ref colour, value); }
        }

        private string registeredownersurname;
        public string RegisteredOwnerSurname
        {
            get { return registeredownersurname; }
            set { SetProperty(ref registeredownersurname, value); }
        }

        private string registeredownertitle;
        public string RegisteredOwnerTitle
        {
            get { return registeredownertitle; }
            set { SetProperty(ref registeredownertitle, value); }
        }

        private string registeredownerinitials;
        public string RegisteredOwnerInitials
        {
            get { return registeredownerinitials; }
            set { SetProperty(ref registeredownerinitials, value); }
        }

        private string registeredowneraddress;
        public string RegisteredOwnerAddress
        {
            get { return registeredowneraddress; }
            set { SetProperty(ref registeredowneraddress, value); }
        }

        private string registeredownerpostalcode;
        public string RegisteredOwnerPostalCode
        {
            get { return registeredownerpostalcode; }
            set { SetProperty(ref registeredownerpostalcode, value); }
        }

        private string registeredownerkusano;
        public string RegisteredOwnerKUSANo
        {
            get { return registeredownerkusano; }
            set { SetProperty(ref registeredownerkusano, value); }
        }

        private string registeredownertel;
        public string RegisteredOwnerTel
        {
            get { return registeredownertel; }
            set { SetProperty(ref registeredownertel, value); }
        }

        private string registeredownercell;
        public string RegisteredOwnerCell
        {
            get { return registeredownercell; }
            set { SetProperty(ref registeredownercell, value); }
        }

        private string registeredownerfax;
        public string RegisteredOwnerFax
        {
            get { return registeredownerfax; }
            set { SetProperty(ref registeredownerfax, value); }
        }

        private string registeredowneremail;
        public string RegisteredOwnerEmail
        {
            get { return registeredowneremail; }
            set { SetProperty(ref registeredowneremail, value); }
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
