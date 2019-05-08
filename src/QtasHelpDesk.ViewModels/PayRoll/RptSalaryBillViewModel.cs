using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QtasHelpDesk.ViewModels.PayRoll
{
    /// <summary> گزارش فیش حقوق </summary>
    [DataContract]
    public class RptSalaryBillDto
    {
        public RptSalaryBillDto()
        {
            SalaryParamNameDtos = new List<SalaryParamNameDto>();
            //PerSalaryInfoDtos = new List<PerSalaryInfoDto>();
            LoanTypeNameDtos = new List<LoanTypeNameDto>();
            PerSalaryAndLoanInfoDtos = new List<PerSalaryAndLoanInfoDto>();
        }

        /// <summary> شرح پارامترهای حقوق </summary>
        [DataMember]
        public List<SalaryParamNameDto> SalaryParamNameDtos { get; set; }

        ///// <summary> اطلاعات حقوق کارکنان </summary>
        //[DataMember]
        //public List<PerSalaryInfoDto> PerSalaryInfoDtos { get; set; }

        /// <summary> شرح انواع وام </summary>
        [DataMember]
        public List<LoanTypeNameDto> LoanTypeNameDtos { get; set; }

        /// <summary> اطلاعات وام کارکنان </summary>
        [DataMember]
        public List<PerSalaryAndLoanInfoDto> PerSalaryAndLoanInfoDtos { get; set; }
    }

    /// <summary> شناسه و نام انواع وام </summary>
    [DataContract]
    public class LoanTypeNameDto
    {
        /// <summary> شمارنده  </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary> شرح نوع وام </summary>
        [DataMember]
        public string LoanTypeDesc { get; set; }

        /// <summary> شناسه نوع وام  </summary>
        [DataMember]
        public int LoanTypeCode { get; set; }
    }

    /// <summary> گزارش وامهای کارمند </summary>
    [DataContract]
    public class PerSalaryAndLoanInfoDto
    {

        /// <summary>  کد محل خدمت </summary>
        [DataMember]
        public object OrganAreaCode { get; set; }
        /// <summary>  محل خدمت </summary>
        [DataMember]
        public string OrganArea { get; set; }
        /// <summary> کدپرسنلی </summary>
        [DataMember]
        public int PerCode { get; set; }
        /// <summary> شماره شناسنامه کارمند </summary>
        [DataMember]
        public string CertificationId { get; set; }
        /// <summary> نام پرسنل </summary>
        [DataMember]
        public string FullName { get; set; }
        /// <summary> نوع استخدام </summary>
        [DataMember]
        public string EmployeeTypeStr { get; set; }
        /// <summary> محل پرداخت حقوق </summary>
        [DataMember]
        public string PerBranch { get; set; }
        /// <summary> شماره حساب </summary>
        [DataMember]
        public string PerAccountNo { get; set; }
        /// <summary> نوع حساب </summary>
        [DataMember]
        public string PerAccountType { get; set; }
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
        /// <summary> فوق العاده پایه تشویقی  - مقدار پارامتر </summary>
        [DataMember]
        public decimal Param16Amount { get; set; }

        /// <summary> فوق العاده پایه رزمندگی - مقدار پارامتر  </summary>
        [DataMember]
        public decimal Param17Amount { get; set; }
        /// <summary> رتبه - مقدار پارامتر  </summary>
        [DataMember]
        public decimal Param18Amount { get; set; }
        /// <summary> تشویقی - مقدار پارامتر  </summary>
        [DataMember]
        public decimal Param19Amount { get; set; }

        /// <summary> مبلغ اضافه کار </summary>
        [DataMember]
        public decimal ExtraWorkAmount { get; set; }
        /// <summary> ساعت اضافه کار </summary>
        [DataMember]
        public int ExtraWorkHour { get; set; }
        /// <summary> مبلغ ماموریت </summary>
        [DataMember]
        public decimal MissionAmount { get; set; }
        /// <summary> پاداش مدیریت </summary>
        [DataMember]
        public decimal ProfitSharingAmount { get; set; }
        /// <summary> عیدی پایان سال </summary>
        [DataMember]
        public decimal EndYearAmount { get; set; }
        /// <summary> اعیاد ملی مذهبی </summary>
        [DataMember]
        public decimal NationalCelebrityAmount { get; set; }
        /// <summary> کارانه </summary>
        [DataMember]
        public decimal KaranehAmount { get; set; }
        /// <summary> مابه التفاوت </summary>
        [DataMember]
        public decimal DiffAmount { get; set; }
        /// <summary> خالص پرداختی </summary>
        [DataMember]
        public decimal PersonalPaymentAmount { get; set; }
        /// <summary> جمع درآمد </summary>
        [DataMember]
        public decimal SumIncome { get; set; }
        /// <summary> جمع حقوق </summary>
        [DataMember]
        public decimal SumSalary { get; set; }
        /// <summary> روزهای کارکرد </summary>
        [DataMember]
        public int WorkDaysCount { get; set; }
        /// <summary> مبلغ مساعده </summary>
        [DataMember]
        public decimal MosaedehAmount { get; set; }
        /// <summary> مبلغ سایر کسورات </summary>
        [DataMember]
        public decimal OtherDeductionAmount { get; set; }
        /// <summary> مبلغ خیریه </summary>
        [DataMember]
        public decimal CarityAmount { get; set; }
        /// <summary> بیمه سهم کارمند </summary>
        [DataMember]
        public decimal ClerkSSInsuranceAmount { get; set; }
        /// <summary> بیمه تکمیلی </summary>
        [DataMember]
        public decimal SupplementaryInsuranceAmount { get; set; }
        /// <summary> مالیات </summary>
        [DataMember]
        public decimal TaxAmount { get; set; }
        /// <summary> مشمول مالیات </summary>
        [DataMember]
        public decimal TaxableAmount { get; set; }
        /// <summary> اموررفاهی </summary>
        [DataMember]
        public decimal RefahiAmount { get; set; }
        /// <summary> وامها </summary>
        [DataMember]
        public decimal SumLoanInstalmentAmount { get; set; }
        /// <summary> خالص پرداختی </summary>
        [DataMember]
        public decimal NetPayableAmount { get; set; }
        /// <summary> جمع کسورات </summary>
        [DataMember]
        public decimal SumDeductions { get; set; }

        /// <summary> مالیات پیش پرداختی یا تعدیل مالیات </summary>
        [DataMember]
        public decimal PrePaidTax { get; set; }

        /// <summary> جمع مالیات تا اینماه </summary>
        [DataMember]
        public decimal SumThisYearTax { get; set; }
        /// <summary> جمع مشمول مالیات تا اینماه </summary>
        [DataMember]
        public decimal SumThisYearTaxable { get; set; }

        /// <summary> جمع بیمه تامین اجتماعی تا اینماه </summary>
        [DataMember]
        public decimal SumThisYearClerkInsurance { get; set; }
        /// <summary> مبلغ قسط وام نوع 1  </summary>
        [DataMember]
        public decimal Loan1Instalment { get; set; }
        /// <summary> مبلغ قسط وام نوع 2  </summary>
        [DataMember]
        public decimal Loan2Instalment { get; set; }
        /// <summary> مبلغ قسط وام نوع 3  </summary>
        [DataMember]
        public decimal Loan3Instalment { get; set; }
        /// <summary> مبلغ قسط وام نوع 4  </summary>
        [DataMember]
        public decimal Loan4Instalment { get; set; }
        /// <summary> مبلغ قسط وام نوع 5  </summary>
        [DataMember]
        public decimal Loan5Instalment { get; set; }
        /// <summary> مبلغ قسط وام نوع 6  </summary>
        [DataMember]
        public decimal Loan6Instalment { get; set; }
        /// <summary> مبلغ قسط وام نوع 7  </summary>
        [DataMember]
        public decimal Loan7Instalment { get; set; }
        /// <summary> مبلغ قسط وام نوع 8  </summary>
        [DataMember]
        public decimal Loan8Instalment { get; set; }
        /// <summary> مبلغ قسط وام نوع 9  </summary>
        [DataMember]
        public decimal Loan9Instalment { get; set; }
        /// <summary> تعداد کل اقساط وام نوع 1  </summary>
        [DataMember]
        public decimal Loan1InstalmentTotalCount { get; set; }
        /// <summary> تعداد کل اقساط وام نوع 2  </summary>
        [DataMember]
        public decimal Loan2InstalmentTotalCount { get; set; }
        /// <summary> تعداد کل اقساط وام نوع 3  </summary>mmary>
        [DataMember]
        public decimal Loan3InstalmentTotalCount { get; set; }
        /// <summary> تعداد کل اقساط وام نوع 4  </summary>y>
        [DataMember]
        public decimal Loan4InstalmentTotalCount { get; set; }
        /// <summary> تعداد کل اقساط وام نوع 5  </summary>mmary>
        [DataMember]
        public decimal Loan5InstalmentTotalCount { get; set; }
        /// <summary> تعداد کل اقساط وام نوع 6  </summary>mary>
        [DataMember]
        public decimal Loan6InstalmentTotalCount { get; set; }
        /// <summary> تعداد کل اقساط وام نوع 7  </summary>
        [DataMember]
        public decimal Loan7InstalmentTotalCount { get; set; }
        /// <summary> تعداد کل اقساط وام نوع 8  </summary>mary>
        [DataMember]
        public decimal Loan8InstalmentTotalCount { get; set; }
        /// <summary> تعداد کل اقساط وام نوع 9  </summary>
        [DataMember]
        public decimal Loan9InstalmentTotalCount { get; set; }
        /// <summary> تعداد اقساط پرداختی وام نوع 1  </summary>
        [DataMember]
        public decimal Loan1InstalmentPaidCount { get; set; }
        /// <summary> تعداد اقساط پرداختی وام نوع 2  </summary>
        [DataMember]
        public decimal Loan2InstalmentPaidCount { get; set; }
        /// <summary> تعداد اقساط پرداختی وام نوع 3  </summary>>
        [DataMember]
        public decimal Loan3InstalmentPaidCount { get; set; }
        /// <summary> تعداد اقساط پرداختی وام نوع 4  </summary>
        [DataMember]
        public decimal Loan4InstalmentPaidCount { get; set; }
        /// <summary> تعداد اقساط پرداختی وام نوع 5  </summary>>
        [DataMember]
        public decimal Loan5InstalmentPaidCount { get; set; }
        /// <summary> تعداد اقساط پرداختی وام نوع 6  </summary>
        [DataMember]
        public decimal Loan6InstalmentPaidCount { get; set; }
        /// <summary> تعداد اقساط پرداختی وام نوع 7  </summary>
        [DataMember]
        public decimal Loan7InstalmentPaidCount { get; set; }
        /// <summary> تعداد اقساط پرداختی وام نوع 8  </summary>
        [DataMember]
        public decimal Loan8InstalmentPaidCount { get; set; }
        /// <summary> تعداد اقساط پرداختی وام نوع 9  </summary>
        [DataMember]
        public decimal Loan9InstalmentPaidCount { get; set; }
        /// <summary> مانده وام نوع 1  </summary>
        [DataMember]
        public decimal Loan1RemainedAmount { get; set; }
        /// <summary> مانده وام نوع 2  </summary>
        [DataMember]
        public decimal Loan2RemainedAmount { get; set; }
        /// <summary> مانده وام نوع 3  </summary>
        [DataMember]
        public decimal Loan3RemainedAmount { get; set; }
        /// <summary> مانده وام نوع 4  </summary>
        [DataMember]
        public decimal Loan4RemainedAmount { get; set; }
        /// <summary> مانده وام نوع 5  </summary>
        [DataMember]
        public decimal Loan5RemainedAmount { get; set; }
        /// <summary> مانده وام نوع 6  </summary>
        [DataMember]
        public decimal Loan6RemainedAmount { get; set; }
        /// <summary> مانده وام نوع 7  </summary>
        [DataMember]
        public decimal Loan7RemainedAmount { get; set; }
        /// <summary> مانده وام نوع 8  </summary>
        [DataMember]
        public decimal Loan8RemainedAmount { get; set; }
        /// <summary> مانده وام نوع 9  </summary>
        [DataMember]
        public decimal Loan9RemainedAmount { get; set; }
    }

}
