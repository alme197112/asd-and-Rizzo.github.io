
If you think F# is cool please look into these issues to see that F# is just OK.


#### Bitwice operators are verbose:

```fsharp
let a = 1 ||| 2
```

### Next will fail to compile

```fsharp
let a = "a" +"b" // fails to compile with  error FS0003: This value is not a function and cannot be applied
let b = "a" + "b" //correct with space after +
```
