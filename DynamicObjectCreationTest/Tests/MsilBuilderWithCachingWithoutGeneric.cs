using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace DynamicObjectCreationTest
{
    public static class MsilBuilderWithCachingWithoutGeneric
    {
        public delegate object DynamicObjectActivator();
        private static readonly Dictionary<Type, DynamicObjectActivator> cache = new Dictionary<Type, DynamicObjectActivator>();

        public static object Build(Type t)
        {
            if(cache.TryGetValue(t, out DynamicObjectActivator value))
            {
                return value();
            }

            var dynamicMethod = new DynamicMethod("CreateInstance", t, Type.EmptyTypes, true);
            var ilGenerator = dynamicMethod.GetILGenerator();
            ilGenerator.Emit(OpCodes.Nop);
            ConstructorInfo emptyConstructor = t.GetConstructor(Type.EmptyTypes);
            ilGenerator.Emit(OpCodes.Newobj, emptyConstructor);
            ilGenerator.Emit(OpCodes.Ret);

            var del = (DynamicObjectActivator)dynamicMethod.CreateDelegate(typeof(DynamicObjectActivator));
            cache.Add(t, del);

            return del();
        }
    }
}
