/// Cross-platform matchers that can be used in both native and fable-compiler tests.
module Matchers

/// The result of comparing a value against a matcher
type MatcherResult =
    | Success
    | Failure of expected : string
module private MatcherResult =
    let fromBoolean b expected =
        match b with
        | true -> Success
        | false -> Failure expected

/// Raised to indicate a failed match
exception MatcherFailure of string

/// Matchers are used to assert on test results, via <c>expect</c>
type Matcher<'actual> = 'actual -> MatcherResult

let private failedMatch expected actual : unit =
    let description = failwithf "Expected:\n\n%s\n\nActual:\n\n%s" expected actual
    raise (MatcherFailure description) |> ignore

/// <summary>
///     Assert using a matcher
/// </summary>
/// <param name="actual">
///     The actual value to which the matcher should be applied.
/// </param>
/// <param name="matcher">
///     The matcher to apply.
/// </param>
let expect (actual : 'actual) (matcher : Matcher<'actual>) : unit =
    let result = matcher actual
    match result with
    // Test case success indicated by unit return value
    | Success ->
        ()
    // Fail test case
    | Failure expected ->
        let actualStr = sprintf "%A" actual
        failedMatch expected actualStr


/// Usage: expect 1 <| equalTo 1
let equalTo (expected : 'a) (actual : 'a) : MatcherResult =
    let expectedStr = sprintf "%A" expected
    MatcherResult.fromBoolean (actual = expected) expectedStr

/// Usage: expect 1 <| notEqualTo 1
let notEqualTo (expected : 'a) (actual : 'a) : MatcherResult =
    let expectedStr = sprintf "%A" expected
    MatcherResult.fromBoolean (actual <> expected) expectedStr

/// Usage: expect actual <| isError
let isError (actual : Result<_,_>) : MatcherResult =
    match actual with
    | Error _ -> Success
    | _ -> Failure "Result.Error"
