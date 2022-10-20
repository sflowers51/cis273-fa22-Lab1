using System;
namespace Polynomial
{
    public class Term
    {
        public int Power { get; set; }
        public double Coefficient { get; set; }

        public Term(int power, double coefficient)
        {
            Power = power;
            Coefficient = coefficient;
        }

        public override string ToString()
        {
            if (Power == 0)
            {
                return $"{Coefficient}";
            }
            
            if (Coefficient == 0)
            {
                Power = 0;
                return $"{Coefficient}";
            }

            return $"{Coefficient}x^{Power}";
        }

    }
}
