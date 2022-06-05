using System;
using System.Collections.Generic;

namespace MailService
{
    public partial class Category
    {
        public Category()
        {
            BernoulliTotals = new HashSet<BernoulliTotal>();
            Bernoullis = new HashSet<Bernoulli>();
            PolynomialTotals = new HashSet<PolynomialTotal>();
            Polynomials = new HashSet<Polynomial>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BernoulliTotal> BernoulliTotals { get; set; }
        public virtual ICollection<Bernoulli> Bernoullis { get; set; }
        public virtual ICollection<PolynomialTotal> PolynomialTotals { get; set; }
        public virtual ICollection<Polynomial> Polynomials { get; set; }
    }
}
