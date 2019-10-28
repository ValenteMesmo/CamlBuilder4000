namespace ValenteMesmo.CamlQueryBuilder

open ValenteMesmo.CamlQueryBuilder.Internals.Xml.XmlNodeFactories
open ValenteMesmo.CamlQueryBuilder.Internals.PartPicker
open System.Runtime.CompilerServices

[<Extension>]
type LookupFieldFilterPickerExtensions =

    [<Extension>]
    static member IsEqualTo(picker: LookupFieldFilterPicker, value : int) =         

        new LogicalOperatorPicker(
            createEqualNode(
                picker.fieldDefinition 
                + createLookupValueNode(value)
            )
            |> picker.Build
        )