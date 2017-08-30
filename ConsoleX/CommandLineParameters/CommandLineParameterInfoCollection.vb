Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.ConsoleX.CommandLineParameters.Enums
#End Region

Namespace CommandLineParameters

  Public Class CommandLineParameterInfoCollection

    Inherits List(Of CommandLineParameterInfo)

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
    Private Function IsEqual(ByVal firstString As String, ByVal secondString As String) As Boolean
      Return Base.Helper.String.TextCompare.IsEqual(firstString, secondString)
    End Function
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary>Liefert die Parameter als CommandLineParameterInfoCollection, welche mit dem angegebenen type und name übereinstimmen.</summary>
    Public Function GetByTypeAndName(ByVal type As CommandLineParameterTypes, ByVal name As String) As CommandLineParameterInfoCollection

      Dim result = Me.GetByType(type).GetByName(name)
      Return result
    End Function

    '''<summary>Liefert die Parameter als CommandLineParameterInfoCollection, welche mit dem angegebenen Namen übereinstimmen.</summary>
    Public Function GetByName(ByVal name As String) As CommandLineParameterInfoCollection

      Dim temp = Me.Where(Function(x) IsEqual(x.Name, name) OrElse IsEqual(x.LongName, name))
      Dim result = New CommandLineParameterInfoCollection
      result.AddRange(temp)

      Return result
    End Function

    '''<summary>Liefert die Parameter als CommandLineParameterInfoCollection, welche mit dem angegebenen Typ übereinstimmen.</summary>
    Public Function GetByType(ByVal type As CommandLineParameterTypes) As CommandLineParameterInfoCollection

      Dim result = New CommandLineParameterInfoCollection
      result.AddRange(Me.Where(Function(x) type.HasFlag(x.Type)))

      Return result
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
