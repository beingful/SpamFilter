using System;

namespace MailService
{
    public interface IModelTotal
    {
        public Guid Id { get; set; }
        public Guid Category { get; set; }
        public int Count { get; set; }

        public Category CategoryNavigation { get; set; }
    }
}
