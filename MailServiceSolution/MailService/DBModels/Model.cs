using System;

namespace MailService.DBModels
{
    public partial class Model
    {
        public Guid Id { get; set; }
        public string Word { get; set; }
        public Guid BernoulliId { get; set; }
        public Guid PolynomialId { get; set; }

        public virtual Bernoulli Bernoulli { get; set; }
        public virtual Polynomial Polynomial { get; set; }
    }
}
