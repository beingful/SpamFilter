using System;
using System.Collections.Generic;
using System.Linq;

namespace MailService
{
    public class NaiveBayesModelFacade<ModelType> : IDisposable
        where ModelType : class, IBayesModel, new()
    {
        private readonly Repository _repository = new Repository();
        private readonly IModelOption<ModelType> _option;

        public NaiveBayesModelFacade(IModelOption<ModelType> option) => _option = option;

        private IEnumerable<ModelType> GetAll() => _repository.GetAll(_option);

        private IEnumerable<ModelType> GetByWord(string word)
        {
            return GetAll()
                .Where(element => element.WordNavigation.Word == word);
        }

        private ModelType Get(string word, string category)
        {
            return GetByWord(word)
                .FirstOrDefault(model => model.CategoryNavigation.Name == category);
        }

        private void Update(ModelType model) => _repository.Update(model);

        private void ChangeNumerator(string word, string category,
            int number, Action<IBayesModel, int> changeNumerator)
        {
            ModelType model = Get(word, category);

            changeNumerator(model, number);

            Update(model);
        }

        public Guid GetId(string word, string category) => Get(word, category).Id;

        public (int Numerator, int Denominator) GetFraction(string word,
            string category, Func<IBayesModel, IModelTotal> total)
        {
            ModelType model = Get(word, category);

            return (model.Numerator, total(model).Count);
        }

        public void PlusToNumerator(string word, string category, int number)
        {
            ChangeNumerator(word, category, number,
                (model, number) => model.Numerator += number);
        }

        public void MinusFromNumerator(string word, string category, int number)
        {
            ChangeNumerator(word, category, number,
                (model, number) => model.Numerator -= number);
        }

        public void Dispose() => _repository.Dispose();
    }
}