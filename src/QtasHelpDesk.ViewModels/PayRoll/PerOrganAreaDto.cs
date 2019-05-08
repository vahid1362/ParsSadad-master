using System;
using System.Collections.Generic;
using System.Text;

namespace QtasHelpDesk.ViewModels.PayRoll
{
  public  class PerOrganAreaDto
    {
        /// <summary> کد پرسنلی  </summary>

        public int PerCode { get; set; }

        /// <summary> نام  </summary>
  
        public string FirstName { get; set; }

        /// <summary> نام خانوادگی  </summary>

        public string LastName { get; set; }

        /// <summary> کد محل خدمت  </summary>
 
        public int OrganAreaCode { get; set; }

        /// <summary> نام محل خدمت  </summary>
      
        public string OrganAreaName { get; set; }
    }
}
