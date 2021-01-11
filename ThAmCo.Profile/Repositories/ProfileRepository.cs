using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThAmCo.Profile.Data;
using ThAmCo.Profile.Data.Entities;
using ThAmCo.Profile.Interfaces;
using ThAmCo.Profile.Models.Profile;

namespace ThAmCo.Profile.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly ProfileDbContext _context;

        public ProfileRepository(ProfileDbContext context)
        {
            _context = context;
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

        public async Task UpdateProfile(ProfileDto profile)
        {
            var profileToUpdate = await _context.Profiles.FindAsync(profile.Id);
            if (profileToUpdate == null)
                return;

            if (profile.Username != null && profileToUpdate.Username != profile.Username)
                profileToUpdate.Username = profile.Username;

            if (profile.Email != null && profileToUpdate.Email != profile.Email)
                profileToUpdate.Email = profile.Email;

            if (profile.Forename != null && profileToUpdate.Forename != profile.Forename)
                profileToUpdate.Forename = profile.Forename;

            if (profile.Surname != null && profileToUpdate.Surname != profile.Surname)
                profileToUpdate.Surname = profile.Surname;

            await _context.SaveChangesAsync();
        }
    }
}
