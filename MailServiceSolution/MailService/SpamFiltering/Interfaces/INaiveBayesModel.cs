using System;
using System.Collections.Generic;

namespace MailService
{
    public interface INaiveBayesModel
    {
        public Dictionary<string, ValueType> Attributes { get; }

        public Result Calculate<CategoryType>()
            where CategoryType : IEmailCategory, new();
    }
}