using System;

namespace MailService
{
    public partial class Vocabulary
    {
        public Guid Id { get; set; }
        public string Word { get; set; }

        public virtual WordInModel WordInModel { get; set; }
    }
}
