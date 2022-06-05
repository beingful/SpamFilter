using System;
using System.Collections.Generic;

namespace MailService
{
    public partial class PolynomialTotal : IModelTotal
    {
        public PolynomialTotal() => Polynomials = new HashSet<Polynomial>();

        public Guid Id { get; set; }
        public Guid Category { get; set; }
        public int Count { get; set; }

        public virtual Category CategoryNavigation { get; set; }
        public virtual ICollection<Polynomial> Polynomials { get; set; }
    }
}
