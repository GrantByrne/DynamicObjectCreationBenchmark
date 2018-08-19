using System;
using System.Linq.Expressions;

namespace DynamicObjectCreationTest
{
    public static class LinqBuilderWithoutCachingWithGeneric
    {
        public static T Build<T>()
        {
            var t = typeof(T);
            var ex = new Expression[] { Expression.New(t) };
            var block = Expression.Block(t, ex);
            var builder = Expression.Lambda<Func<T>>(block).Compile();
            return builder();
        }
    }
}
