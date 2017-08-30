Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Text
Imports SSP.ConsoleX.CommandLineParameters.Attributes
Imports SSP.ConsoleX.CommandLineParameters.Enums
Imports SSP.ConsoleX.CommandLineParameters.Exceptions
Imports SSP.ConsoleX.CommandLineParameters.Interfaces
#End Region

Namespace CommandLineParameters

  Public Class ParameterHelper

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New()
      Me.Parameters = New CommandLineParameterInfoCollection
      Me.HelpPage = New ConsoleHelpPage(Me.Parameters)

      If Not Me.HasHelpPage Then Return

      Dim info = New OptionDefinitionInfo With {
      .Name = "?",
      .LongName = "help",
      .ValueType = CommandLineParameterValueTypes.NoValue,
      .HelpDescription = My.Settings.HelpOptionDescription
      }

      Me.Definition.AddOption(info)
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    '''<summary>Definiert die erwarteten Parameter.</summary>
    ''' <returns></returns>
    Public ReadOnly Property Definition As New CommandLineParametersDefinition

    '''<summary>Liefert einen boolschen Wert, ob eine Hilfe existiert oder legt diesen fest.</summary>
    Public Property HasHelpPage As Boolean = True

    '''<summary>Liefert die zugrunde liegende Hilfe.</summary>
    Public ReadOnly Property HelpPage As ConsoleHelpPage

    Private ReadOnly Property Parameters As CommandLineParameterInfoCollection

    Private ReadOnly OptionInitialChars As String() = New String() {"--", "-", "/"}

    Private ReadOnly NameValueDelimiters As String() = New String() {":", "="}

    Private ReadOnly Property ArgumentType As CommandLineParameterTypes _
    = CommandLineParameterTypes.Argument Or CommandLineParameterTypes.OpionalArgument

    Private ReadOnly Property OptionType As CommandLineParameterTypes = CommandLineParameterTypes.Option

