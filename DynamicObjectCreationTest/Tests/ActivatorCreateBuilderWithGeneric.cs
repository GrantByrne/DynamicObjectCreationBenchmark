using System;

namespace DynamicObjectCreationTest
{
    public static class ActivatorCreateBuilderWithGeneric
    {
        public static TestObject Build()
        {
            return Activator.CreateInstance<TestObject>();
        }
    }
}
