using System.Collections.Generic;

namespace ThAmCo.Profile.Models
{
    public class Account
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public IList<string> Roles { get; set; }
    }
}
