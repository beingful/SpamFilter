using System;
using System.Collections.Generic;

namespace MailService
{
    public class Repository : IDisposable
    {
        private readonly NaiveBayesClassifierContext _context = new NaiveBayesClassifierContext();

        public IEnumerable<T> GetAll<T>(IModelOption<T> option) where T : class
        {
            return option.GetAll(_context);
        }

        public async void Insert(object model)
        {
            await _context.AddAsync(model);

            SaveChanges();
        }

        public void Update(object model)
        {
            _context.Update(model);

            SaveChanges();
        }

        private void SaveChanges() => _context.SaveChanges();

        public async void Dispose() => await _context.DisposeAsync();
    }
}