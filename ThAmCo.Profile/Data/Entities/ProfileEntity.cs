using System;
using System.Collections.Generic;

namespace ThAmCo.Profile.Data.Entities
{
    public class ProfileEntity
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public IList<ProfileAddress> Addresses { get; set; }
    }

    public class ProfileAddress
    {
        public Guid Id { get; set; }

        public string AddressLine1 { get; set; }

        public string Postcode { get; set; }

        public string TownCity { get; set; }
    }
}
