using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ThAmCo.Profile.Interfaces;
using ThAmCo.Profile.Models.Profile;
using ThAmCo.Profile.ViewModels;

namespace ThAmCo.Profile.Repositories
{
    public class MockProfileRepository : IProfileRepository
    {
        private readonly IMapper _mapper;

        public static List<ProfileDto> Profiles = new List<ProfileDto>();

        public MockProfileRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IList<ProfileViewModel>> GetProfiles()
        {
            var mappedProfiles = Profiles.Select(p => _mapper.Map<ProfileViewModel>(p)).ToList();
            return mappedProfiles;
        }

        public async Task<ProfileViewModel> GetProfile(Guid id)
        {
            var profile = Profiles.FirstOrDefault(x => x.Id == id);
            if (profile == null)
                return null;

            return _mapper.Map<ProfileViewModel>(profile);
        }

        public async Task AddProfile(ProfileDto profile)
        {
            Profiles.Add(profile);
        }

        public async Task RemoveProfile(Guid profileId)
        {
            var profile = Profiles.FirstOrDefault(x => x.Id == profileId);
            if (profile != null)
                Profiles.Remove(profile);
        }

        public async Task<ProfileViewModel> UpdateProfile(ProfileDto profile)
        {
            var profileToUpdate = Profiles.FirstOrDefault(x => x.Id == profile.Id);
            if (profileToUpdate == null)
                return null;

            if (profile.Username != null && profileToUpdate.Username != profile.Username)
                profileToUpdate.Username = profile.Username;

            if (profile.Email != null && profileToUpdate.Email != profile.Email)
                profileToUpdate.Email = profile.Email;

            if (profile.Forename != null && profileToUpdate.Forename != profile.Forename)
                profileToUpdate.Forename = profile.Forename;

            if (profile.Surname != null && profileToUpdate.Surname != profile.Surname)
                profileToUpdate.Surname = profile.Surname;

            var mappedProfile = _mapper.Map<ProfileViewModel>(profile);

            return mappedProfile;
        }
    }
}
