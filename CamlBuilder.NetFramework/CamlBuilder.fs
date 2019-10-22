namespace ValenteMesmo

open ValenteMesmo.Internals
//where builder
//orderby
//viewfields
//row limit
//groupby

//CAML query to check if user is member of a specific group
//  using Membership

[<AbstractClass; Sealed>]
type CamlBuilder private () =
    static member Where handler =
        new WhereBuilder(handler)