using System;
using System.Collections.Generic;

namespace MailService
{
    public partial class Model
    {
        public Model()
        {
            WordInModelMultinomialNavigations = new HashSet<WordInModel>();
            WordInModelPolynomialNavigations = new HashSet<WordInModel>();
        }

        public Guid Id { get; set; }
        public Guid Spam { get; set; }
        public Guid Correspondence { get; set; }

        public virtual Fraction CorrespondenceNavigation { get; set; }
        public virtual Fraction SpamNavigation { get; set; }
        public virtual ICollection<WordInModel> WordInModelMultinomialNavigations { get; set; }
        public virtual ICollection<WordInModel> WordInModelPolynomialNavigations { get; set; }
    }
}