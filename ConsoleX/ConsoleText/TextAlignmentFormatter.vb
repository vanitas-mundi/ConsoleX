Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.ConsoleX.ConsoleText.Enums
Imports SSP.ConsoleX.ConsoleText.Interfaces
#End Region

Namespace ConsoleText

  Public Class TextAlignmentFormatter

    Implements ITextAlignmentFormatter

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New(ByVal consoleTextAlignment As ConsoleTextAlignments)
      Me.ConsoleTextAlignment = consoleTextAlignment
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public Property ConsoleTextAlignment As ConsoleTextAlignments
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Function FormatText(s As String, ByVal maxWidth As Int32) As String Implements ITextAlignmentFormatter.FormatText

      Dim formatter As ITextAlignmentFormatter

      Select Case Me.ConsoleTextAlignment
        Case ConsoleTextAlignments.Left
          formatter = New TextAlignmentLeftFormatter
        Case ConsoleTextAlignments.Right
          formatter = New TextAlignmentRightFormatter
        Case ConsoleTextAlignments.Center
          formatter = New TextAlignmentCenterFormatter
        Case ConsoleTextAlignments.Block
          formatter = New TextAlignmentBlockFormatter
        Case Else
          formatter = New TextAlignmentLeftFormatter
      End Select

      Return formatter.FormatText(s, maxWidth)
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace