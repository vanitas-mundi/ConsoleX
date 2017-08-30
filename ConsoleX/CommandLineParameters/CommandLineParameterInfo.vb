Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.ConsoleX.CommandLineParameters.Enums
#End Region

Namespace CommandLineParameters

  Public Class CommandLineParameterInfo

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
    Private _value As String = String.Empty
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New()
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    '''<summary>Liefert den Typ des Parameters oder legt diesen fest.</summary>
    Public Property Type As CommandLineParameterTypes = CommandLineParameterTypes.Argument

    '''<summary>Liefert den Standardwert des Parameters oder legt diesen fest.</summary>
    Public Property DefaultValue As String = String.Empty

    '''<summary>Liefert die Hilfe-Beschreibung des Parameters oder legt diesen fest.</summary>
    Public Property HelpDescription As String = String.Empty

    '''<summary>Liefert den Namen des Parameters oder legt diesen fest.</summary>
    Public Property Name As String = String.Empty

    '''<summary>Liefert den optionalen Langnamen des Parameters oder legt diesen fest.</summary>
    Public Property LongName As String = String.Empty

    '''<summary>Liefert den Typ der Parameterwertes oder legt diesen fest.</summary>
    Public Property ValueType As CommandLineParameterValueTypes = CommandLineParameterValueTypes.NoValue

    '''<summary>Liefert den optionalen Namen des Parameterwertes oder legt diesen fest.</summary>
    Public Property ValueName As String = "Value"

    '''<summary>Liefert den Wert des Parameters oder legt diesen fest.</summary>
    Public Property Value As String
      Get
        Return If(_value Is String.Empty, Me.DefaultValue, _value)
      End Get
      Set(value As String)
        _value = value
      End Set
    End Property

    '''<summary>Liefert true, wenn die Option als Befehlszeilenargument angegeben wurde.</summary>
    Public Property ExistOption As Boolean = False
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary>Liefert true, wenn der Parameter optional ist.</summary>
    Public Function IsOptional() As Boolean

      Dim result = (Me.Type = CommandLineParameterTypes.OpionalArgument) _
      OrElse (Me.Type = CommandLineParameterTypes.OpionalArgument)

      Return result
    End Function

    '''<summary>Prüft, ob das Parsing zu einem validen Parameter führte.</summary>
    Public Function IsValid() As Boolean

      Dim result = False

      Select Case Me.Type
        Case CommandLineParameterTypes.Argument
          result = Not String.IsNullOrEmpty(Me.Value)
        Case CommandLineParameterTypes.OpionalArgument
          result = Not String.IsNullOrEmpty(Me.Value)
        Case CommandLineParameterTypes.Option
          Select Case True
            Case (Me.ExistOption) AndAlso (Me.ValueType = CommandLineParameterValueTypes.HasValue) AndAlso (String.IsNullOrEmpty(Me.Value))
              result = False
            Case (Me.ExistOption) AndAlso (Me.ValueType = CommandLineParameterValueTypes.NoValue) AndAlso (Not String.IsNullOrEmpty(Me.Value))
              result = False
            Case Else
              result = True
          End Select
      End Select

      Return result
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
