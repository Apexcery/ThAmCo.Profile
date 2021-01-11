using System;
using System.Threading.Tasks;
using ThAmCo.Profile.Models.Profile;

namespace ThAmCo.Profile.Interfaces
{
    public interface IProfileRepository
    {
        public Task AddProfile(ProfileDto profile);
        public Task RemoveProfile(Guid profileId);
        public Task UpdateProfile(ProfileDto profile);
    }
}
