Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.ConsoleX.ConsoleText.Interfaces
#End Region

Namespace ConsoleText

  Public Class TextAlignmentRightFormatter

    Implements ITextAlignmentFormatter

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
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Function FormatText(s As String, ByVal maxWidth As Int32) As String Implements ITextAlignmentFormatter.FormatText
      Return If(maxWidth = 0, s, s.PadLeft(maxWidth))
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace