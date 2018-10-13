using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EME.Objects
{
    public enum NameFormat
    {
        FML,
        FL,
        LCFM,
        FMIL,
        FIMIL
    }

    public class NameManager
    {
        public static string FormatName(User u, NameFormat nf)
        {
            switch (nf)
            {
                case NameFormat.FML:
                    return u.FirstName + " " + u.MiddleName + " " + u.LastName;
                case NameFormat.FL:
                    return u.FirstName + " " + u.LastName;
                case NameFormat.LCFM:
                    return u.LastName + ", " + u.FirstName + " " + u.MiddleName;
                case NameFormat.FMIL:
                    return u.FirstName + " " + (String.IsNullOrEmpty(u.MiddleName) ? "" : u.MiddleName[0].ToString()) + " " + u.LastName;
                case NameFormat.FIMIL:
                    return u.FirstName[0] + " " + (String.IsNullOrEmpty(u.MiddleName) ? "" : u.MiddleName[0].ToString()) + " " + u.LastName;
            }

            return "";
        }
    }
}
