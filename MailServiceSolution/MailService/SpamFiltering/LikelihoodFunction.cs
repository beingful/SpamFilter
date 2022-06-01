using System.Collections.Generic;
using System.Linq;

namespace MailService
{
    public class LikelihoodFunction
    {
        private readonly INaiveBayesModel _model;

        public LikelihoodFunction(INaiveBayesModel model) => _model = model;

        private Dictionary<IEmailCategory, double> GetCategory()
        {
            var categories = new Dictionary<IEmailCategory, double>();

            categories.Add(new Spam(), _model.Calculate<Spam>());
            categories.Add(new Correspondence(), _model.Calculate<Correspondence>());

            return categories;
        }

        public IEmailCategory Classify()
        {
            var categories = GetCategory();

            categories.OrderByDescending(category => categories.Values);

            return categories.ElementAt(0).Key;
        }
    }
}