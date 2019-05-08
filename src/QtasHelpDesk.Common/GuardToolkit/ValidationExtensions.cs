using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace QtasHelpDesk.CrossCutting.GuardToolkit
{
    public static class ValidationExtensions
    {
        #region EfCore
        public static string GetValidationErrors(this DbContext context)
        {
            var errors = new StringBuilder();
            var entities = context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
                .Select(e => e.Entity);
            foreach (var entity in entities)
            {
                var validationContext = new ValidationContext(entity);
                var validationResults = new List<ValidationResult>();
                if (!Validator.TryValidateObject(entity, validationContext, validationResults, validateAllProperties: true))
                {
                    foreach (var validationResult in validationResults)
                    {
                        var names = validationResult.MemberNames.Aggregate((s1, s2) => $"{s1}, {s2}");
                        errors.AppendFormat("{0}: {1}", names, validationResult.ErrorMessage);
                    }
                }
            }

            return errors.ToString();
        }


        #endregion

        #region InputValidation
        public static bool IsValidIranianNationalCode(this string input)
        {
            if (!Regex.IsMatch(input, @"^(?!(\d)\1{9})\d{10}$"))
                return false;

            var check = Convert.ToInt32(input.Substring(9, 1));
            var sum = Enumerable.Range(0, 9)
                .Select(x => Convert.ToInt32(input.Substring(x, 1)) * (10 - x))
                .Sum() % 11;

            return sum < 2 && check == sum || sum >= 2 && check + sum == 11;
        }

        public static bool IsValidIranianLegalCode(this string input)
        {
            if (!Regex.IsMatch(input, @"^(?!(\d)\1{10})\d{11}$"))
                return false;

            var check = Convert.ToInt32(input.Substring(10, 1));
            var dec = Convert.ToInt32(input.Substring(9, 1)) + 2;
            var coef = new[] { 29, 27, 23, 19, 17, 29, 27, 23, 19, 17 };

            var sum = Enumerable.Range(0, 10)
                          .Select(x => (Convert.ToInt32(input.Substring(x, 1)) + dec) * coef[x])
                          .Sum() % 11;

            return sum == check;
        }

        public static bool IsValidForeignerCode(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;
            return true;
        }


        public static bool IsValidTel(string input)
        {
            return !string.IsNullOrEmpty(input);

            //TODO: صحت شماره تلفن بازنگری شود
            //if (input.StartsWith("0"))
            //    return input.Length == 11;
            //return input.Length == 10;
        }

        public static bool IsValidAddress(string input)
        {
            return !string.IsNullOrEmpty(input) && input.Length >= 10;
        }

        public static bool IsValidName(string input)
        {
            return !string.IsNullOrEmpty(input) && input.Length >= 2;
        }

        public static bool IsValidPersianName(string input)
        {
            return Regex.IsMatch(input, @"[\u0600-\u06FF]$");
        }

        public static bool IsValidLatinName(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z]+$");
        }

        public static bool IsValidCertId(string input)
        {
            return !string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^\d+$");
        }

        public static bool IsValidMobileNumber(string input)
        {
            return Regex.IsMatch(input, @"09(1[0-9]|3[1-9]|2[1-9])-?[0-9]{3}-?[0-9]{4} ");
        }

        public static bool IsNumeric(string input)
        {
            return Regex.IsMatch(input, @"^(0|[1-9][0-9]*)$");
        }

        public static bool IsNumeric(char input)
        {
            const char delete = (char)8;
            return !char.IsDigit(input) && input != delete;
        }

        public static bool IsNumber(char input)
        {
            return !char.IsDigit(input);
        }

        public static string RemoveUnathorizeCharacter(this string input)
        {
            return Regex.Replace(input, @"[!@,#,$,%,^,&,*,+,>,<,=,|,\,:,;]", "");
        }

        public static string RemoveSpaces(this string input)
        {
            const RegexOptions options = RegexOptions.None;
            var regex = new Regex(@"[ ]{2,}", options);
            return regex.Replace(input, @" ");
        }

        public static bool IsValidEmail(string input)
        {
            try { return Regex.IsMatch(input, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase); }
            catch { return true; }
        }

        public static bool IsValidIban(string iban)
        {
            if (string.IsNullOrEmpty(iban))
                return false;

            if (iban.StartsWith("IR"))
            {
                if (iban.Length != 26)
                    return false;

                if (!Regex.IsMatch(iban, "IR[0-9]{24}"))
                    return false;

                return true;
            }

            return false;
        }

        public static string GetMonthName(int month)
        {
            switch(month)
            {
                case 1:
                    return "فروردین";
                case 2:
                    return "اردیبهشت";
                case 3:
                    return "خرداد";
                case 4:
                    return "تیر";
                case 5:
                    return "مرداد";
                case 6:
                    return "شهریور";
                case 7:
                    return "مهر";
                case 8:
                    return "آبان";
                case 9:
                    return "آذر";
                case 10:
                    return "دی ";
                case 11:
                    return "بهمن";
                case 12:
                    return "اسفند";

            }
            return "";
        }

       


        #endregion

    }
}