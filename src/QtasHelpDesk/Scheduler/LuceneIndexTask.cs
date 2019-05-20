using DNTScheduler.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using QtasHelpDesk.Services.Contracts.Content;

namespace QtasHelpDesk
{
    public class LuceneIndexTask : IScheduledTask
    {
        #region Feild

        private readonly IPostService _postService;
        private readonly IHostingEnvironment _hostingEnvironment;
        #endregion
        public LuceneIndexTask(IPostService postService, IHostingEnvironment hostingEnvironment)
        {
            _postService = postService;
            _hostingEnvironment = hostingEnvironment;
        }
        public bool IsShuttingDown { get; set; }

        public async Task RunAsync()
        {
            if (this.IsShuttingDown)
            {
                return;
            }

            var postViewModels = _postService.GetPosts();
            var createIdnex = new CreateIndex(_hostingEnvironment);
            createIdnex.CreateFullTextIndex(postViewModels);




        }
    }
}
