using System;
using System.Diagnostics;

namespace Polynomial
{
    public class Polynomial
    {
        private LinkedList<Term> terms;

        public int NumberOfTerms => terms.Count;

        public int Degree => NumberOfTerms == 0 ? 0 : terms.First.Value.Power;

        public Polynomial()
        {
            terms = new LinkedList<Term>();
        }

        
        public void AddTerm(double coeff, int power)
        {
            var currentNode = terms.First;
            while (currentNode != null)
            {

                // check for matching power
                if (power == currentNode.Value.Power)
                {
                    currentNode.Value.Coefficient += coeff;
                    if (currentNode.Value.Coefficient == 0.0)
                    {
                        terms.Remove(currentNode);
                        return;
                    }
                    return;
                }

                // check for lesser power
                if (power > currentNode.Value.Power)
                {
                    var newTerm = new Term(power, coeff);
                    if (currentNode.Value.Coefficient == 0.0)
                    {
                        terms.Remove(currentNode);
                        return;
                    }
                    terms.AddBefore(currentNode, newTerm);
                    return;
                }

                currentNode = currentNode.Next;
            }
           
            // Add new term to end of list
            terms.AddLast(new Term(power, coeff));
            
        }

        
        public override string ToString()
        {
            string result = "";
           if (NumberOfTerms == 0)
                {
                    result = "0";                  
                }
            foreach (var term in terms)
            {                
                if (term.Power == 0)
                {
                    result += term.ToString();
                }

                if ( term.Power > 0) 
                {
                    if (term.Coefficient == 0.0)
                    {
                        result = "0";
                    }
                  
                    else 
                    { 
                        result += term.ToString() + "+"; 
                    }
                    
                }


            }
            return result;
            
        }

        public static Polynomial Add(Polynomial p1, Polynomial p2)
        {
            Polynomial sum = new Polynomial();

            // add all the terms from p1 to sum
            foreach (var term in p1.terms)
            {
                sum.AddTerm(term.Coefficient, term.Power);
            }

            // add all the terms from p2 to sum
            foreach (var term in p2.terms)
            {
                sum.AddTerm(term.Coefficient, term.Power);
            }
            
            return sum;
        }

        public static Polynomial Subtract(Polynomial p1, Polynomial p2)
        {
            Polynomial difference = new Polynomial();
            // add all the terms from p1 to sum
            foreach (var term in p1.terms)
            {
                difference.AddTerm(term.Coefficient, term.Power);
            }

            // add all the terms from p2 to sum
            foreach (var term in p2.terms)
            {
                difference.AddTerm(term.Coefficient * -1, term.Power);
            }

            return difference;
        }

        public static Polynomial Negate(Polynomial p)
        {
            Polynomial inverse = new Polynomial();

            foreach (var term in p.terms)
            {
                
                inverse.AddTerm((term.Coefficient * -1), term.Power);
            }

            return inverse;
        }

        public static Polynomial Multiply(Polynomial p1, Polynomial p2)
        {
            Polynomial Product = new Polynomial();

            foreach(var p1term in p1.terms)
            {
                foreach(var p2terms in p2.terms)
                {
                    var newCoeff = (p1term.Coefficient) * (p2terms.Coefficient);
                    var newPower = (p1term.Power) + (p2terms.Power);

                    Product.AddTerm(newCoeff, newPower);
                }
            }


            return Product;
        }


    }
}

