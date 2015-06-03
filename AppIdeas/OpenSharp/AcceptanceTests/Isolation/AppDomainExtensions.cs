using System;

namespace AcceptanceTests.Helpers
{
    public static class AppDomainExtensions
    {
        public static T CreateInstanceAndUnwrap<T>(this AppDomain domain)
            where T : class
        {
            var assembly = typeof (T).Assembly.FullName;
            var type = typeof (T).FullName;
            return domain.CreateInstanceAndUnwrap(assembly, type) as T;
        }
    }
}