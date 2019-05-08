﻿using System.Collections.Generic;
using QtasHelpDesk.Entities.Identity;
using DNTCommon.Web.Core;

namespace QtasHelpDesk.ViewModels.Identity
{
    public class DynamicRoleClaimsManagerViewModel
    {
        public string[] ActionIds { set; get; }

        public int RoleId { set; get; }

        public Role RoleIncludeRoleClaims { set; get; }

        public ICollection<MvcControllerViewModel> SecuredControllerActions { set; get; }
    }
}