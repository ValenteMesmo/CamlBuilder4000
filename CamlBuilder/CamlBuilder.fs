namespace ValenteMesmo.CamlQueryBuilder

open ValenteMesmo.CamlQueryBuilder.Internals
//viewfields
//groupby

//CAML query to check if user is member of a specific group
//  using Membership

[<AbstractClass; Sealed>]
type CamlBuilder private () =
    static member Where handler =
        handler
        |> WhereBuilder

    static member OrderBy fieldName =
        OrderByDescBuilder("", fieldName)

    static member OrderByDesc fieldName =
        OrderByDescBuilder("", fieldName)