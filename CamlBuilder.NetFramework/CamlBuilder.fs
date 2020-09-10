namespace ValenteMesmo.CamlQueryBuilder

open ValenteMesmo.CamlQueryBuilder.Internals
//where builder
//orderby
//viewfields
//row limit
//groupby

//CAML query to check if user is member of a specific group
//  using Membership

//TODO: remove view and query
[<AbstractClass; Sealed>]
type CamlBuilder private () =
    static member Where handler =
        handler
        |> WhereBuilder