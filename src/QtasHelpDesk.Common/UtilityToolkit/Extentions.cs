using System;
using System.Globalization;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace QtasHelpDesk.CrossCutting.UtilityToolkit
{
  public static  class Utility
    {
     /// <summary>
            /// Gets the download binary array
            /// </summary>
            /// <param name="file">File</param>
            /// <returns>Download binary array</returns>
            public static byte[] GetDownloadBits(this IFormFile file)
            {
                using (var fileStream = file.OpenReadStream())
                using (var ms = new MemoryStream())
                {
                    fileStream.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    return fileBytes;
                }
            }

            /// <summary>
            /// Gets the picture binary array
            /// </summary>
            /// <param name="file">File</param>
            /// <returns>Picture binary array</returns>
            public static byte[] GetPictureBits(this IFormFile file)
            {
                return GetDownloadBits(file);
            }


            public static DateTime GetPreviousMonth(int month, int year)
            {
                PersianCalendar pc = new PersianCalendar();
                   DateTime dt = new DateTime(1391, 4, 7, pc);
                   return  dt.AddMonths(-1);
            }
    

        }
}
