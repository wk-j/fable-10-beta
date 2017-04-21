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

//type IJQuery = interface end

type IJQuery =
    abstract css : string * string -> IJQuery
    abstract addClass : string -> IJQuery

    [<Emit("$0.click($1)")>]
    abstract onClick : (obj -> unit) -> IJQuery

module JQuery =
    [<Emit("window['$']($0)")>]
    let select (selector: string) : IJQuery = jsNative

    [<Emit("window['$']($0)")>]
    let ready(handler: unit -> unit) : unit = jsNative

    [<Emit("$2.css($0,$1)")>]
    let css(prop: string) (value: string) (el: IJQuery) : IJQuery = jsNative

    //[<Emit("$1.addClass($0)")>]
    //let addClass(className: string) (el: IJQuery) : IJQuery = jsNative
    //let addClass(className: string) : IJQuery = jsNative

    //[<Emit("$1.click($0)")>]
    //let click(handler: obj -> unit) (el: IJQuery) : IJQuery = jsNative


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


    (*
    JQuery.ready(fun () ->
                 let div = JQuery.select "#main"
                 div
                 |> JQuery.css "background-color" "red"
                 |> JQuery.click (fun ev -> console.log "clicked")
                 |> JQuery.addClass "fancy-class"
                 |> ignore )
           *)
    JQuery.select("#main")
        .css("background-color", "lightblue")
        .css("font-size", "24px")
        .onClick(fun ev -> console.log("clicked")) |> ignore


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
