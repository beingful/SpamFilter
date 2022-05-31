using System;

namespace MailService.DBModels.Interfaces
{
    public interface INaiveBayesModel
    {
        public Guid Id { get; set; }
        public int Spam { get; set; }
        public int Сorrespondence { get; set; }
        public Vocabulary IdNavigation { get; set; }
    }
}
