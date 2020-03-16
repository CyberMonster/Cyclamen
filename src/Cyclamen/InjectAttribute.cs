using System;

namespace Cyclamen
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class InjectAttribute : Attribute { }
}
