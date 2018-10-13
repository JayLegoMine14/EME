using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EME.Objects
{
    public class ConfidenceManager
    {
        public static double GetNameConfidence(NameFormat nf)
        {
            switch (nf)
            {
                case NameFormat.FML:
                    return .8;
                case NameFormat.FL:
                    return .3;
                case NameFormat.LCFM:
                    return .8;
                case NameFormat.FMIL:
                    return .5;
                case NameFormat.FIMIL:
                    return .4;
            }

            return 0;
        }
    }
}
