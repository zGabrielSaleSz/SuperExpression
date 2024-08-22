using System;
using System.Collections.Generic;

namespace SuperExpression.Core
{
    public interface IExpressionBuilder
    {
        void Switch<T>(T switchMatch, params T[] possibleValues);
        Func<TKey, TValue> BuildSwitch<TKey, TValue>(IDictionary<TKey, TValue> dictionary);
    }
}
