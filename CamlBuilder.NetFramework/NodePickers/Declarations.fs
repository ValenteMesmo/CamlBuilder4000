namespace ValenteMesmo.CamlQueryBuilder.Internals.PartPicker

type LogicalOperatorPicker internal (parentBuild) =
    member internal this.Build() : string = parentBuild

type FieldTypePicker internal (parentBuild : string -> string) =
    member internal this.Build() = parentBuild

type TextFieldFilterPicker internal (parentBuild : string -> string, fieldDefinition : string) =
    member internal this.Build(a) = parentBuild a
    member internal this.fieldDefinition = fieldDefinition 

type LookupFieldFilterPicker internal (parentBuild : string -> string, fieldDefinition : string) =        
    member internal this.fieldDefinition = fieldDefinition
    member internal this.Build = parentBuild

type LookupMultiFieldFilterPicker internal (parentBuild : string -> string, fieldDefinition : string) =        
    member internal this.fieldDefinition = fieldDefinition
    member internal this.Build = parentBuild

type DateFieldFilterPicker internal (parentBuild : string -> string, fieldDefinition : string) =        
    member internal this.fieldDefinition = fieldDefinition
    member internal this.Build = parentBuild

type BoolFieldFilterPicker internal (parentBuild : string -> string, fieldDefinition : string) =        
    member internal this.fieldDefinition = fieldDefinition
    member internal this.Build = parentBuild

type FileDirRefFilterPicker internal (parentBuild : string -> string, fieldDefinition : string) =        
    member internal this.fieldDefinition = fieldDefinition
    member internal this.Build = parentBuild