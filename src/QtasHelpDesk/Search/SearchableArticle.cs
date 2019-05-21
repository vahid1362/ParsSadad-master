using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QtasHelpDesk.ViewModels.Content;

namespace QtasHelpDesk.Search
{
    public class SearchableArticle : Searchable
    {
       

        public SearchableArticle(PostViewModel post)
        {
            var descriptionPath = $"Pages/Articles/Intro{post.Id}";
            DescriptionPath = descriptionPath;
             Id = post.Id;
            Title = post.Title;
        }

        public override string Description { get; }
        public override string DescriptionPath { get; }
        public override string Href { get; }
        public override int Id { get; }
        public override string Title { get; }
    }
}
