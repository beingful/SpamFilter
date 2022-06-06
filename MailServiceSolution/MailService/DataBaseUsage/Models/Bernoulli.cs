using System;

namespace MailService
{
    public partial class Bernoulli : IBayesModel
    {
        public Guid Id { get; set; }
        public Guid VocabularyId { get; set; }
        public Guid CategoryId { get; set; }
        public int Numerator { get; set; }
        public Guid TotalId { get; set; }

        public Category Category { get; set; }
        public BernoulliTotal Total { get; set; }
        public Vocabulary Vocabulary { get; set; }
    }
}