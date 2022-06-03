using System.Collections.Generic;

namespace MailService
{
    public class NaiveBayes
    {
        private readonly string _text;

        public NaiveBayes(string text) => _text = text;

        private IEnumerable<string> GetDocumentVector()
        {
            var vectorization = new DataProcessing(_text);

            return vectorization.Start();
        }

        private IEnumerable<string> GetVocabulary()
        {
            using var facade = new VocabularyFacade();

            return facade.GetAllTheWords();
        }

        private IEnumerable<ModelResult<IEmailCategory>> GetResult(INaiveBayesModel model)
        {
            var results = new List<ModelResult<IEmailCategory>>();

            results.Add(model.Calculate<Spam>());
            results.Add(model.Calculate<Correspondence>());

            return results;
        }

        public EmailClassification Classify()
        {
            IEnumerable<string> vector = GetDocumentVector();
            IEnumerable<string> vocabulary = GetVocabulary();

            var data = new InputData(vector, vocabulary);

            var bernoulliModel = new BernoulliModel(data);
            var polynomialModel = new PolynomialModel(data);

            IEnumerable<ModelResult<IEmailCategory>> bernoulliResult = GetResult(bernoulliModel);
            IEnumerable<ModelResult<IEmailCategory>> polynomialResult = GetResult(bernoulliModel);

            var function = new LikelihoodFunction(bernoulliResult, polynomialResult);

            string emailCategory = function.ClassifyEmail();

            return new EmailClassification(_text, emailCategory, bernoulliResult, polynomialResult);
        }
    }
}