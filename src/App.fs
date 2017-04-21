module Fable10

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Browser

[<Emit("undefined")>]
let undefined: obj = jsNative

[<Emit("1")>]
let one: int = jsNative

[<Emit("$0 === undefined")>]
let isUndefined(x: 'a) : bool = jsNative

[<Emit("isNaN(parseFloat($0)) ? null : parseFloat($0)")>]
let parseFloat (input: string) : float option = jsNative

let test() =
    console.log("Hello, world!")
    console.log(undefined)
    console.log( one + one + one)
    console.log(isUndefined 5)
    console.log(isUndefined "")
    console.log(isUndefined undefined)

    match parseFloat "335.83" with
    | Some value -> console.log(value)
    | None -> console.log("parseFloat failed")

let init() =
    let canvas = Browser.document.getElementsByTagName_canvas().[0]
    canvas.width <- 1000.
    canvas.height <- 800.
    let ctx = canvas.getContext_2d()
    // The (!^) operator checks and casts a value to an Erased Union type
    // See http://fable.io/docs/interacting.html#Erase-attribute
    ctx.fillStyle <- !^"rgb(200,0,0)"
    ctx.fillRect (10., 10., 55., 50.)
    ctx.fillStyle <- !^"rgba(0, 0, 200, 0.5)"
    ctx.fillRect (30., 30., 55., 50.)

test()
init()
