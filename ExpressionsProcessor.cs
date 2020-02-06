using System;
using System.Collections.Generic;
using System.Text;

namespace ArtimeticExpressionCaclulator
{
    public class ExpressionsProcessor
    {
        Stack<double> operandHolder = new Stack<double>();
        Stack<Operators> operators = new Stack<Operators>();
        private Operands _operands;

        public ExpressionsProcessor(Operands operands)
        {
            _operands = operands;
        }

        /// <summary>
        /// Processes input expressions  by pushing operands to operands stack and operators to operators stack
        /// It will calculate values based on the BODMAS rule giving high precedence to Division and multiplication compared to addition or subtraction
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string Process(string input)
        {
            if(string.IsNullOrWhiteSpace(input))
            {
                return null;
            }
            var expressions = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach(var ch in expressions)
            {             
                if(IsOperator(ch[0]))
                {
                    var op = new Operators(ch[0]);
                    if (operators.Count == 0 || op.Precedence > operators.Peek().Precedence)
                    {
                        operators.Push(op);
                    }
                    else
                    {
                        while(operators.Count > 0 && op.Precedence <= operators.Peek().Precedence)
                        {
                            var oparator = operators.Pop();
                            var op1 = operandHolder.Pop();
                            var op2 = operandHolder.Pop();
                            var value = _operands.Calculate(op1, op2, oparator.Value);
                            operandHolder.Push(value);
                        }
                        operators.Push(op);
                    }
                   
                    
                }
                else
                {
                    var value =_operands.GetOperandValue(ch);
                    if(value != null)
                    {
                        operandHolder.Push(value.Value);
                    }
                    

                }
            }

            while (operators.Count > 0)
            {
                var oparator = operators.Pop();
                double op1, op2;
                if(operandHolder.Count > 0)
                {
                    op1 = operandHolder.Pop();
                }
                else
                {
                    throw new ArgumentException("Empty stack. Invalid input");
                }
                if (operandHolder.Count > 0)
                {
                    op2 = operandHolder.Pop();
                }
                else
                {
                    throw new ArgumentException("Empty stack. Invalid input");
                }

                var value = _operands.Calculate(op1, op2, oparator.Value);
                operandHolder.Push(value);
            }
          

            return GetCalculatedResult();
        }

        private bool IsOperator(char op)
        {
            bool result = false;
            switch (op)
            {
                case '+':                  
                case '-':                  
                case '*':                 
                case '/':
                    result = true;
                    break;

            }
            return result;
        }

        private string GetCalculatedResult()
        {
            if(operandHolder.Count > 0 )
            {
                var calculated = operandHolder.Pop();
                if(operandHolder.Count > 0 || operators.Count >0)
                {
                    //some input error
                    throw new ArgumentException("Empty stack. Invalid input");
                }
                var result = _operands.GetResult(calculated);
                return result;
            }

            throw new ArgumentException("Empty stack. Invalid input");
        }
    }
}
