using HappyDogShow.Infrastructure.Models;
using HappyDogShow.Services.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.SharedModels
{
    public class DogRegistrationDetail : ValidatableBindableBase, IDogRegistration
    {
        public int Id { get; set; }

        private string regisrationnumber;
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
            set { SetProperty(ref dateofbirth, value); }
        }

        public string DOB
        {
            get { return DateOfBirth.ToString("yyyy-MM-dd"); }
        }

        private int breedId;
        public int BreedId
        {
            get { return breedId; }
            set { SetProperty(ref breedId, value); }
        }

        public string BreedName { get; set; }

        private string registeredname;
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
        public string ChipOrTattooNumber
        {
            get { return chiportattoonumber; }
            set { SetProperty(ref chiportattoonumber, value); }
        }

        private string sire;
        public string Sire
        {
            get { return sire; }
            set { SetProperty(ref sire, value); }
        }

        private string dam;
        public string Dam
        {
            get { return dam; }
            set { SetProperty(ref dam, value); }
        }

        private string bredby;
        public string BredBy
        {
            get { return bredby; }
            set { SetProperty(ref bredby, value); }
        }

        private string colour;
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



    }
}
