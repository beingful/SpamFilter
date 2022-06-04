using System;
using System.Linq;

namespace MailService
{
    public class CategoryFacade : IDisposable
    {
        private readonly Repository _repository = new Repository();

        private Category GetCategoryByName(string name)
        {
            return _repository
                .GetAll(new CategoryOption())
                .First(element => element.Name == name);
        }

        public int GetEmailQuantity(string categoryName) => GetCategoryByName(categoryName).Quantity;

        public void AddOne(string categoryName)
        {
            Category category = GetCategoryByName(categoryName);

            category.Quantity += 1;

            _repository.Update(category);
        }

        public void Dispose() => _repository.Dispose();
    }
}