using System;
using System.Collections.Generic;

namespace MailService.DBModels
{
    public class BernoulliRepository : IDisposable
    {
        private readonly NaiveBayesContext _context = new NaiveBayesContext();

        private IEnumerable<Bernoulli> GetAll() => _context.Bernoullis;

        public Bernoulli GetByWord(string word) 
        {
            
        }

        private async void Insert(Bernoulli bernoulli)
        {
            await _context.AddAsync(bernoulli);

            SaveChanges();
        }

        private void Update(Bernoulli bernoulli) 
        {
            _context.Update(bernoulli);

            SaveChanges();
        }

        private void SaveChanges() => _context.SaveChanges();

        public async void Dispose() => await _context.DisposeAsync();
    }
}