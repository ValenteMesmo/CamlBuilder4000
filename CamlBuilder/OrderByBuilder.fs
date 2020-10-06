namespace ValenteMesmo.CamlQueryBuilder.Internals

open ValenteMesmo.CamlQueryBuilder.Internals.Xml.XmlNodeFactories
open RowContentBuilderModule

type OrderByBuilder(parentBuild, fieldName) =
    member this.Build() =
        parentBuild |> concat <| createOrderByNode(fieldName)
        |> createQueryNode
        |> createViewNode

    member this.RowLimit number =        
        (
            parentBuild |> concat <| createOrderByNode(fieldName)
            |> createQueryNode
            , number
        )
        |> RowContentBuilder

and OrderByDescBuilder(parentBuild, fieldName) =    
    member this.Build() =
        parentBuild |> concat <| createOrderByDescNode(fieldName)
        |> createQueryNode
        |> createViewNode

    member this.RowLimit number =        
        (
            parentBuild |> concat <| createOrderByDescNode(fieldName)
            |> createQueryNode
            , number
        )
        |> RowContentBuilder