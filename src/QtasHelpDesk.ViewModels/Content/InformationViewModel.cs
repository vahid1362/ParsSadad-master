using System;
using System.Collections.Generic;
using System.Text;

namespace QtasHelpDesk.ViewModels.Content
{
   public class InformationViewModel
    {
        public InformationViewModel()
        {
            PostViewModels=new List<PostViewModel>();
            FaqViewModels=new List<FaqViewModel>();
        }

        public List<PostViewModel> PostViewModels { get; set; }

        public List<FaqViewModel> FaqViewModels { get; set; }
    }
}
