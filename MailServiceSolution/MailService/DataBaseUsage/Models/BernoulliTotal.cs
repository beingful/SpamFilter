using System;
using System.Collections.Generic;

namespace MailService
{
    public partial class BernoulliTotal : IModelTotal
    {
        public BernoulliTotal() => Bernoullis = new HashSet<Bernoulli>();

        public Guid Id { get; set; }
        public Guid Category { get; set; }
        public int Count { get; set; }

        public virtual Category CategoryNavigation { get; set; }
        public virtual ICollection<Bernoulli> Bernoullis { get; set; }
    }
}