using System;

namespace MailService.DBModels
{
    public partial class Vocabulary
    {
        public Guid Id { get; set; }
        public string Word { get; set; }

        public virtual WordInModel WordInModel { get; set; }
    }
}
