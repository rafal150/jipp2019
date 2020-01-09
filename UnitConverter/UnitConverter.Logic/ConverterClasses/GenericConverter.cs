using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace UnitConversion
{
    [ConverterClassType(ClassType.Universal)]
    public class GenericConverter : UnitConverter
    {
        private string name = "Konwerter";
        public override string Name
        {
            get => name;
            set => name = value;
        }

        public GenericConverter(string name, List<ConverterUnitDTO> units)
        {
            Name = name;
            FillUnits(units);
        }

        private void FillUnits(List<ConverterUnitDTO> units)
        {
            this.units = new Dictionary<string, Unit>();
            foreach (ConverterUnitDTO cudto in units)
            {
                this.units.Add(cudto.Name, new Unit(cudto.Name, GetFunctionFromString(cudto.ConversionFromBaseValueFormula), GetFunctionFromString(cudto.ConversionToBaseValueFormula)));   
            }
        }

        private Func<decimal, decimal> GetFunctionFromString(string expressionString)
        {
            string pattern = @"([][+-/*()])";
            string[] expressionsParts = RemoveEmptyEntries(Regex.Split(expressionString.Replace(" ", ""), pattern));
            ParameterExpression paramX = null;
            Expression expression = SeparateExpressions(expressionsParts, ref paramX);
            return Expression.Lambda<Func<decimal, decimal>>(expression, paramX).Compile();
        }

        private Expression SeparateExpressions(string[] expression, ref ParameterExpression parameterExpression)
        {
            int operatorIndex = -1;
            int bracketCounter = 0;

            for (int i = 0; i < expression.Length; i++)
            {
                string chars = expression[i];
                if (chars == "(")
                    bracketCounter++;
                else if (chars == ")") bracketCounter--;
                else if (bracketCounter == 0 && (chars == "+" || chars == "-"))
                {
                    operatorIndex = i;
                    break;
                }
                else if (bracketCounter == 0 && operatorIndex < 0 && (chars == "*" || chars == "/"))
                    operatorIndex = i;
            }

            if (operatorIndex < 0)
            {
                if (expression[0] == "(" && expression[expression.Length - 1] == ")")
                {
                    int expressionLength = expression.Length;
                    return SeparateExpressions(expression.Skip(1).Take(expressionLength - 2).ToArray(), ref parameterExpression);
                }
                else
                {
                    return GetExpressionFromStringValue(expression[0], ref parameterExpression);
                }

            }
            else
            {
                string operatorString = expression[operatorIndex];
                Expression expressionLeft = SeparateExpressions(expression.Take(operatorIndex).ToArray(), ref parameterExpression);
                Expression expressionRight = SeparateExpressions(expression.Skip(operatorIndex + 1).ToArray(), ref parameterExpression);
                return CombineExpressions(expressionLeft, expressionRight, operatorString);
            }
        }

        private static string[] RemoveEmptyEntries(string[] array)
        {
            List<string> list = new List<string>(array);
            return list.Where(x => string.IsNullOrWhiteSpace(x) == false).ToArray();
        }

        private Expression GetExpressionFromStringValue(string val, ref ParameterExpression parameterExpression)
        {
            Expression valExpression;
            if (decimal.TryParse(val.Replace(",", "."), System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out decimal val1Decimal))
            {
                valExpression = Expression.Constant(decimal.Parse(val.Replace(",", "."), System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture), typeof(decimal));
            }
            else
            {
                valExpression = Expression.Parameter(typeof(decimal), val);
                parameterExpression = valExpression as ParameterExpression;
            }

            return valExpression;
        }

        private Expression CombineExpressions(Expression val1Expression, Expression val2Expression, string sign)
        {
            if (sign == "+")
                return Expression.Add(val1Expression, val2Expression);
            else if (sign == "-")
                return Expression.Subtract(val1Expression, val2Expression);
            else if (sign == "*")
                return Expression.Multiply(val1Expression, val2Expression);
            else
                return Expression.Divide(val1Expression, val2Expression);
        }
    }
}
