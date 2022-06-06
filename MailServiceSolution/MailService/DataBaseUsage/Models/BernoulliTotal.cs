using System;
using System.Collections.Generic;

namespace MailService
{
    public partial class BernoulliTotal : IModelTotal
    {
        public BernoulliTotal() => Bernoullis = new HashSet<Bernoulli>();

        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public int Count { get; set; }

        public Category Category { get; set; }
        public ICollection<Bernoulli> Bernoullis { get; set; }
    }
}