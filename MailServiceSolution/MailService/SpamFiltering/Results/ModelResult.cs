using System;
using System.Collections.Generic;

namespace MailService
{
    public class ModelResult
    {
        public readonly Dictionary<string, ValueType> Attributes;
        public readonly IEnumerable<Result<IEmailCategory>> Results;

        public ModelResult(Dictionary<string, ValueType> attributes,
            IEnumerable<Result<IEmailCategory>> results)
        {
            Attributes = attributes;
            Results = results;
        }
    }
}