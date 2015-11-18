


- cannot use `typeof(Void)` but `typeof(void)`

- cannot do next `g()()()("al")` generate `goooal` string, but Scala can

- cannot call lambda right after creation `()=> { }()`

- cannot `return MyMethod() ?? MyMethod2() ?? throw new Exception();`

- cannot path enumerable or array instead of params.

- IReadOnlyDictionary and KeyValuePair are not contrvariant but readonly. 