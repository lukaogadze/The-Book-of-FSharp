// Additional Members
#load "Shared.fsx";

type Markup =
    | ContentElement of string * Markup list
    | EmptyElement of string
    | Content of string
    member x.toHtml() =
        match x with
        | ContentElement (tag, children) ->
            use w = new System.IO.StringWriter()
            children
                |> Seq.map (fun m -> m.toHtml())
                |> Seq.iter (fun (Shared.HtmlString(html)) -> w.Write(html))
            Shared.HtmlString (sprintf "<%s>%s</%s>" tag (w.ToString()) tag)
        | EmptyElement (tag) -> Shared.HtmlString (sprintf "<%s />" tag)
        | Content (c) -> Shared.HtmlString (sprintf "%s" c)

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


movieList.toHtml() |> fun (Shared.HtmlString(html)) -> html |> printfn "%s"