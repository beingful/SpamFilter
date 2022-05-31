using MailService.DBModels;
using MailService.DBModels.Facades;
using System;
using System.Collections.Generic;

namespace MailService.SpamFiltering
{
    public class Probabilities<AttributeType> where AttributeType : struct
    {
        private readonly Dictionary<string, AttributeType> _vector;
        private readonly Func<int, int, AttributeType, float> _getProbability;

        public Probabilities(Dictionary<string, AttributeType> vector,
            Func<int, int, AttributeType, float> getProbability)
        {
            _vector = vector;
            _getProbability = getProbability;
        }

        private (int spam, int correspondence) GetModelParametres(string word)
        {
            using var facade = new WordInModelFacade();

            WordInModel model = facade.GetbyWord(word);

            return (model.Spam, model.Сorrespondence);
        }

        public IEnumerable<double> Calculate()
        {
            var probabilities = new List<double>(_vector.Count);

            foreach (var element in _vector)
            {
                var parametres = GetModelParametres(element.Key);
                float probability = _getProbability(parametres.spam, parametres.correspondence, element.Value);

                probabilities.Add(Math.Log10(probability));
            }

            return probabilities;
        }
    }
}