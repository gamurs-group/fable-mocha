# fable-mocha

Fable bindings for [Mocha](https://mochajs.org/).

## Build Configuration

See https://harry.vangberg.name/unit-testing-fable-with-mocha

## Example

```
open Fable.Import.Mocha

/// Assert that the expected and actual values are equal
let assertEqual expected actual: unit =
    Assert.AreEqual(actual, expected)

/// Assert that the expected and actual values are not equal
let assertNotEqual expected actual: unit =
    Assert.NotEqual(actual, expected)

describe "test suite" (fun _ ->
    it "should do something poorly" (fun _ ->
        assertEqual 1 2
    )
    it "should do something well" (fun _ ->
        assertEqual 2 2
    )
    it "should do something else well" (fun _ ->
        assertNotEqual 23 65
    )
)
|> ignore
```


