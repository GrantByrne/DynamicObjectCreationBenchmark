using System;
using System.Linq.Expressions;

namespace DynamicObjectCreationTest
{
    public static class LinqBuilderWithCachingWithGeneric<T>
    {
        private static readonly Type t = typeof(T);
        private static readonly Expression[] ex = new Expression[] { Expression.New(t) };
        private static readonly BlockExpression block = Expression.Block(t, ex);
        private static readonly Func<T> builder = Expression.Lambda<Func<T>>(block).Compile();

        public static T Build()
        {
            return builder();
        }
    }
}
