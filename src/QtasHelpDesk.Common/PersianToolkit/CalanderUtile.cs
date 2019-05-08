using System;
using System.Collections.Generic;
using System.Text;
using DNTPersianUtils.Core;

namespace QtasHelpDesk.CrossCutting.PersianToolkit
{
   public static class CalanderUtil
    {
        public static int ConvertToNumericFormat(this DateTime dateTime)
        {
        
            return dateTime.GetPersianYear()*10000 + dateTime.GetPersianMonth()*100 + 
                             dateTime.GetPersianDayOfMonth();
        }

        public static int GetfirstDayOfYear(this DateTime dateTime)
        {
            return int.Parse(dateTime.GetPersianYear() + "01" +
                             "01");
        }

    }
}
