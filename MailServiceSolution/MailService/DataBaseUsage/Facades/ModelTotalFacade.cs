using System;
using System.Collections.Generic;
using System.Linq;

namespace MailService
{
    public class ModelTotalFacade<ModelTotalType> : IDisposable
        where ModelTotalType : class, IModelTotal, new()
    {
        private readonly Repository _repository = new Repository();
        private readonly IModelOption<ModelTotalType> _option;

        public ModelTotalFacade(IModelOption<ModelTotalType> option)
        {
            _option = option;
        }

        private IEnumerable<ModelTotalType> GetAll() => _repository.GetAll(_option);

        private ModelTotalType GetOne(string category)
        {
            return GetAll()
                .First(total => total.CategoryNavigation.Name == category);
        }

        private void Update(ModelTotalType total) => _repository.Update(total);

        private void ChangeByOne(string category, Action<ModelTotalType> change)
        {
            ModelTotalType total = GetOne(category);

            change(total);

            Update(total);
        }

        public Guid GetTotal(string category) => GetOne(category).Id;

        public void Plus(string category, int count)
        {
            ChangeByOne(category, total => total.Count += count);
        }

        public void Minus(string category, int count)
        {
            ChangeByOne(category, total => total.Count -= count);
        }

        public void Dispose() => _repository.Dispose();
    }
}