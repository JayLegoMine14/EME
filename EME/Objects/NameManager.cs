using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EME.Objects
{
    public enum NameFormat
    {
        FML,
        FL
    }

    public class NameManager
    {
        public static string FormatName(User u, NameFormat nf)
        {
            switch (nf)
            {
                case NameFormat.FML:
                    return u.FirstName + " " + u.MiddleName + (String.IsNullOrEmpty(u.MiddleName) ? "" : " ") + u.LastName;
                case NameFormat.FL:
                    return u.FirstName + " " + u.LastName;
            }

            return "";
        }
    }
}
