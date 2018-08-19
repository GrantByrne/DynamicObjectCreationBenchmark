using System.Runtime.Serialization;

namespace DynamicObjectCreationTest
{
    public static class FormatterServicesBuilderWithoutCachingWithGeneric<T>
    {
        public static T Build()
        {
            var t = typeof(T);
            var o = FormatterServices.GetUninitializedObject(t);
            var ctor = t.GetConstructors()[0];
            return (T)ctor.Invoke(o, new object[] { });
        }
    }
}
