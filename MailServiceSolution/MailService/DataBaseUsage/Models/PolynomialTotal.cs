using System;
using System.Collections.Generic;

namespace MailService
{
    public partial class PolynomialTotal : IModelTotal
    {
        public PolynomialTotal() => Polynomials = new HashSet<Polynomial>();

        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public int Count { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Polynomial> Polynomials { get; set; }
    }
}
