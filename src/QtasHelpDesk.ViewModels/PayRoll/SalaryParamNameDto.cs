using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace QtasHelpDesk.ViewModels.PayRoll
{
    /// <summary> شناسه و نام پارامتر گزارش حقوق </summary>
    [DataContract]
    public class SalaryParamNameDto
    {
        /// <summary> شمارنده  </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary> شرح پارامتر </summary>
        [DataMember]
        public string ParamDesc { get; set; }

        /// <summary> شناسه پارامتر  </summary>
        [DataMember]
        public int ParamCode { get; set; }
    }
}
