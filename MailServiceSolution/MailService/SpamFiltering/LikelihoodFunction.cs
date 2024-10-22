﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MailService
{
    public class LikelihoodFunction
    {
        private readonly Result _bernoulli;
        private readonly Result _polynomial;

        public LikelihoodFunction(IEnumerable<Result> bernoulliResult,
            IEnumerable<Result> polynomialResult)
        {
            _bernoulli = GetResult(bernoulliResult);
            _polynomial = GetResult(polynomialResult);
        }

        private Result GetResult(IEnumerable<Result> results)
        {
            results = results.OrderByDescending(result => result.Probability);

            return results.First();
        }

        private int PseudorandomNumber(int from, int to)
        {
            Random random = new Random();

            return random.Next(from, to);
        }

        private int GetBound(ValueType value) => Convert.ToInt32(value);

        private double Approximation(double probability, double number)
        {
            return Math.Abs(probability - number);
        }

        private string GetPseudorandomCategory()
        {
            string emailCategory;

            int to = Math.Max(GetBound(_bernoulli.Probability), GetBound(_polynomial.Probability));
            int from = Math.Min(GetBound(_bernoulli.Probability), GetBound(_polynomial.Probability));

            double number = PseudorandomNumber(from, to);

            if (Approximation(_bernoulli.Probability, number)
                > Approximation(_polynomial.Probability, number))
            {
                emailCategory = _bernoulli.Category;
            }
            else
            {
                emailCategory = _polynomial.Category;
            }

            return emailCategory;
        }

        public string ClassifyEmail()
        {
            string emailCategory;

            if (_bernoulli.Category == _polynomial.Category)
            {
                emailCategory = _bernoulli.Category;
            }
            else
            {
                emailCategory = GetPseudorandomCategory();
            }

            return emailCategory;
        }
    }
}