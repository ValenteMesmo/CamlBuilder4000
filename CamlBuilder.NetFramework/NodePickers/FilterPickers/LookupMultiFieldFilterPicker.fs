namespace ValenteMesmo.CamlQueryBuilder

open ValenteMesmo.CamlQueryBuilder.Internals.Xml.XmlNodeFactories
open ValenteMesmo.CamlQueryBuilder.Internals.PartPicker
open System.Runtime.CompilerServices

[<Extension>]
type LookupMultiFieldFilterPickerExtensions =

    [<Extension>]
    static member Contains(picker: LookupMultiFieldFilterPicker, value : int) =         

        new LogicalOperatorPicker(
            createEqualNode(
                picker.fieldDefinition 
                + createLookupValueNode(value)
            )
            |> picker.Build
        )