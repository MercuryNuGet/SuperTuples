using System;
using System.Linq;
using System.Reflection;
using Mercury;
using NUnit.Framework;

namespace SuperTuples.Test
{
    public static class TypeSpecAssertExtensions
    {
        public static IPostAssertCaseBuilder<Type, Type> AssertIsAbstract(this IAssertCaseBuilder<Type, Type> caseBuilder)
        {
            return caseBuilder.Assert("is abstract", (type, _) => Assert.IsTrue(type.IsAbstract));
        }

        public static IPostAssertCaseBuilder<Type, Type> AssertIsPublic(this IAssertCaseBuilder<Type, Type> caseBuilder)
        {
            return caseBuilder.Assert("is public", (type, _) => Assert.IsTrue(type.IsPublic));
        }

        public static IPostAssertCaseBuilder<Type, Type> AssertHasNoNewPublicMembers(this IAssertCaseBuilder<Type, Type> caseBuilder)
        {
            return caseBuilder.Assert("has no new public members",
                (type, _) => CollectionAssert.AreEquivalent(new[] { "Equals", "GetHashCode", "ToString" },
                    type.GetMembers(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).Select(m => m.Name)));
        }

        public static IPostAssertCaseBuilder<Type, Type> AssertHasNoPublicFields(this IAssertCaseBuilder<Type, Type> caseBuilder)
        {
            return caseBuilder.Assert("has no public fields",
                (type, _) => CollectionAssert.IsEmpty(type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)));
        }

        public static IPostAssertCaseBuilder<Type, Type> AssertHasNoWritableFields(this IAssertCaseBuilder<Type, Type> caseBuilder)
        {
            return caseBuilder.Assert("has no writable fields",
                (type, _) => CollectionAssert.IsEmpty(type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                    .Where(f => !f.IsInitOnly)));
        }

        public static IPostAssertCaseBuilder<Type, Type> AssertStandardSupleTypeRestrictions(this IStaticArrangedWithData<Type> arranged)
        {
            return arranged
                .Act((data) => data)
                .AssertIsAbstract()
                .AssertIsPublic()
                .AssertHasNoNewPublicMembers()
                .AssertHasNoPublicFields()
                .AssertHasNoWritableFields();
        }
    }
}
