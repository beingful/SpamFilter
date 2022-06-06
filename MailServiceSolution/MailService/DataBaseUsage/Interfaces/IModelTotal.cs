using System;

namespace MailService
{
    public interface IModelTotal
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public int Count { get; set; }

        public Category Category { get; set; }
    }
}
