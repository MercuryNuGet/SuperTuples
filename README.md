# Super Tuples

An abstract replacement for .net Tuples.

## Key Features

1. `abstract`, built for descending from with:
1. No `public` members
1. Simple and [correct](http://stackoverflow.com/questions/35200738/any-good-reason-why-tuple-equals-does-not-check-exact-types) `Equals` and `GetHashCode` implementation
1. Optional cached `hash`
1. Verifiably Immutable

## Example

```
public class Person : Suple<string, string>
{
    public Person(string firstName, string lastName) : base(firstName, lastName, SupleHash.Cached)
    {
    }
    
    public string FirstName => Item1;
    public string LastName => Item2;
}
```

`Person` fully supports a correct equality contract, much like inheriting from `Tuple<string, string>`, but unlike inheriting from `Tuple<string, string>`:

1. `Item1` and `Item2` are `protected`, keeping intellisense clean and they shouldn't appear with most serializers. 
1. `Equals` and/or `GetHashCode` could be overridden if required without [breaking contract](http://stackoverflow.com/questions/35200738/any-good-reason-why-tuple-equals-does-not-check-exact-types).
1. The hash is cached for performance
