using System;
using System.Collections.Generic;

namespace MailService.DBModels
{
    public partial class Fraction
    {
        public Fraction()
        {
            ModelCorrespondenceNavigations = new HashSet<Model>();
            ModelSpamNavigations = new HashSet<Model>();
        }

        public Guid Id { get; set; }
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public virtual ICollection<Model> ModelCorrespondenceNavigations { get; set; }
        public virtual ICollection<Model> ModelSpamNavigations { get; set; }
    }
}
