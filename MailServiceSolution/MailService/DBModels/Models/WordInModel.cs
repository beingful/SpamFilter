using System;

namespace MailService
{
    public partial class WordInModel
    {
        public Guid Id { get; set; }
        public Guid Multinomial { get; set; }
        public Guid Polynomial { get; set; }

        public virtual Vocabulary IdNavigation { get; set; }
        public virtual Model MultinomialNavigation { get; set; }
        public virtual Model PolynomialNavigation { get; set; }
    }
}