using System;
using System.Collections.Generic;

namespace MailService
{
    public class ModelResult<CategoryType>
        where CategoryType : IEmailCategory
    {
        public readonly Dictionary<string, ValueType> Attributes;
        public readonly double Probability;

        public ModelResult(Dictionary<string, ValueType> attributes, double probability)
        {
            Attributes = attributes;
            Probability = probability;
        }

        public string Category => typeof(CategoryType).Name;
    }
}