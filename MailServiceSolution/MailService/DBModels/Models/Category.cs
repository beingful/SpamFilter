using System;

namespace MailService
{
    public partial class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}