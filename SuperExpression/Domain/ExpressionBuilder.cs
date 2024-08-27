using SuperExpression.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SuperExpression.Domain
{
    public class ExpressionBuilder
    {
        public static Func<TKey, TValue> BuildIfElse<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
        {
            var parameter = Expression.Parameter(typeof(TKey), "zkey");

            Expression elseExpression = Expression.Default(typeof(TValue));
            foreach (var keyvalues in dictionary)
            {
                var caseKey = Expression.Constant(keyvalues.Key);
                var returnValue = Expression.Constant(keyvalues.Value);
                var comparation = Expression.Equal(parameter, caseKey);

                // puts the currentExpression on ifFalse
                var caseNode = Expression.Condition(comparation, returnValue, elseExpression);

                // get the new Expression as Switch expression
                elseExpression = caseNode;
            }
            var lambda = Expression.Lambda<Func<TKey, TValue>>(elseExpression, parameter);
            return lambda.Compile();
        }

        public static Func<TKey, TValue> BuildSwitch<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
        {
            var valueType = typeof(TValue);
            var parameter = Expression.Parameter(typeof(TKey), "zkey");
            var cases = new List<SwitchCase>();
            foreach (var keyvalues in dictionary)
            {
                var caseKey = Expression.Constant(keyvalues.Key);
                var returnValue = Expression.Constant(keyvalues.Value, valueType);
                var comparation = Expression.SwitchCase(returnValue, caseKey);

                // puts the cases in a list to put togheter on Switch
                cases.Add(comparation);
            }
            // default case returns null
            var defaultCase = Expression.Constant(default(TValue), valueType);
            var switchExpression = Expression.Switch(parameter, defaultCase, cases.ToArray());
            // if you add a breakpoint here, you'll see the logic expression;
            var lambda = Expression.Lambda<Func<TKey, TValue>>(switchExpression, parameter);
            return lambda.Compile();
        }

        public static void Switch<T>(T switchMatch, params T[] possibleValues)
        {
            Type type = typeof(T);
   
            var parameterBase = Expression.Parameter(type, "name1");
            var parameterComparer = Expression.Parameter(type, "name2");

            var comparerBase = Expression.Equal(parameterBase, parameterComparer);
            Func<T, T, bool> comparerFunction =
                Expression.Lambda<Func<T, T, bool>>(comparerBase, parameterBase, parameterComparer).Compile();


            int index = 0;
            LabelTarget gotoDestination = Expression.Label();

            var labelExpression = Expression.Label(gotoDestination);
            
            if (comparerFunction(switchMatch, possibleValues[index]) == false)
            {
                Expression.Return(gotoDestination);
            }


            Console.WriteLine($"{switchMatch} is equal to parameter index {index}, value {possibleValues[index]}");
        }
    }
}
