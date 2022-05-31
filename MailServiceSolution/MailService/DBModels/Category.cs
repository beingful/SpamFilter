using System;

namespace MailService.DBModels
{
    public partial class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
