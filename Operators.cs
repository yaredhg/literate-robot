

namespace ArtimeticExpressionCaclulator
{
    public class Operators
    {
        public char Value { get; set; }
        public int Precedence { get; set; }

        public Operators(char value)
        {
            Value = value;
            Precedence = GetPreference(value);
        }
        /// <summary>
        /// This will give Division and multiplication higher precedence
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private int GetPreference(char value)
        {
            int result = 1;
            switch (value)
            {                
                case '*':
                case '/':
                    result = 2;
                    break;

            }
            return result;
        }
    }
}
