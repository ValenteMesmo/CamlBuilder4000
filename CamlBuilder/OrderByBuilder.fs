namespace ValenteMesmo.CamlQueryBuilder.Internals

open ValenteMesmo.CamlQueryBuilder.Internals.Xml.XmlNodeFactories
open ValenteMesmo.CamlQueryBuilder.Internals.PartPicker

type OrderByBuilder(fieldName) =    
    member this.Build() =
        fieldName
        |> createOrderByNode
        |> createQueryNode
        |> createViewNode

    member this.RowLimit number =        
        (
            fieldName
            |> createOrderByNode
            |> createQueryNode, number
        )
        |> RowContentBuilder

and OrderByDescBuilder(fieldName) =    
    member this.Build() =
        fieldName
        |> createOrderByDescNode
        |> createQueryNode
        |> createViewNode

    member this.RowLimit number =        
        (
            fieldName
            |> createOrderByDescNode
            |> createQueryNode, number
        )
        |> RowContentBuilder
        

//and RowContentBuilder(parentBuild, number : int) =
//    member this.Build() =
//        parentBuild |> concat <| createRowLimitNode(number)
//        |> createViewNode