using System;
using System.Collections.Generic;

namespace MailService
{
    public interface INaiveBayesModel
    {
        public Dictionary<string, ValueType> Attributes { get; }

        public Result<IEmailCategory> Calculate<CategoryType>()
            where CategoryType : IEmailCategory, new();
    }
}