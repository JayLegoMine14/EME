using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EME.Objects
{
    public class User
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public List<string> ImagePaths { get; set; }

        public List<Name> GetNames()
        {
            List<Name> names = new List<Name>();

            foreach(NameFormat nf in (NameFormat[])Enum.GetValues(typeof(NameFormat)))
            {
                names.Add(new Name()
                {
                    Value = NameManager.FormatName(this, nf),
                    Confidence = ConfidenceManager.GetNameConfidence(nf)
                });
            }

            return names;
        }
    }
}
