﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThAmCo.Profile.Interfaces;
using ThAmCo.Profile.Models.Profile;

namespace ThAmCo.Profile.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileController(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        [HttpPost]
        public async Task<ActionResult> AddProfile(ProfileDto profile)
        {
            await _profileRepository.AddProfile(profile);

            return Ok();
        }
    }
}
