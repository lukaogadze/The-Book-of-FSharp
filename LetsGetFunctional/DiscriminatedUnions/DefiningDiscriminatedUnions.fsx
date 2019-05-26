(*Defining Discriminated Unions*)
#load "Shared.fsx";

let showValue v =
    printfn "%s" <| match v with
                    | Some x -> x.ToString()
                    | None -> "None"

Some 123 |> showValue

Some "abc" |> showValue

None |> showValue

(*OOP Version*)
type IShape = interface end

type Circle(r : float) =
    interface IShape
    member x.Radius = r

type Rectangle(w : float, h : float) =
    interface IShape
    member x.Width = w
    member x.Height = h

type Triangle(l1 : float, l2 : float, l3 : float) =
    interface IShape
    member x.Leg1 = l1
    member x.Leg2 = l2
    member x.Leg3 = l3

(*FP Version*)
//type Shape =
//    | Circle of float
//    | Rectangle of float * float
//    | Triangle of float * float * float

type Shape =
    | Circle of Radius : float
    | Rectangle of Width : float * Height : float
    | Triangle of Leg1 : float * Leg2 : float * Leg3 : float

let c = Circle(Radius = 3.0)
let r = Rectangle(Width = 10.0, Height = 12.0)
let t = Triangle(Leg1 = 125.0, Leg2 = 20.0, Leg3 = 7.0)

type Markup =
    | ContentElement of string * Markup list
    | EmptyElement of string
    | Content of string

let movieList =
    ContentElement("html",
        [ ContentElement("head", [ ContentElement("title", [ Content "Guilty Pleasures" ])])
          ContentElement("body",
                [ ContentElement("article",
                    [ ContentElement("h1", [ Content "Some Guilty Pleasures" ])
                      ContentElement("p",
                        [ Content "These are "
                          ContentElement("strong", [ Content "a few" ])
                          Content " of my guilty pleasures" ])
                      ContentElement("ul",
                        [ ContentElement("li", [ Content "Crank (2006)" ])
                          ContentElement("li", [ Content "Starship Troopers (1997)" ])
                          ContentElement("li", [ Content "RoboCop (1987)" ])])])])])


let rec toHtml markup =
    match markup with
    | ContentElement (tag, children) ->
        use w = new System.IO.StringWriter()
        children
            |> Seq.map toHtml
            |> Seq.iter (fun (s : string) -> w.Write(s))
        sprintf "<%s>%s</%s>" tag (w.ToString()) tag
    | EmptyElement (tag) -> sprintf "<%s />" tag
    | Content (c) -> sprintf "%s" c

movieList |> toHtml

open System.IO


let displayHtml (Shared.HtmlString(html)) =
    let fn = Path.Combine(Path.GetTempPath(), "HtmlDemo.htm")
    let bytes = System.Text.UTF8Encoding.UTF8.GetBytes html
    using (new FileStream(fn, FileMode.Create, FileAccess.Write))
          (fun fs -> fs.Write(bytes, 0, bytes.Length))
    System.Diagnostics.Process.Start(fn).WaitForExit()
    File.Delete fn

Shared.HtmlString(movieList |> toHtml) |> displayHtml