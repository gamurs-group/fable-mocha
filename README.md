# Fable.Import.MochaJS

Fable bindings for [Mocha.js](https://mochajs.org/).


### Nuget Packages

Stable | Prerelease
--- | ---
[![NuGet Badge](https://buildstats.info/nuget/Fable.Import.MochaJS)](https://www.nuget.org/packages/Fable.Import.MochaJS/) | [![NuGet Badge](https://buildstats.info/nuget/Fable.Import.MochaJS?includePreReleases=true)](https://www.nuget.org/packages/Fable.Import.MochaJS/)


## Getting Started

### Build Configuration

See https://harry.vangberg.name/unit-testing-fable-with-mocha

### Example

#### Test Suite

```
module Test.Example

open Fable.Import.MochaJS

/// Assert that the expected and actual values are equal
let assertEqual expected actual: unit =
    Assert.AreEqual(actual, expected)

/// Assert that the expected and actual values are not equal
let assertNotEqual expected actual: unit =
    Assert.NotEqual(actual, expected)

describe "test suite" <| fun _ ->
    it "should do something poorly" <| fun _ ->
        assertEqual 1 2
    it "should do something well" <| fun _ ->
        assertEqual 2 2
    )
    it "should do something else well" <| fun _ ->
        assertNotEqual 23 65
|> ignore
```

#### Test Runner

You will also need to import side effects from *every test suite* in a main test runner, otherwise test suites
won't be detected by Mocha.

```
module Test.Main

open Fable.Core.JsInterop

importSideEffects "./TestSuiteA.fs"
importSideEffects "./TestSuiteB.fs"
// etc

```


## Development

### Building

Make sure the following **requirements** are installed in your system:

* [dotnet SDK](https://www.microsoft.com/net/download/core) 2.0 or higher
* [node.js](https://nodejs.org) 6.11 or higher
* [yarn](https://yarnpkg.com)
* [Mono](http://www.mono-project.com/) if you're on Linux or macOS.

Then you just need to type `./build.cmd` or `./build.sh`

### Release

In order to push the package to [nuget.org](https://nuget.org) you need to add your API keys to `NUGET_KEY` environmental variable.
You can create a key [here](https://www.nuget.org/account/ApiKeys).

- Update RELEASE_NOTES with a new version, data and release notes [ReleaseNotesHelper](http://fake.build/apidocs/fake-releasenoteshelper.html).
Ex:

```
#### 0.2.0 - 30.04.2017
* FEATURE: Does cool stuff!
* BUGFIX: Fixes that silly oversight
```

- You can then use the Release target. This will:
  - make a commit bumping the version: Bump version to 0.2.0
  - publish the package to nuget
  - push a git tag

`./build.sh Release`
