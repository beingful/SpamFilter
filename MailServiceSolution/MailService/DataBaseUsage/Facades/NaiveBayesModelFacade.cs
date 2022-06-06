using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace MailService
{
    public class NaiveBayesModelFacade<ModelType> : IDisposable
        where ModelType : class, IBayesModel, new()
    {
        private readonly Repository _repository = new Repository();
        private readonly IModelOption<ModelType> _option;

        public NaiveBayesModelFacade(IModelOption<ModelType> option) => _option = option;

        private IQueryable<ModelType> GetAll() => _repository.GetAll(_option);

        public IQueryable<ModelType> Get()
        {
            return GetAll()
                .Include(model => model.Vocabulary)
                .Include(model => model.Category);
        }

        private ModelType GetOne(string word, string category)
        {
            return Get()
                .First(model => model.Vocabulary.Word == word
                && model.Category.Name == category);
        }

        private void Update(ModelType model) => _repository.Update(model);

        private void ChangeNumerator(string word, string category,
            int number, Action<IBayesModel, int> changeNumerator)
        {
            ModelType model = GetOne(word, category);

            changeNumerator(model, number);

            Update(model);
        }

        public Guid GetId(string word, string category) => GetOne(word, category).Id;

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