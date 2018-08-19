using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace DynamicObjectCreationTest
{
    public static class FormatterServicesBuilderWithCachingWithGeneric<T>
    {
        private static readonly Type t = typeof(T); 
        private static readonly ConstructorInfo ctor = t.GetConstructors()[0];

        public static T Build()
        {
            var o = FormatterServices.GetUninitializedObject(t);
            return (T)ctor.Invoke(o, new object[] { });
        }
    }
}
