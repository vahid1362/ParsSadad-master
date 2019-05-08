using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace QtasHelpDesk.ViewModels.Leave
{

    /// <summary>
    /// اطلاعات مرخصی
    /// </summary>
    [DataContract]
    public class PerMorakhasiDto
    {
        /// <summary>
        /// اطلاعات مرخصی
        /// </summary>
        [DataMember]
        public List<PerMorakhasiInfosDto> PerMorakhasiInfosDtos { get; set; } = new List<PerMorakhasiInfosDto>();

        /// <summary>
        /// خلاصه اطلاعات
        /// </summary>
        [DataMember]
        public PerMorakhasiSummaryDto PerMorakhasiSummaryDto { get; set; } = new PerMorakhasiSummaryDto();

     
        public  LeaveRequestViewModel RequestViewModel { get; set; }

    }

    public class PerMorakhasiInfosDto
    {
        /// <summary>
        /// لیست اعلام نظرات هر درخواست
        /// </summary>
        [DataMember]
        [Display(Name = "لیست اعلام نظرات هر درخواست")]
        public List<ConfirmRequestStateDto> ConfirmRequestStatusDtos { get; set; } = new List<ConfirmRequestStateDto>();

        /// <summary>
        /// شماره درخواست
        /// </summary>
        [DataMember]
        [Display(Name = "شماره درخواست")]
        public int RowNo { get; set; }

        /// <summary>
        /// کدسازمان
        /// </summary>
        [DataMember]
        [Display(Name = "کدسازمان")]
        public int OrganCode { get; set; }

        /// <summary>
        /// کدپرسنلی
        /// </summary>
        [DataMember]
        [Display(Name = "کدپرسنلی")]
        public int PerCode { get; set; }

        /// <summary>
        /// تاریخ شروع مرخصی
        /// </summary>
        [DataMember]
        [Display(Name = "تاریخ شروع مرخصی")]
        public int StartDate { get; set; }
        [Display(Name = "تاریخ شروع مرخصی")]
        public string StartDatestr => StartDate.ToString("####/##/##");

        /// <summary>
        /// نوع مرخصی
        /// </summary>
        [DataMember]
        [Display(Name = "شماره مرخصی")]
        public int MorakhasiType { get; set; }

        /// <summary>
        /// شرح نوع مرخصی
        /// </summary>
        [DataMember]
        [Display(Name = "نوع مرخصی")]
        public string MorakhasiTypeStr { get; set; }

        /// <summary>
        /// مدت مرخصی چه روز، چه دقیقه
        /// </summary>
        [DataMember]
        [Display(Name = "مدت مرخصی")]
        public int? Duration { get; set; }

        /// <summary>
        /// تاریخ پایان مرخصی
        /// </summary>
        [DataMember]
        [Display(Name = "تاریخ پایان مرخصی")]
        public int? EndDate { get; set; }

        /// <summary>
        /// تاریخ پایان مرخصی
        /// </summary>
        [DataMember]
        [Display(Name = "تاریخ پایان مرخصی")]
        public string EndDateStr => EndDate?.ToString("####/##/##");

        /// <summary>
        /// شرح مرخصی
        /// </summary>
        [DataMember]
        [Display(Name = "شرح مرخصی")]
        public string Description { get; set; }

        /// <summary>
        /// تاریخ ثبت
        /// </summary>
        [DataMember]
        [Display(Name = "تاریخ ثبت")]
        public int? RegDate { get; set; }

        /// <summary>
        /// شماره ثبت
        /// </summary>
        [DataMember]
        [Display(Name = "شماره ثبت")]
        public string RegNo { get; set; }

        /// <summary>
        /// کد پرسنلی جانشین
        /// </summary>
        [DataMember]
        [Display(Name = "کد پرسنلی جانشین")]
        public int? PerSub { get; set; }
        
        /// <summary>
        /// مدت به روز
        /// </summary>
        [DataMember]
        [Display(Name = "مدت به روز")]
        public int? DayLong { get; set; }

        /// <summary>
        /// ساعت شروع مرخصی ساعتی
        /// </summary>
        [DataMember]
        [Display(Name = "زمان شروع مرخصی ساعتی")]
        public string StartTime { get; set; }

        /// <summary>
        /// ساعت پایان مرخصی ساعتی
        /// </summary>
        [DataMember]
        [Display(Name = "زمان پایان مرخصی ساعتی")]
        public string EndTime { get; set; }

        /// <summary>
        /// مدت مرخصی ساعتی به دقیقه
        /// </summary>
        [DataMember]
        [Display(Name = "مدت مرخصی ساعتی")]
        public int? MinutLong { get; set; }

        /// <summary>
        /// آیا این درخواست حذف شده است؟
        /// </summary>
        [DataMember]
        [Display(Name = "درخواست های حذفی")]
        public bool? IsDeleted { get; set; }

        /// <summary>
        /// آخرین وضعیت درخواست
        /// </summary>
        [DataMember]
        [Display(Name = "آخرین وضعیت درخواست")]
        public int? RequestStatus { get; set; }

        /// <summary>
        /// شرح آخرین وضعیت درخواست
        /// </summary>
        [DataMember]
        [Display(Name = "آخرین وضعیت ")]
        public string RequestStatusStr { get; set; }
     
    }

    /// <summary>
    /// خلاصه اطلاعات مرخصی
    /// </summary>

    [DataContract]
    public class PerMorakhasiSummaryDto
    {
        /// <summary>
        /// ذخیره مرخصی استحقاقی سنوات گذشته
        /// </summary>
        [DataMember]
        public int LastYearSavePaidLeaveDays { get; set; }

        /// <summary>
        /// مرخصی استحقاقی استفاده شده امسال
        /// </summary>
        [DataMember]
        public int ThisYearPaidLeaveUsedDays { get; set; }

        /// <summary>
        /// مانده مرخصی استحقاقی امسال
        /// </summary>
        [DataMember]
        public int ThisYearPaidLeaveRemainDays { get; set; }

        /// <summary>
        /// جمع کل غیبت ها
        /// </summary>
        [DataMember]
        public int SumAbsenceDays { get; set; }

        /// <summary>
        /// جمع کل مرخصی های بدون حقوق
        /// </summary>
        [DataMember]
        public int SumNoSalaryLeaveDays { get; set; }

        /// <summary>
        /// جمع مرخصی های ساعتی امسال به روز
        /// </summary>
        [DataMember]
        public int ThisYearTimeLeaveSumDays { get; set; }

        /// <summary>
        ///مانده دقیقه مرخصی ساعتی از جمع مرخصی ساعتی امسال به روز
        /// </summary>
        [DataMember]
        public int ThisYearTimeLeaveSumMinuts { get; set; }
    }

    /// <summary>اطلاعات اعلام نظر مدیران</summary>
    [DataContract]
    public class ConfirmRequestStateDto
    {
        /// <summary>
        /// کد شناسه
        /// </summary>
        [DataMember]
        public int RowNo { get; set; }

        /// <summary>
        /// کدسازمان
        /// </summary>
        [DataMember]
        public int OrganCode { get; set; }

        /// <summary>
        /// کد نوع درخواست
        /// </summary>
        [DataMember]
        public int RequestTypeCode { get; set; }

        /// <summary>
        /// شرح نوع درخواست
        /// </summary>
        [DataMember]
        public int RequestTypeCodeStr { get; set; }

        /// <summary>
        /// شماره درخواست
        /// </summary>
        [DataMember]
        public int ReqCode { get; set; }


        /// <summary>
        /// کد گروه درخواست دهنده
        /// </summary>
        [DataMember]
        public int UserGroupCode { get; set; }

        /// <summary>
        /// رول کد مدیری که نظر می دهد
        /// </summary>
        [DataMember]
        public int RoleCode { get; set; }


        /// <summary>
        /// نوع نظر
        /// </summary>
        [DataMember]
        public int IdeaTypeCode { get; set; }

        /// <summary>
        /// کد نظر مدیر
        /// </summary>
        [DataMember]
        public int IdeaCode { get; set; }

        /// <summary>
        /// شرح نظر مدیر
        /// </summary>
        [DataMember]
        public string IdeaCodeStr { get; set; }

        /// <summary>
        /// تاریخ اعلام نظر
        /// </summary>
        [DataMember]
        public System.DateTime IdeaDateTime { get; set; }

        /// <summary>
        /// دلیل نظر
        /// </summary>
        [DataMember]
        public string IdeaReason { get; set; }
    }
}
