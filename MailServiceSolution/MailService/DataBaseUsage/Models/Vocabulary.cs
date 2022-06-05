using System;
using System.Collections.Generic;

namespace MailService
{
    public partial class Vocabulary
    {
        public Vocabulary()
        {
            Bernoullis = new HashSet<Bernoulli>();
            Polynomials = new HashSet<Polynomial>();
        }

        public Guid Id { get; set; }
        public string Word { get; set; }

        public virtual ICollection<Bernoulli> Bernoullis { get; set; }
        public virtual ICollection<Polynomial> Polynomials { get; set; }
    }
}
