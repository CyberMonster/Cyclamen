using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Cyclamen
{
    public static class Extentions
    {
        public static void InjectProperties<T>(this T injectTarget, IServiceProvider serviceProvider) where T : class
        {
            var targetType = injectTarget.GetType();
            var targetMembers = targetType.GetMembers(BindingFlags.GetField
                    | BindingFlags.GetProperty
                    | BindingFlags.Instance
                    | BindingFlags.NonPublic
                    | BindingFlags.Public)
                .ToList();
            var injectableMembers = targetMembers.Where(m => m.CustomAttributes.Any(a => a.AttributeType == typeof(InjectAttribute)));

            List<Exception> errors = null;
            foreach (var member in injectableMembers)
            {
                var pInfo = member as PropertyInfo;
                var fInfo = member as FieldInfo;
                var memberType = pInfo?.PropertyType ?? fInfo.FieldType;
                if (!memberType.IsInterface)
                    (errors ??= new List<Exception>()).Add(
                        new NotSupportedException("Can't inject non interface type via property."));
                else
                    if (pInfo != null)
                        pInfo.SetValue(injectTarget, serviceProvider.GetService(memberType));
                    else
                        fInfo.SetValue(injectTarget, serviceProvider.GetService(memberType));
            }

            if (errors != null)
                throw new AggregateException(errors);
        }
    }
}
