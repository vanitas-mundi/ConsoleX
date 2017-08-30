Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.ConsoleX.CommandLineParameters
Imports SSP.ConsoleX.CommandLineParameters.Interfaces
#End Region

Namespace CommandLineParameters

  Public Class CommandLineSettingsBase

    Implements ICommandLineSettings

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    '''<summary>Liefert die CommandLineParameterInfo-Objekte als Dictionary.</summary>
    Public ReadOnly Property ParametersDictionary As New Dictionary(Of String, CommandLineParameterInfo) _
    Implements ICommandLineSettings.ParametersDictionary
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary>Liefert ein CommandLineParameterInfo-Objekt zum angegebenen propertyName.</summary>
    Public Function GetParameterInfo(ByVal propertyName As String) As CommandLineParameterInfo _
    Implements ICommandLineSettings.GetParameterInfo

      Return Me.ParametersDictionary.Item(propertyName)
    End Function

    '''<summary>Liefert true, wenn die Option name als Befelszeilenargument angegeben worden ist.</summary>
    Public Function ExistOption(ByVal name As String) As Boolean Implements ICommandLineSettings.ExistOption

      Dim info = Me.ParametersDictionary.Values.FirstOrDefault(Function(x) Base.Helper.String.TextCompare.IsEqual(x.Name, name))
      Dim result = (info IsNot Nothing) AndAlso (info.ExistOption)
      Return result
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace