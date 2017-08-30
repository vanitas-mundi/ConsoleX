Option Explicit On
Option Infer On
Option Strict On


#Region " --------------->> Imports/ usings "
Imports System.Text
#End Region

Namespace CommandLineParameters

  Public Class ConsoleHelpPageInfo

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    '''<summary>Liefert den zugrunde liegenden StrinBuilder des ConsoleHelpPageInfo-Objektes.</summary>
    Public ReadOnly Property Builder As New StringBuilder(vbCrLf)

    '''<summary>Liefert die zugrunde liegenden Argumente des ConsoleHelpPageInfo-Objektes.</summary>
    Public ReadOnly Property Arguments As New List(Of String)

    '''<summary>Liefert die zugrunde liegenden Optionen des ConsoleHelpPageInfo-Objektes.</summary>
    Public ReadOnly Property Options As New List(Of String)

    '''<summary>Liefert die zugrunde liegenden Beschreibungen des ConsoleHelpPageInfo-Objektes.</summary>
    Public ReadOnly Property Descriptions As New ConsoleHelpPageParameterDescriptionCollection
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Overrides Function ToString() As String
      Return Me.Builder.ToString
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace