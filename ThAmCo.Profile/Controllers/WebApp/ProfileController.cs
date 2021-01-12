using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ThAmCo.Profile.Data;
using ThAmCo.Profile.Data.Entities;
using ThAmCo.Profile.Interfaces;
using ThAmCo.Profile.Models.Profile;

namespace ThAmCo.Profile.Controllers.WebApp
{
    public class ProfileController : Controller
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IAccountsService _accountsService;
        private readonly IConfiguration _config;

        public ProfileController(ProfileDbContext context, IProfileRepository profileRepository, IAccountsService accountsService, IConfiguration config)
        {
            _profileRepository = profileRepository;
            _accountsService = accountsService;
            _config = config;
        }

        // GET: Profile
        public async Task<IActionResult> Index()
        {
            var isCookieStored = Request.Cookies.TryGetValue("access_token", out var accessToken);
            if (!isCookieStored)
                return Redirect($"{_config["AppSettings:Endpoints:AccountsEndpoint"]}/Auth");

            var currentId = await _accountsService.GetCurrentAccountId(accessToken);
            if (currentId == null)
                return Redirect($"{_config["AppSettings:Endpoints:AccountsEndpoint"]}/Auth");

            var profile = await _profileRepository.GetProfile(Guid.Parse(currentId));

            return View(profile);
        }

        // GET: Profile/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            var isCookieStored = Request.Cookies.TryGetValue("access_token", out _);
            if (!isCookieStored)
                return Redirect($"{_config["AppSettings:Endpoints:AccountsEndpoint"]}/Auth");

            if (id == null)
            {
                return NotFound();
            }

            var profile = await _profileRepository.GetProfile((Guid) id);
            if (profile == null)
            {
                return NotFound(id);
            }

            return View(profile);
        }

        // GET: Profile/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            var isCookieStored = Request.Cookies.TryGetValue("access_token", out _);
            if (!isCookieStored)
                return Redirect($"{_config["AppSettings:Endpoints:AccountsEndpoint"]}/Auth");

            if (id == null)
            {
                return NotFound();
            }

            var profile = await _profileRepository.GetProfile((Guid) id);
            if (profile == null)
            {
                return NotFound();
            }
            return View(profile);
        }

        // POST: Profile/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Username,Email,Forename,Surname")] ProfileEntity profileEntity)
        {
            var isCookieStored = Request.Cookies.TryGetValue("access_token", out _);
            if (!isCookieStored)
                return Redirect($"{_config["AppSettings:Endpoints:AccountsEndpoint"]}/Auth");

            if (id != profileEntity.Id)
            {
                return NotFound();
            }

            var updateProfile = new ProfileDto
            {
                Id = profileEntity.Id,
                Username = profileEntity.Username,
                Email = profileEntity.Email,
                Forename = profileEntity.Forename,
                Surname = profileEntity.Surname
            };

            var updatedProfile = await _profileRepository.UpdateProfile(updateProfile);

            return View(updatedProfile);
        }
    }
}
