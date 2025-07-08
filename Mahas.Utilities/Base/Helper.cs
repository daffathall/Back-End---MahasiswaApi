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
    }
}
