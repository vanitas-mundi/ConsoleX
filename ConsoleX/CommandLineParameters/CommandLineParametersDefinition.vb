Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace CommandLineParameters

  Public Class CommandLineParametersDefinition

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    '''<summary>Liefert die Parameter als CommandLineParameterInfoCollection.</summary>
    Private ReadOnly Property Parameters As New CommandLineParameterInfoCollection
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary>Fügt ein nicht-optionales Argument der Definition hinzu.</summary>
    Public Sub AddArgument()
      AddArgument(New ArgumentDefinitionInfo)
    End Sub

    '''<summary>Fügt ein nicht-optionales Argument der Definition hinzu.</summary>
    Public Sub AddArgument(ByVal info As ArgumentDefinitionInfo)

      Dim parameter = New CommandLineParameterInfo With {
      .Type = Enums.CommandLineParameterTypes.Argument,
      .Name = info.Name,
      .ValueName = info.ValueName,
      .ValueType = Enums.CommandLineParameterValueTypes.HasValue,
      .HelpDescription = info.HelpDescription
      }
      Parameters.Add(parameter)
    End Sub

    '''<summary>
    '''Fügt ein optionales Argument der Definition hinzu. 
    '''Wird in der Commandline dieser nicht angegeben, dann wird der hinterlegte Standardwert benutz.
    '''Wird das erste optionale Argument der Definition hinzugefügt, dann dürfen keine weiteren
    '''nicht-optionalen Argumente folgen.
    '''</summary>
    Public Sub AddOptionalArgument()
      AddOptionalArgument(New OptionalArgumentDefinitionInfo)
    End Sub

    '''<summary>
    '''Fügt ein optionales Argument der Definition hinzu. 
    '''Wird in der Commandline dieser nicht angegeben, dann wird der hinterlegte Standardwert benutz.
    '''Wird das erste optionale Argument der Definition hinzugefügt, dann dürfen keine weiteren
    '''nicht-optionalen Argumente folgen.
    '''</summary>
    Public Sub AddOptionalArgument(ByVal info As OptionalArgumentDefinitionInfo)

      Dim parameter = New CommandLineParameterInfo With {
      .Type = Enums.CommandLineParameterTypes.OpionalArgument,
      .Name = info.Name,
      .ValueType = Enums.CommandLineParameterValueTypes.HasValue,
      .ValueName = info.ValueName,
      .DefaultValue = info.DefaultValue,
      .HelpDescription = info.HelpDescription
      }
      Parameters.Add(parameter)
    End Sub

    '''<summary>
    '''Fügt eine Option der Definition hinzu. Optionen werden immer benannt und können optional über
    '''einen Langnamen verfügen.
    '''Wird in der Commandline die Option nicht angegeben, wird die Option verworfen oder bei Angabe 
    '''eines Standardwerts dieser benutzt. Bei Angabe ohne Wert gilt die Option als gesetzt.
    '''</summary>
    Public Sub AddOption(ByVal name As String)

      AddOption(New OptionDefinitionInfo With {.Name = name})
    End Sub

    '''<summary>
    '''Fügt eine Option der Definition hinzu. Optionen werden immer benannt und können optional über
    '''einen Langnamen verfügen.
    '''Wird in der Commandline die Option nicht angegeben, wird die Option verworfen oder bei Angabe 
    '''eines Standardwerts dieser benutzt. Bei Angabe ohne Wert gilt die Option als gesetzt.
    '''</summary>
    Public Sub AddOption(ByVal info As OptionDefinitionInfo)

      Dim parameter = New CommandLineParameterInfo With {
      .Type = Enums.CommandLineParameterTypes.Option,
      .Name = info.Name,
      .LongName = info.LongName,
      .ValueType = info.ValueType,
      .ValueName = info.ValueName,
      .DefaultValue = info.DefaultValue,
      .HelpDescription = info.HelpDescription
      }
      Parameters.Add(parameter)
    End Sub

    Public Function ToParameterCollection() As CommandLineParameterInfoCollection
      Return Parameters
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace