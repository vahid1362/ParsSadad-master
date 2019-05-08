using System;
using System.Runtime.Serialization;

namespace QtasHelpDesk.ViewModels.PayRoll
{
  public  class PerWarrantInfoDto
    {
        /// <summary>  محل خدمت </summary>
        [DataMember]
        public string OrganArea { get; set; }
        /// <summary> کدپرسنلی </summary>
        [DataMember]
        public int PerCode { get; set; }
        /// <summary> شماره شناسنامه کارمند </summary>
        [DataMember]
        public string CertificationId { get; set; }
        /// <summary> کد ملی کارمند </summary>
        [DataMember]
        public string NationalId { get; set; }
        /// <summary> نام پرسنل </summary>
        [DataMember]
        public string FullName { get; set; }
        /// <summary> تاریخ تولد </summary>
        [DataMember]
        public int BirthDate { get; set; }
        /// <summary> محل تولد </summary>
        [DataMember]
        public string BirthLocation { get; set; }
        /// <summary> محل صدور </summary>
        [DataMember]
        public string SodorLocation { get; set; }

        /// <summary> وضعیت تاهل </summary>
        [DataMember]
        public string MarryStatusStr { get; set; }

        /// <summary> نوع استخدام </summary>
        [DataMember]
        public string EmployeeTypeStr { get; set; }
        /// <summary> نوع حکم </summary>
        [DataMember]
        public string WarrantTypeStr { get; set; }
        /// <summary> تاریخ اجرا حکم </summary>
        [DataMember]
        public int WarrantExecuteDate { get; set; }
        
        /// <summary> امتیاز تجربه </summary>
        [DataMember]
        public string PerPoint { get; set; }
        /// <summary> سابقه مفید-سال </summary>
        [DataMember]
        public Nullable<int> DutyYear { get; set; }
        /// <summary> سابقه مفید-ماه </summary>
        [DataMember]
        public Nullable<int> DutyMonth { get; set; }
        /// <summary> سابقه مفید-روز </summary>
        [DataMember]
        public Nullable<int> DutyDay { get; set; }
        /// <summary> سابقه بیمه-سال </summary>
        [DataMember]
        public Nullable<int> BimehYear { get; set; }
        /// <summary> سابقه بیمه-ماه </summary>
        [DataMember]
        public Nullable<int> BimehMonth { get; set; }
        /// <summary> سابقه بیمه-روز </summary>
        [DataMember]
        public Nullable<int> BimehDay { get; set; }

        //تحصیلات
        /// <summary> مقطع تحصیلی </summary>
        [DataMember]
        public string EduLevelDesc { get; set; }
        /// <summary> رشته تحصیلی </summary>
        [DataMember]
        public string EduCourse { get; set; }
        /// <summary> تاریخ پایان مقطع تحصیلی </summary>
        [DataMember]
        public int EduEndDate { get; set; }

        // کد شغلی و گروه
        /// <summary> رتبه </summary>
        [DataMember]
        public int Rank { get; set; }
        /// <summary> شغل </summary>
        [DataMember]
        public string JobDesc { get; set; }
        /// <summary> گروه شغلی </summary>
        [DataMember]
        public int JobGroup { get; set; }

        /// <summary> شماره دبیرخانه حکم </summary>
        [DataMember]
        public string DabirNo { get; set; }

        /// <summary> تاریخ صدور حکم </summary>
        [DataMember]
        public Nullable<int> SodorDate { get; set; }

        /// <summary> شرح کامل حکم </summary>
        [DataMember]
        public string WarrantCompletedDescription { get; set; }

        /// <summary> جمع حقوق و مزایای حکم به حروف </summary>
        [DataMember]
        public string SumWarrantParamToWord { get; set; }

        /// <summary> جمع حقوق و مزایای حکم به عدد </summary>
        [DataMember]
        public decimal SumWarrantParamToNumber { get; set; }

        //پارامترهای حکم
        /// <summary> حقوق پایه - مقدار پارامتر </summary>
        [DataMember]
        public decimal Param1Amount { get; set; }
        /// <summary> حق سنوات - مقدار پارامتر  </summary>
        [DataMember]
        public decimal Param2Amount { get; set; }
        /// <summary> فوق العاده شغل - مقدار پارامتر  </summary>
        [DataMember]
        public decimal Param3Amount { get; set; }
        /// <summary> حق التضمین - مقدار پارامتر  </summary>
        [DataMember]
        public decimal Param4Amount { get; set; }
        /// <summary> فوق العاده جذب - مقدار پارامتر  </summary>
        [DataMember]
        public decimal Param5Amount { get; set; }
        /// <summary> حق عائله مندی - مقدار پارامتر  </summary>
        [DataMember]
        public decimal Param6Amount { get; set; }
        /// <summary> حق خواوربار - مقدار پارامتر  </summary>
        [DataMember]
        public decimal Param7Amount { get; set; }
        /// <summary> حق مسکن - مقدار پارامتر  </summary>
        [DataMember]
        public decimal Param8Amount { get; set; }
        /// <summary> حق مهد کودک - مقدار پارامتر  </summary>
        [DataMember]
        public decimal Param9Amount { get; set; }
        /// <summary> فوق العاده سنوات - مقدار پارامتر  </summary>
        [DataMember]
        public decimal Param10Amount { get; set; }
        /// <summary> حق پایه وری - مقدار پارامتر  </summary>
        [DataMember]
        public decimal Param11Amount { get; set; }
        /// <summary> هزینه تردد - مقدار پارامتر  </summary>
        [DataMember]
        public decimal Param12Amount { get; set; }
        /// <summary> سختی کار - مقدار پارامتر  </summary>
        [DataMember]
        public decimal Param13Amount { get; set; }
        /// <summary> تفاوت تطبیق - مقدار پارامتر  </summary>
        [DataMember]
        public decimal Param14Amount { get; set; }
        /// <summary> آب و هوا  - مقدار پارامتر </summary>
        [DataMember]
        public decimal Param15Amount { get; set; }
        /// <summary> فوق العاده پایه تشویقی - مقدار پارامتر  </summary>
        [DataMember]
        public decimal Param16Amount { get; set; }

        /// <summary> فوق العاده پایه رزمندگی- مقدار پارامتر  </summary>
        [DataMember]
        public decimal Param17Amount { get; set; }

        /// <summary> رتبه - مقدار پارامتر  </summary>
        [DataMember]
        public decimal Param18Amount { get; set; }

        /// <summary> تشویقی - مقدار پارامتر  </summary>
        [DataMember]
        public decimal Param19Amount { get; set; }
    }
}
