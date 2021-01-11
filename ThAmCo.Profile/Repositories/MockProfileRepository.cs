using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThAmCo.Profile.Interfaces;
using ThAmCo.Profile.Models.Profile;
using ThAmCo.Profile.ViewModels;

namespace ThAmCo.Profile.Repositories
{
    public class MockProfileRepository : IProfileRepository
    {
        public Task<IList<ProfileViewModel>> GetProfiles()
        {
            throw new NotImplementedException();
        }

        public Task<ProfileViewModel> GetProfile(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task AddProfile(ProfileDto profile)
        {
            throw new NotImplementedException();
        }

        public Task RemoveProfile(Guid profileId)
        {
            throw new NotImplementedException();
        }

        public Task<ProfileViewModel> UpdateProfile(ProfileDto profile)
        {
            throw new NotImplementedException();
        }
    }
}
