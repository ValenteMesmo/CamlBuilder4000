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

    member this.ThenBy(nextFieldName) =        
        ThenOrderByDescBuilder(
            parentBuild
            , createOrderFieldRef fieldName |> concat <| createOrderFieldRef nextFieldName
        )

    member this.ThenByDesc(nextFieldName) =        
        ThenOrderByDescBuilder(
            parentBuild
            , createOrderFieldRef fieldName |> concat <| createOrderFieldRefDesc nextFieldName
        )

and OrderByDescBuilder(parentBuild, fieldName) =    
    member this.Build() =
        parentBuild |> concat <| createOrderByDescNode(fieldName)
        |> createQueryNode           
    
    member this.RowLimit number =        
        (
            parentBuild |> concat <| createOrderByDescNode(fieldName)
            |> createQueryNode
            , number
        )
        |> RowContentBuilder

    member this.ThenBy(nextFieldName) =        
        ThenOrderByDescBuilder(
            parentBuild
            , createOrderFieldRefDesc fieldName |> concat <| createOrderFieldRef nextFieldName
        )

    member this.ThenByDesc(nextFieldName) =        
        ThenOrderByDescBuilder(
            parentBuild
            , createOrderFieldRefDesc fieldName |> concat <| createOrderFieldRefDesc nextFieldName
        )

and ThenOrderByDescBuilder(parentBuild, orderByContent) =
    member this.Build() =
        parentBuild |> concat <| createOrderBy(orderByContent)
        |> createQueryNode
        |> createViewNode

    member this.RowLimit number =        
        (
            parentBuild |> concat <| createOrderBy(orderByContent)
            |> createQueryNode
            , number
        )
        |> RowContentBuilder

    member this.ThenBy(nextFieldName) =        
        ThenOrderByDescBuilder(
            parentBuild
            , orderByContent |> concat <| createOrderFieldRef nextFieldName
        )

    member this.ThenByDesc(nextFieldName) =        
        ThenOrderByDescBuilder(
            parentBuild
            , orderByContent |> concat <| createOrderFieldRefDesc nextFieldName
        )
    