using System;
using System.Collections.Generic;

namespace TwoOneTwoGames.UIManager.Utilities
{
    public static class ReflectionHelpers
    {
        public static Type[] GetAllDerivedTypes(this AppDomain aAppDomain, Type aType)
        {
            var result = new List<Type>();
            var assemblies = aAppDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes();
                foreach (var type in types)
                    if (type.IsSubclassOf(aType))
                        result.Add(type);
            }

            return result.ToArray();
        }
    }
}