using System;
using System.Collections.Generic;
using System.Text;

namespace ArtimeticExpressionCaclulator
{
    public class Operands
    {
 
        //Gets a fraction value given string like 3/7 or 2_3/5 or 3
        public double? GetOperandValue(string number)
        {
            double? value = null;
            string[] values = number.Split(new char[] { '_', '/' }, StringSplitOptions.RemoveEmptyEntries);
            if(values.Length == 1)
            {
                if(double.TryParse(values[0], out double result))
                {
                    return result;
                }            
            }
            
            if(values.Length == 2 || values.Length == 3)
            {
                
                if(double.TryParse(values[0], out double fraction1) && double.TryParse(values[1], out double fraction2))
                {
                    if(values.Length == 2)
                    {
                        return fraction1 / fraction2;
                    }
                    
                    if (double.TryParse(values[2], out double fraction3))
                    {
                        return fraction1 + fraction2 / fraction3;
                    }
                }     
            }
            return value;

        }

        /// <summary>
        /// Formats the number to the out put like 1_7/8 or 7/8 or 8 etc..
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public string GetResult(double number)
        {
            string output = null;
            var result = number.ToString().Split('.', StringSplitOptions.RemoveEmptyEntries);
            if(result.Length == 1)
            {
                return result[0];
            }
            var fractionPart = result[result.Length - 1];
            var wholePart = result[0];
            StringBuilder fractionNoDigits = new StringBuilder();
            fractionNoDigits.Append("1");
            for (int i = 0; i < fractionPart.Length; i++)
            {
                fractionNoDigits.Append("0");
            }
            var decimalPart = int.Parse(fractionPart);
            var decimalPoint = int.Parse(fractionNoDigits.ToString());
            var gcd = GCD(decimalPart, decimalPoint);
            var fraction1 = decimalPart / gcd;
            var fraction2 = decimalPoint / gcd;
            if (wholePart != "0")
            {
                output = string.Format("{0}_{1}/{2}", wholePart, fraction1, fraction2);
            }
            else
            {
                output = string.Format("{0}/{1}",fraction1, fraction2);
            }
            return output;
        }

        /// <summary>
        /// Calculates expresions based on operands given and operations
        /// </summary>
        /// <param name="op1"></param>
        /// <param name="op2"></param>
        /// <param name="operatation"></param>
        /// <returns></returns>
        public double Calculate(double op1, double op2, char operatation)
        {
            double result = 0 ;
            switch(operatation)
            {
                case '+':
                    result = op1 + op2;
                    break;

                case '-':
                    result = op1 - op2;
                    break;

                case '*':
                    result = op1 * op2;
                    break;

                case '/':
                    result = op1 / op2;
                    break;

            }
            return result;
        }

        /// <summary>
        /// Calculate the Greater Common divisor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private int GCD(int a, int b)
        {
            if(b == 0)
            {
                return a;
            }
            return  GCD(b, a % b);
        }
    }
}
