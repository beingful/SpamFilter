using System;

namespace MailService
{
    public partial class Polynomial : IBayesModel
    {
        public Guid Id { get; set; }
        public Guid Word { get; set; }
        public Guid Category { get; set; }
        public int Numerator { get; set; }
        public Guid Denominator { get; set; }

        public virtual Category CategoryNavigation { get; set; }
        public virtual PolynomialTotal DenominatorNavigation { get; set; }
        public virtual Vocabulary WordNavigation { get; set; }
    }
}
