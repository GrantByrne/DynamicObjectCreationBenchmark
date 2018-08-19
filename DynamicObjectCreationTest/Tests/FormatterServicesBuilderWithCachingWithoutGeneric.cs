using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace DynamicObjectCreationTest
{
    public static class FormatterServicesBuilderWithCachingWithoutGeneric
    {
        private static readonly Dictionary<Type, ConstructorInfo> cache = new Dictionary<Type, ConstructorInfo>();

        public static object Build(Type t)
        {
            if (cache.TryGetValue(t, out ConstructorInfo ctor))
            {
                var o = FormatterServices.GetUninitializedObject(t);
                return ctor.Invoke(o, new object[] { });
            }
            else
            {
                var o = FormatterServices.GetUninitializedObject(t);
                ctor = t.GetConstructors()[0];
                cache.Add(t, ctor);
                return ctor.Invoke(o, new object[] { });
            }
        }
    }
}
