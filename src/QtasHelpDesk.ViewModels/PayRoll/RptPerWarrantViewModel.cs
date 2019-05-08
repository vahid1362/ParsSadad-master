using System;
using System.Collections.Generic;
using System.Text;

namespace QtasHelpDesk.ViewModels.PayRoll
{
    /// <summary> گزارش حکم کارگزینی </summary>
  
    public class RptPerWarrantDto
    {
        public RptPerWarrantDto()
        {
            SalaryParamNameDtos = new List<SalaryParamNameDto>();
            PerWarrantInfoDtos = new List<PerWarrantInfoDto>();
        }

        /// <summary> شرح پارامترهای حقوق </summary>
     
        public List<SalaryParamNameDto> SalaryParamNameDtos { get; set; }

        /// <summary> اطلاعات حکم کارکنان </summary>
       
        public List<PerWarrantInfoDto> PerWarrantInfoDtos { get; set; }
    }
}
