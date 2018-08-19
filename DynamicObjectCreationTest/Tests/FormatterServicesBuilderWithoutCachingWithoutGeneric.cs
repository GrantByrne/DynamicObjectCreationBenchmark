using System;
using System.Runtime.Serialization;

namespace DynamicObjectCreationTest
{
    // Formatter Services
    public static class FormatterServicesBuilderWithoutCachingWithoutGeneric
    {
        public static object Build(Type t)
        {
            var o = FormatterServices.GetUninitializedObject(t);
            var ctor = t.GetConstructors()[0];
            return ctor.Invoke(o, new object[] { });
        }
    }
}
