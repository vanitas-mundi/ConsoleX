Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Text
Imports SSP.ConsoleX.CommandLineParameters.Enums
#End Region

Namespace CommandLineParameters

  Public Class ConsoleHelpPage

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
    '''<summary>Liefert die Beschreibung der Applikation für die Hilfe</summary>
    Public Property ApplicationDescription As String

    '''<summary>Liefert eine Auflistung mit Hinweisen für die Hilfe.</summary>
    Public Property ApplicationHints As New List(Of String)

    '''<summary>Liefert eine Auflistung mit Aufruf-Beispielen für die Hilfe.</summary>
    Public Property Samples As New List(Of String)

    '''<summary>Liefert den Standardtext für die Applikationsbeschreibungsüberschrift oder legt diesen fest.</summary>
    Public Property HelpPageApplicationDescriptionHeader As String = My.Settings.HelpPageApplicationDescriptionHeader

    '''<summary>Liefert den Standardtext für die Hinweisüberschrift oder legt diesen fest.</summary>
    Public Property HelpPageHintsHeader As String = My.Settings.HelpPageHintsHeader

    '''<summary>Liefert den Standardtext für die Beispielüberschrift oder legt diesen fest.</summary>
    Public Property HelpPageSamplesHeader As String = My.Settings.HelpPageSamplesHeader

    '''<summary>Liefert den Standardtext für die Hilfeoptionbeschreibung oder legt diesen fest.</summary>
    Public Property HelpOptionDescription As String = My.Settings.HelpOptionDescription
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New(ByVal parameters As CommandLineParameterInfoCollection)
      Me.Parameters = parameters
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    '''<summary>Liefert die Parameter als CommandLineParameterInfoCollection.</summary>
    Private ReadOnly Parameters As CommandLineParameterInfoCollection
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
    Private Function GetLines(ByVal value As String, ByVal indent As Int32) As String()

      Dim textInfo = New ConsoleText.ConsoleTextInfo With {
        .MaxWidth = Console.WindowWidth - indent,
        .Value = value,
        .AppendNewLine = False
        }

      Dim result = ConsoleText.ConsoleTextFunctions.Instance.GetFormattedTextLines(textInfo)
      Return result
    End Function

    Private Sub AddApplicationDescription(ByVal info As ConsoleHelpPageInfo)

      If String.IsNullOrEmpty(Me.ApplicationDescription) Then Return

      With info.Builder
        .AppendLine(Me.HelpPageApplicationDescriptionHeader)
        .AppendLine(New String("="c, Me.HelpPageApplicationDescriptionHeader.Length))
        .AppendLine()

        Dim lines = GetLines(Me.ApplicationDescription, 0)
        lines.ToList.ForEach(Sub(x) .Append(x))
        .AppendLine()
      End With
    End Sub

    Private Function GetOptionDescriptionNameBase(ByVal parameter As CommandLineParameterInfo) As String

      Dim name = If(String.IsNullOrEmpty(parameter.Name), String.Empty, $"/{parameter.Name}") & "{0}"
      Dim longName = If(String.IsNullOrEmpty(parameter.LongName), String.Empty, $"/{parameter.LongName}") & "{0}"

      Dim result = New StringBuilder(longName)

      If Not String.IsNullOrEmpty(name) Then result.Append(If(result.Length = 0, name, $", {name}"))

      Return result.ToString
    End Function

    Private Function GetOptionDescriptionName(ByVal parameter As CommandLineParameterInfo) As String

      Dim temp = GetOptionDescriptionNameBase(parameter)
      Dim result = String.Format(temp, String.Empty)
      Return result
    End Function

    Private Function GetOptionName(ByVal parameter As CommandLineParameterInfo) As String

      Dim result = GetOptionDescriptionNameBase(parameter).Replace(", ", "] [")

      Dim s = String.Empty

      Select Case parameter.ValueType
        Case CommandLineParameterValueTypes.HasValue
          s = $":{parameter.ValueName}"
        Case CommandLineParameterValueTypes.HasOptionalValue
          s = $"[[:]{parameter.ValueName}]"
        Case Else
          s = String.Empty
      End Select

      result = String.Format(result, s)

      Return result
    End Function

    Private Function GetArgumentDescriptionName(ByVal parameter As CommandLineParameterInfo) As String

      Dim result = If(String.IsNullOrEmpty(parameter.Name), parameter.ValueName, parameter.Name)
      Return result
    End Function


    Private Function GetArgumentName(ByVal parameter As CommandLineParameterInfo) As String

      Dim result = If(String.IsNullOrEmpty(parameter.Name), parameter.ValueName, $"{parameter.Name}:{parameter.ValueName}")
      Return result
    End Function

    Private Sub AddOptionAndDescription(ByVal info As ConsoleHelpPageInfo, ByVal parameter As CommandLineParameterInfo)

      info.Options.Add($"[{GetOptionName(parameter)}]")

      Dim descriptionItem = New ConsoleHelpPageParameterDescription With {
      .Name = GetOptionDescriptionName(parameter),
      .Description = parameter.HelpDescription,
      .Type = CommandLineParameterTypes.Option
      }

      info.Descriptions.Add(descriptionItem)
    End Sub

    Private Sub AddArgumentAndDescription(ByVal info As ConsoleHelpPageInfo, ByVal parameter As CommandLineParameterInfo)

      Dim argumentName = GetArgumentName(parameter)
      info.Arguments.Add(If(parameter.Type = Enums.CommandLineParameterTypes.Argument, argumentName, $"[{argumentName}]"))

      Dim descriptionItem = New ConsoleHelpPageParameterDescription With {
      .Name = GetArgumentDescriptionName(parameter),
      .Description = parameter.HelpDescription,
      .Type = CommandLineParameterTypes.Argument
      }

      info.Descriptions.Add(descriptionItem)
    End Sub

    Private Sub AddParameterAndDescription(ByVal info As ConsoleHelpPageInfo, ByVal parameter As CommandLineParameterInfo)

      If parameter.Type = Enums.CommandLineParameterTypes.Option Then
        AddOptionAndDescription(info, parameter)
      Else
        AddArgumentAndDescription(info, parameter)
      End If
    End Sub

    Private Sub CreateArgumentsAndOptionsCollections(ByVal info As ConsoleHelpPageInfo)

      Me.Parameters.ForEach(Sub(x) AddParameterAndDescription(info, x))
    End Sub

    Private Sub AddCommandCall(ByVal info As ConsoleHelpPageInfo)

      With info.Builder
        Dim commandName = $"{My.Application.Info.AssemblyName.ToUpper} "
        Dim commandArguments = $"{String.Join(" ", info.Arguments)} {String.Join(" ", info.Options)}"
        Dim argumentLines = GetLines(commandArguments, commandName.Length)

        ' Erste Zeile einfügen.
        .Append($"{commandName}{argumentLines.First}")

        ' Falls vorhanden jede weitere Zeile einfügen.
        argumentLines.Skip(1).ToList.ForEach(Sub(x) .Append(x.PadLeft(Console.WindowWidth)))

        .AppendLine()
      End With
    End Sub

    Private Sub AddDescriptions(ByVal info As ConsoleHelpPageInfo)

      With info.Builder
        .AppendLine(info.Descriptions.ToString)
      End With
    End Sub

    Private Sub AddApplicationHints(ByVal info As ConsoleHelpPageInfo)

      If Not Me.ApplicationHints.Any Then Return

      With info.Builder
        .AppendLine(Me.HelpPageHintsHeader)
        .AppendLine(New String("="c, Me.HelpPageHintsHeader.Length))
        .AppendLine()

        For Each hint In Me.ApplicationHints
          Dim lines = GetLines(hint, 0)
          lines.ToList.ForEach(Sub(x) .Append(x))
        Next hint

        .AppendLine()
      End With
    End Sub

    Private Sub AddApplicationSamples(ByVal info As ConsoleHelpPageInfo)

      If Not Me.Samples.Any Then Return

      With info.Builder
        .AppendLine(Me.HelpPageSamplesHeader)
        .AppendLine(New String("="c, Me.HelpPageSamplesHeader.Length))
        .AppendLine()

        For Each sample In Me.Samples
          Dim lines = GetLines(String.Format(sample, My.Application.Info.AssemblyName.ToUpper), 0)
          lines.ToList.ForEach(Sub(x) .Append(x))
          .AppendLine()
        Next sample
      End With
    End Sub

    Private Function BuildHelpPage() As String

      Dim info = New ConsoleHelpPageInfo

      AddApplicationDescription(info)
      CreateArgumentsAndOptionsCollections(info)
      AddCommandCall(info)
      AddDescriptions(info)
      AddApplicationHints(info)
      AddApplicationSamples(info)

      Dim result = info.ToString
      Return result
    End Function
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary>Zeigt die Hilfe an.</summary>
    Public Sub Show()

      Console.WriteLine(BuildHelpPage)
    End Sub

    '''<summary>Liefert die Hilfe als String</summary>
    Public Overrides Function ToString() As String
      Return BuildHelpPage()
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace