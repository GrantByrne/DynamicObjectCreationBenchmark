using System;

namespace DynamicObjectCreationTest
{
    public static class ActivatorCreateBuilderWithoutGeneric
    {
        public static TestObject Build()
        {
            return (TestObject)Activator.CreateInstance(typeof(TestObject));
        }
    }
}
