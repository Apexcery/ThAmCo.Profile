using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThAmCo.Profile.Models.Profile;
using ThAmCo.Profile.ViewModels;

namespace ThAmCo.Profile.Interfaces
{
    public interface IProfileRepository
    {
        public Task<IList<ProfileViewModel>> GetProfiles();
        public Task<ProfileViewModel> GetProfile(Guid id);
        public Task AddProfile(ProfileDto profile);
        public Task RemoveProfile(Guid profileId);
        public Task<ProfileViewModel> UpdateProfile(ProfileDto profile);
    }
}
