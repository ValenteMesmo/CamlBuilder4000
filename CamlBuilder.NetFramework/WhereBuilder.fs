namespace ValenteMesmo.CamlQueryBuilder.Internals

open ValenteMesmo.CamlQueryBuilder.Internals.Xml.XmlNodeFactories
open ValenteMesmo.CamlQueryBuilder.Internals.PartPicker

type WhereBuilder(handler : FieldTypePicker -> LogicalOperatorPicker) =        
    let whereContent = handler(new FieldTypePicker(fun f -> f))
    member this.Build() = createWhereNode <| whereContent.Build()
    //member this.OrderBy fieldName = ""