using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace QtasHelpDesk.ViewModels.Content
{
    public class GroupViewModel 
    {
        public GroupViewModel()
        {
            AvaiableGroup = new List<SelectListItem>();
            SubGroups = new List<GroupViewModel>();
        }
        
        public int  Id { get; set; }

        [Required(ErrorMessage = "وارد کردن عنوان ضروری است")]
        [DisplayName("عنوان")]
        public string Title { get; set; }


        public long? ParentId { get; set; }

        [Required(ErrorMessage = "وارد کردن الویت ضروری است")]
        [DisplayName("اولویت")]
        public int Priority { get; set; }

        [DisplayName("شرح")]
        public string Description { get; set; }

        [DisplayName("آیا خصوصصی باشد")]
        public bool IsPrivate { get; set; }


        public List<SelectListItem> AvaiableGroup { get; set; }

        public int? PictureId { get; set; }

        [DisplayName("عنوان")]
        public string BreadCrumbName { get; set; }

        public List<GroupViewModel> SubGroups { get; set; }


    }
}
