module RowContentBuilderModule

open ValenteMesmo.CamlQueryBuilder.Internals.Xml.XmlNodeFactories

type RowContentBuilder(parentBuild, number : int) =
    member this.Build() =
        parentBuild |> concat <| createRowLimitNode(number)
        |> createViewNode