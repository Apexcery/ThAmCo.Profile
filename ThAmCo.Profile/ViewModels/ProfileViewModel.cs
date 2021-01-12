using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThAmCo.Profile.ViewModels
{
    public class ProfileViewModel
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public IList<ProfileAddressViewModel> Addresses { get; set; }
    }

    public class ProfileAddressViewModel
    {
        public Guid Id { get; set; }

        public string AddressLine1 { get; set; }

        public string Postcode { get; set; }

        public string TownCity { get; set; }
    }
}
