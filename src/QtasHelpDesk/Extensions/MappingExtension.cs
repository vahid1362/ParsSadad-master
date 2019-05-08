using AutoMapper;
using QtasHelpDesk.Domain.Content;
using QtasHelpDesk.Domain.Identity;
using QtasHelpDesk.Domain.Media;
using QtasHelpDesk.ViewModels.Content;
using QtasHelpDesk.ViewModels.Identity;
using QtasHelpDesk.ViewModels.Media;

namespace QtasHelpDesk.Extensions
{
    public class MappingExtension : Profile
    {

        public MappingExtension()
        {
            #region User
            CreateMap<User, UserViewModel>().ForMember(des => des.Image, opt => opt.MapFrom(src => src.Picture.BinaryData));
            CreateMap<UserViewModel, User>();
            CreateMap<RegisterUserViewModel, User>();
            CreateMap<User, RegisterUserViewModel>();

            #endregion

            #region Media
            CreateMap<GalleryViewModel, Gallery>();
            CreateMap<Gallery, GalleryViewModel>();


            //CreateMap<GalleryPictureViewModel, GalleryPicture>();
            //CreateMap<GalleryPicture, GalleryPictureViewModel>();

            #endregion

            #region Content

            CreateMap<Group, GroupViewModel>();
            CreateMap<GroupViewModel, Group>();

            #endregion


        }
    }
}
