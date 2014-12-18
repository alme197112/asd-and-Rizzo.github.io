
publoc void Do(object item,int count){

if (item == null)   throw new ArgumentNullException("item")
if (count <= 0) throw new ArgumentException("count","Count should be greater then 0")
 }


publoc void Do(object item,int count){

if (item == null)  throw new ArgumentNullException(nameof(item))

 }
 
1. Guards, like Guard.ThrowIfNull(item), can do more that just encapsulate check and throw, e.g. getting localized message from storage or wrap/shield exception into more user friednly or less infor about server side
2. Contract, Requires 
3. Cotract clause after ususal throws
4. Debug.Assert


C# allows skip Attribute suffix when applied.

if (item == null)   throw new ArgumentNull(nameof(item))


Some language (as I know F# and Scale) allow skip 'new'
if (item == null)  throw ArgumentNullException(nameof(item))




With static methods we can do this (but need to import some static class),e.g

namespace System{
public static class Excpetions{
  ArgumentNullException ArgumentNull(string name){
  return new ArgumentNull(name)
  }
  ..
}
}

using System.Exceptions;

if (item == null) throw ArgumentNull(nameof(item))

Also possile to use existing '?' for if check:

item == null ? throw ArgumentNull(nameof(item))
item ?? throw ArgumentNull(nameof(item))


```
if (count <= 0) throw new Argument(nameof(count),"Count should be greater then 0")
if (count <= 0) throw  ArgumentException(nameof(count),"Count should be greater then 0")
if (count <= 0) throw new ArgumentException(nameof(count),"Count should be greater then 0")
if (count <= 0) throw Argument(nameof(count),"Count should be greater then 0")
count <= 0 ? throw Argument(nameof(count),"Count should be greater then 0")
Contract.Requires<int>(x=> x > 0, "Count should be greater then 0")
Debug.Assert(count > 0, "

Guard.Greater(count,0,"Count should be greater then 0")
Guard.Greater(count,0,MyEnironemnt.CoutShouldBeGreater.Format(0))
```





