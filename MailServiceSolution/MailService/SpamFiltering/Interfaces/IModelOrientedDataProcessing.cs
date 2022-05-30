using System.Collections.Generic;

namespace MailService.SpamFiltering.Interfaces
{
    public interface IModelOrientedDataProcessing
    {
        public IEnumerable<string> GetVectorOfAttributes();
    }
}
