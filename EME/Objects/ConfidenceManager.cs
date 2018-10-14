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
                    return .5;
            }

            return 0;
        }
    }
}
