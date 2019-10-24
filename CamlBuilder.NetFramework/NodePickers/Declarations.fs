namespace ValenteMesmo.CamlQueryBuilder.Internals.PartPicker

open ValenteMesmo.CamlQueryBuilder.Internals.Xml.XmlNodeFactories

type LogicalOperatorPicker(parentBuild) =
    member internal this.Build() : string = parentBuild

type FieldTypePicker(parentBuild : string -> string) =
    member internal this.Build() = parentBuild

type TextFieldFilterPicker(parentBuild : string -> string, fieldDefinition : string) =
    member internal this.Build(a) = parentBuild a
    member internal this.fieldDefinition = fieldDefinition 

type LookupIdFieldFilterPicker(parentBuild : string -> string, fieldDefinition : string) =        
    member internal this.fieldDefinition = fieldDefinition
    member internal this.Build = parentBuild

type DateFieldFilterPicker(parentBuild : string -> string, fieldDefinition : string) =        
    member internal this.fieldDefinition = fieldDefinition
    member internal this.Build = parentBuild