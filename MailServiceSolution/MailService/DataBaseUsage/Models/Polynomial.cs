using System;

namespace MailService
{
    public partial class Polynomial : IBayesModel
    {
        public Guid Id { get; set; }
        public Guid VocabularyId { get; set; }
        public Guid CategoryId { get; set; }
        public int Numerator { get; set; }
        public Guid TotalId { get; set; }

        public virtual Category Category { get; set; }
        public virtual PolynomialTotal Total { get; set; }
        public virtual Vocabulary Vocabulary { get; set; }
    }
}