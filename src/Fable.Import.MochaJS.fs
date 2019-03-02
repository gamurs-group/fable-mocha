/// Fable bundings for Mocha, see https://mochajs.org/
module Fable.Import.MochaJS

open Fable.Core

let [<Global>] describe (title : string) (f : unit -> unit) = jsNative
let [<Global>] xdescribe (title : string) (f : unit -> unit) = jsNative
let [<Global>] context (title : string) (f : unit -> unit) = jsNative
let [<Global>] xcontext (title : string) (f : unit -> unit) = jsNative
let [<Global>] it (msg : string) (f : unit -> unit) = jsNative
let [<Global>] xit (msg : string) (f : unit -> unit) = jsNative
let [<Global>] specify (msg : string) (f : unit -> unit) = jsNative
let [<Global>] xspecify (msg : string) (f : unit -> unit) = jsNative
let [<Global>] before (name : string) (f : unit -> unit) = jsNative
let [<Global>] beforeEach (name : string) (f : unit -> unit) = jsNative
let [<Global>] after (name : string) (f : unit -> unit) = jsNative
let [<Global>] afterEach (name : string) (f : unit -> unit) = jsNative
