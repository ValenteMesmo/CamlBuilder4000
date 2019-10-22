namespace ValenteMesmo.CamlQueryBuilder

open ValenteMesmo.CamlQueryBuilder.Internals
//where builder
//orderby
//viewfields
//row limit
//groupby

//CAML query to check if user is member of a specific group
//  using Membership

[<AbstractClass; Sealed>]
type CamlQuery private () =
    static member Where handler =
        new WhereBuilder(handler)