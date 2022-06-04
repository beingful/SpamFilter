using System;

namespace MailService
{
    public class ModelFacade : IDisposable
    {
        private readonly Repository _repository = new Repository();

        public Guid Create(Guid spam, Guid correspondence)
        {
            var model = new Model
            {
                Id = Guid.NewGuid(),
                Spam = spam,
                Correspondence = correspondence
            };

            _repository.Insert(model);

            return model.Id;
        }

        public void Dispose() => _repository.Dispose();
    }
}