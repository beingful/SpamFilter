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

        private void CreateIfDoesNotExist(IEnumerable<string> vector)
        {
            foreach (var word in vector)
            {
                var facade = new VocabularyFacade();

                if (!facade.DoesSuchAWordExist(word))
                {
                    facade.Create(word);
                }
            }
        }

        private ModelResult GetResult(INaiveBayesModel model)
        {
            var results = new List<Result>();

            results.Add(model.Calculate<Spam>());
            results.Add(model.Calculate<Correspondence>());

            return new ModelResult(model.Attributes, results);
        }

        public EmailClassification Classify()
        {
            IEnumerable<string> vector = GetDocumentVector();

            CreateIfDoesNotExist(vector);

            IEnumerable<string> vocabulary = GetVocabulary();

            var data = new InputData(vector, vocabulary);

            var bernoulliModel = new BernoulliModel(data);
            var polynomialModel = new PolynomialModel(data);

            ModelResult bernoulliResult = GetResult(bernoulliModel);
            ModelResult polynomialResult = GetResult(bernoulliModel);

            var function = new LikelihoodFunction(bernoulliResult.Results, polynomialResult.Results);

            string emailCategory = function.ClassifyEmail();

            var textRepresentation = new TextRepresentation(_text, emailCategory, vector);

            return new EmailClassification(textRepresentation, bernoulliResult, polynomialResult);
        }
    }
}