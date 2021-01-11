using System;
using System.Threading.Tasks;
using ThAmCo.Profile.Interfaces;
using ThAmCo.Profile.Models.Profile;

namespace ThAmCo.Profile.Repositories
{
    public class MockProfileRepository : IProfileRepository
    {
        public Task AddProfile(ProfileDto profile)
        {
            throw new NotImplementedException();
        }

        public Task RemoveProfile(Guid profileId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProfile(ProfileDto profile)
        {
            throw new NotImplementedException();
        }
    }
}
