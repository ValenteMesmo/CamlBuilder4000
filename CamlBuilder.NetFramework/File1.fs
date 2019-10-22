module File1

    open XmlNodeFactories

    type LogicalOperatorPicker(parentBuild) =
            member this.Build =
                parentBuild

            member this.And() =
                new FieldTypePicker(createAndNode parentBuild)

            member this.Or() =
                new FieldTypePicker(createOrNode parentBuild)

            member this.And(handler : FieldTypePicker -> LogicalOperatorPicker) =
                let result = handler(new FieldTypePicker(sprintf "%s"))
                new LogicalOperatorPicker(createAndNode parentBuild result.Build)

     and FieldTypePicker(parentBuild : string -> string) =
            member this.Build =
                parentBuild