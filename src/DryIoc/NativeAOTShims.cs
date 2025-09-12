#if !DRYIOC_DISABLE_SHIMS
#if NETSTANDARD || NETFRAMEWORK
using System;

namespace System.Diagnostics.CodeAnalysis
{
    // Internal shim: visible inside DryIoc assembly only, avoids exposing shim to library consumers.
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method |
                    AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter,
                    Inherited = false, AllowMultiple = false)]
    internal sealed class DynamicallyAccessedMembersAttribute : Attribute
    {
        public DynamicallyAccessedMembersAttribute(DynamicallyAccessedMemberTypes memberTypes) => MemberTypes = memberTypes;
        public DynamicallyAccessedMemberTypes MemberTypes { get; }
    }

    [Flags]
    internal enum DynamicallyAccessedMemberTypes
    {
        All = -1, //Specifies all members.
        None = 0, //Specifies no members.
        PublicParameterlessConstructor = 1, //Specifies the default, parameterless public constructor.
        PublicConstructors = 3, //Specifies all public constructors.
        NonPublicConstructors = 4, //Specifies all non-public constructors.
        PublicMethods = 8, //Specifies all public methods.
        NonPublicMethods = 16, //Specifies all non-public methods.
        PublicFields = 32, //Specifies all public fields.
        NonPublicFields = 64, //Specifies all non-public fields.
        PublicNestedTypes = 128, //Specifies all public nested types.
        NonPublicNestedTypes = 256, //Specifies all non-public nested types.
        PublicProperties = 512, //Specifies all public properties.
        NonPublicProperties = 1024, //Specifies all non-public properties.
        PublicEvents = 2048, //Specifies all public events.
        NonPublicEvents = 4096, //Specifies all non-public events.
        Interfaces = 8192, //Specifies all interfaces implemented by the type.
    }
}
#endif
#endif