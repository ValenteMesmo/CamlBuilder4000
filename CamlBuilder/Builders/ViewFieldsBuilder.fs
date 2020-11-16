namespace ValenteMesmo.CamlQueryBuilder.Internals

open ValenteMesmo.CamlQueryBuilder.Internals.Xml.XmlNodeFactories
open RowContentBuilderModule
open System

type ViewFieldsBuilder(parentBuild, fields) =        
    let viewFields =         
        fields 
        |> Seq.map (fun f -> createFieldRef f)
        |> String.concat ""
        |> createViewFields
    
    member this.Build() =
        parentBuild |> concat <| viewFields
        |> createViewNode

    member this.RowLimit number =        
        (
            parentBuild |> concat <| viewFields
            , number
        )
        |> RowContentBuilder

    member this.ThenBy(nextFieldName) =        
        ThenOrderByDescBuilder(
            parentBuild
            , viewFields |> concat <| createOrderFieldRef nextFieldName
        )

    member this.ThenByDesc(nextFieldName) =        
        ThenOrderByDescBuilder(
            parentBuild
            , viewFields |> concat <| createOrderFieldRefDesc nextFieldName
        )