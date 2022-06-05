using System;

namespace MailService
{
    public interface IBayesModel
    {
        public Guid Id { get; set; }
        public Guid Word { get; set; }
        public Guid Category { get; set; }
        public int Numerator { get; set; }
        public Guid Denominator { get; set; }

        public Category CategoryNavigation { get; set; }
        public Vocabulary WordNavigation { get; set; }
    }
}
