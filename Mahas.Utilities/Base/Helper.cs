using Mahas.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahas.Utilities.Base
{
    public static class Helper
    {

        public const string BASE_PATH_FILE_APP = "upload/";
        public static string FromAngka(decimal angka)
        {
            if (angka >= 75 && angka <= 100)
                return nameof(EnumGrade.A);
            else if (angka >= 70 && angka < 75)
                return nameof(EnumGrade.AB);
            else if (angka >= 60 && angka < 70)
                return nameof(EnumGrade.B);
            else if (angka >= 50 && angka < 60)
                return nameof(EnumGrade.BC);
            else if (angka >= 45 && angka < 50)
                return nameof(EnumGrade.C);
            else if (angka >= 40 && angka < 45)
                return nameof(EnumGrade.D);
            else
                return nameof(EnumGrade.E);
        }

        public static string SafePath(this string path)
        {
            path = path.EndsWith(@"/") ? path : path + @"/";
            path = path.StartsWith(@"/") ? path.Remove(0,1) : path;
            return path;
        }

        public static string BASE_PATH_DIRECTORY() => Path.Combine(Directory.GetCurrentDirectory().Split(@"\")[0], "Sharing") + "\\";
        public static string CreateBaseUploadPath(string path)=> Path.Combine(BASE_PATH_FILE_APP, path, DateTime.UtcNow.ToString("yyMMdd/"));
        public static string CreateFullUploadPath(string path)=> Path.Combine(BASE_PATH_DIRECTORY(), CreateBaseUploadPath(path));
    
    
    }
}
