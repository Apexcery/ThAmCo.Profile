using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Profile.Data;
using ThAmCo.Profile.Data.Entities;
using ThAmCo.Profile.Interfaces;
using ThAmCo.Profile.Models.Profile;
using ThAmCo.Profile.ViewModels;

namespace ThAmCo.Profile.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly ProfileDbContext _context;
        private readonly IMapper _mapper;

        public ProfileRepository(ProfileDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<ProfileViewModel>> GetProfiles()
        {
            var profiles = await _context.Profiles.Include(x => x.Addresses).ToListAsync();

            var mappedProfiles = profiles.Select(p => _mapper.Map<ProfileViewModel>(p)).ToList();

            return mappedProfiles;
        }

        public async Task<ProfileViewModel> GetProfile(Guid id)
        {
            var profile = await _context.Profiles.Include(x => x.Addresses).FirstOrDefaultAsync(x => x.Id == id);

            if (profile == null)
                return null;

            var mappedProfile = _mapper.Map<ProfileViewModel>(profile);

            return mappedProfile;
        }

        public async Task AddProfile(ProfileDto profile)
        {
            var newProfile = new ProfileEntity
            {
                Id = profile.Id,
                Username = profile.Username,
                Email = profile.Email,
                Forename = profile.Forename,
                Surname = profile.Surname
            };

            await _context.Profiles.AddAsync(newProfile);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveProfile(Guid profileId)
        {
            var profileToRemove = await _context.Profiles.FindAsync(profileId);
            if (profileToRemove == null)
                return;

            _context.Profiles.Remove(profileToRemove);
            await _context.SaveChangesAsync();
        }

        public async Task<ProfileViewModel> UpdateProfile(ProfileDto profile)
        {
            var profileToUpdate = await _context.Profiles.FindAsync(profile.Id);
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

            await _context.SaveChangesAsync();

            var mappedProfile = _mapper.Map<ProfileViewModel>(profileToUpdate);

            return mappedProfile;
        }
    }
}