#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
    Private Function IsArgument(ByVal commandLineParameter As String) As Boolean
      Return Not IsOption(commandLineParameter)
    End Function

    Private Function IsOption(ByVal commandLineParameter As String) As Boolean
      Return OptionInitialChars.Any(Function(x) commandLineParameter.StartsWith(x))
    End Function

    Private Function GetParameterNameBase(ByVal parameter As String) As String

      Dim name = parameter.Split(NameValueDelimiters, StringSplitOptions.None).FirstOrDefault
      Dim temp = New StringBuilder(name)
      OptionInitialChars.ToList.ForEach(Sub(x) temp.Replace(x, String.Empty))

      Dim result = If(temp.ToString = parameter, String.Empty, temp.ToString)
      Return result
    End Function

    Private Function ExistParameterName(ByVal parameter As String) As Boolean

      Dim result = GetParameterNameBase(parameter)
      Return Me.Parameters.GetByName(result).Any
    End Function

    Private Function GetParameterName(ByVal parameter As String) As String

      Dim result = GetParameterNameBase(parameter)

      If Not Me.Parameters.GetByName(result).Any Then RaiseErrorOrShowExceptionName(New ArgumentOrOptionNameNotExistException)

      Return result
    End Function

    Private Function GetParameterValueReplaceString(ByVal parameter As String) As String

      Dim name = GetParameterName(parameter)
      Dim initialChars = New List(Of String)(OptionInitialChars) From {String.Empty}

      For Each initialChar In initialChars
        For Each nameDelimiter In NameValueDelimiters
          Dim result = $"{initialChar}{name}{nameDelimiter}"
          If Base.Helper.String.TextCompare.StartsWith(parameter, result) Then
            Return result
          End If

          result = $"{initialChar}{name}"
          If Base.Helper.String.TextCompare.IsEqual(parameter, result) Then
            Return result
          End If
        Next nameDelimiter
      Next initialChar

      Return String.Empty
    End Function

    Private Function GetParameterValue(ByVal parameter As String) As String

      Dim result = parameter.Substring(GetParameterValueReplaceString(parameter).Length)
      Return result
    End Function

    Private Function GetArgument(ByVal argumentIndex As Int32) As CommandLineParameterInfo

      If argumentIndex > Me.ArgumentCount Then RaiseErrorOrShowExceptionName(New ArgumentIndexOutOfRangeException)

      Dim result = Me.Parameters.GetByType(Me.ArgumentType).Skip(argumentIndex - 1).FirstOrDefault
      Return result
    End Function

    Private Function GetArgument(ByVal name As String) As CommandLineParameterInfo

      Try
        Dim result = Me.Parameters.GetByTypeAndName(Me.ArgumentType, name).FirstOrDefault
        Return result
      Catch ex As Exception
        RaiseErrorOrShowExceptionName(New ArgumentOrOptionNameNotExistException)
        Return Nothing
      End Try
    End Function

    Private Function GetOption(ByVal name As String) As CommandLineParameterInfo
      Try
        Dim result = Me.Parameters.GetByTypeAndName(Me.OptionType, name).FirstOrDefault
        Return result
      Catch ex As Exception
        RaiseErrorOrShowExceptionName(New ArgumentOrOptionNameNotExistException)
        Return Nothing
      End Try
    End Function

    Private Sub RaiseErrorOrShowExceptionName(ByVal exception As Exception)

      If Debugger.IsAttached Then Throw New Exception

      Console.WriteLine(exception.Message)
      Environment.Exit(0)
    End Sub

    Private Sub CheckShowHelpPage()

      If Not Me.ExistsOption("?") Then Return

      If Not Me.HasHelpPage Then RaiseErrorOrShowExceptionName(New ApplicationHasNoHelpPageException)

      Me.HelpPage.Show()
      If Debugger.IsAttached Then Helper.ConsoleHelper.Functions.WaitUntilKeyPressed()
      Environment.Exit(0)
    End Sub

    Private Sub CheckArgumentCount(ByVal argumentCounter As Int32)

      If Me.RequiredArgumentCount = argumentCounter Then Return

      RaiseErrorOrShowExceptionName(New WrongNumberOfArgumentsException)
    End Sub

    Private Sub CheckParsingError()

      If Not Me.Parameters.Any(Function(x) Not x.IsValid) Then Return

      RaiseErrorOrShowExceptionName(New ParameterParsingErrorException)
    End Sub
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary>Analysiert die Befehlszeilenparameter.</summary>
    Public Sub Parse()
      Parse(Environment.GetCommandLineArgs.Skip(1).ToArray)
    End Sub

    '''<summary>Analysiert die Befehlszeilenparameter (commandLineParameters).</summary>
    Public Sub Parse(ByVal commandLineParameters As String())

      Me.Parameters.Clear()
      Me.Parameters.AddRange(Me.Definition.ToParameterCollection)

      Dim argumentIndex = 0
      Dim argumentCounter = 0

      For Each parameter In commandLineParameters

        Dim info As CommandLineParameterInfo

        If IsOption(parameter) Then
          Dim name = GetParameterName(parameter)
          info = GetOption(name)
          info.ExistOption = True
        Else

          If ExistParameterName(parameter) Then
            Dim name = GetParameterName(parameter)
            info = GetArgument(name)
          Else
            argumentIndex += 1
            info = GetArgument(argumentIndex)
          End If

          If info.Type = CommandLineParameterTypes.Argument Then argumentCounter += 1
        End If

        Dim value = GetParameterValue(parameter)
        info.Value = value
      Next parameter

      CheckShowHelpPage()
      CheckArgumentCount(argumentCounter)
      CheckParsingError()
    End Sub

    '''<summary>Analysiert die Befehlszeilenparameter und liefert deren Werte als Objekt vom Type T.</summary>
    Public Function ParseToObject(Of T As {ICommandLineSettings, New})() As T
      Return ParseToObject(Of T)(Environment.GetCommandLineArgs.Skip(1).ToArray)
    End Function

    '''<summary>Analysiert die Befehlszeilenparameter (commandLineParameters) und liefert deren Werte als Objekt vom Type T.</summary>
    Public Function ParseToObject(Of T As {ICommandLineSettings, New})(ByVal commandLineParameters As String()) As T

      Parse(commandLineParameters)

      Dim result = New T


      With Base.Helper.Reflection.Property

        For Each propertyName In .Names(result)

          Dim refersToAttribute = .GetAttributeOrNothing(Of RefersToCommandLineParameterAttribute)(result, propertyName)

          If refersToAttribute IsNot Nothing Then

            Dim info As CommandLineParameterInfo

            Select Case True
              Case (Me.ArgumentType.HasFlag(refersToAttribute.Type)) _
              AndAlso (Not String.IsNullOrEmpty(refersToAttribute.Name))
                info = GetArgument(refersToAttribute.Name)
              Case Me.ArgumentType.HasFlag(refersToAttribute.Type)
                info = GetArgument(refersToAttribute.ArgumentIndex)
              Case Else
                info = GetOption(refersToAttribute.Name)
            End Select

            result.ParametersDictionary.Add(propertyName, info)

            If info IsNot Nothing Then .Set(result, propertyName, info.Value)
          End If
        Next propertyName
      End With

      Return result
    End Function

    '''<summary>Liefert den Wert des Arguments argumentIndex.</summary>
    Public Function GetArgumentValue(ByVal argumentIndex As Int32) As String
      Dim result = GetArgument(argumentIndex).Value
      Return result
    End Function

    '''<summary>Liefert den Wert des Arguments name.</summary>
    Public Function GetArgumentValue(ByVal name As String) As String
      Dim result = GetArgument(name).Value
      Return result
    End Function

    '''<summary>Liefert den Wert der Option name.</summary>
    Public Function GetOptionValue(ByVal name As String) As String
      Dim result = GetOption(name).Value
      Return result
    End Function

    '''<summary>Prüft, ob die Option name in den Befehlszeilenparametern angegeben wurde.</summary>
    Public Function ExistsOption(ByVal name As String) As Boolean

      Dim result = Me.Parameters.GetByTypeAndName(Me.OptionType, name).Any(Function(x) x.ExistOption)
      Return result
    End Function

    '''<summary>Liefert die Anzahl der erforderlichen (nicht optionalen) Argumente.</summary>
    Public Function RequiredArgumentCount() As Int32
      Dim result = Me.Parameters.GetByType(CommandLineParameterTypes.Argument).Count
      Return result
    End Function

    '''<summary>Liefert die Anzahl der erforderlichen und nicht erforderlichen Argumente.</summary>
    Public Function ArgumentCount() As Int32
      Dim result = Me.Parameters.GetByType(Me.ArgumentType).Count
      Return result
    End Function

    '''<summary>Liefert die Anzahl der möglichen Optionen.</summary>
    Public Function OptionCount() As Int32
      Dim result = Me.Parameters.GetByType(CommandLineParameterTypes.Option).Count
      Return result
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace