using System;

namespace MailService
{
    internal class FractionFacade : IDisposable
    {
        private readonly Repository _repository = new Repository();

        public Guid Create(int numerator, int denominator)
        {
            var fraction = new Fraction
            {
                Id = Guid.NewGuid(),
                Numerator = numerator,
                Denominator = denominator
            };

            _repository.Insert(fraction);

            return fraction.Id;
        }

        public void Dispose() => _repository.Dispose();
    }
}