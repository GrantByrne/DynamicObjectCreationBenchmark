using System;
using System.Reflection;
using System.Reflection.Emit;

namespace DynamicObjectCreationTest
{
    public static class MsilBuilderWithoutCachingWithGeneric<T>
    {
        public delegate T DynamicObjectActivator();

        public static T Build()
        {
            var t = typeof(T);
            var dynamicMethod = new DynamicMethod("CreateInstance", t, Type.EmptyTypes, true);
            var ilGenerator = dynamicMethod.GetILGenerator();
            ilGenerator.Emit(OpCodes.Nop);
            ConstructorInfo emptyConstructor = t.GetConstructor(Type.EmptyTypes);
            ilGenerator.Emit(OpCodes.Newobj, emptyConstructor);
            ilGenerator.Emit(OpCodes.Ret);
            var del = (DynamicObjectActivator)dynamicMethod.CreateDelegate(typeof(DynamicObjectActivator));
            return del();
        }
    }
}
