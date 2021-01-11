using ThAmCo.Profile.Data.Entities;
using ThAmCo.Profile.ViewModels;

namespace ThAmCo.Profile.Mapper
{
    public class ProfileMapper : AutoMapper.Profile
    {
        public ProfileMapper()
        {
            CreateMap<ProfileEntity, ProfileViewModel>();
        }
    }
}
