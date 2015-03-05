

1. Debug.Assert


2. throws

3. Guards, like Guard.ThrowIfNull(item), can do more that just encapsulate check and throw, e.g. getting localized message from storage or wrap/shield exception into more user friednly or less infor about server side.

```csharp
Guard.Greater(count,0,"Count should be greater then 0")
Guard.Greater(count,0,MyEnironemnt.CoutShouldBeGreater.Format(0))
```

4. Contracts. Static, dynamic and optional.

5. Bounded contexts

6. Immutability and options








