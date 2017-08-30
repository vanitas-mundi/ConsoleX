Option Explicit On
Option Infer On
Option Strict On


#Region " --------------->> Imports/ usings "
Imports SSP.ConsoleX.ConsoleText
#End Region

Namespace Helper

  Public Class ConsoleTextHelper

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Friend Sub New()
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public Property ErrorForeColor As ConsoleColor = ConsoleColor.Red

    Public Property ErrorBackColor As ConsoleColor?
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "

    Private Sub WriteLineToConsole(ByVal info As ConsoleTextInfo, ByVal line As String)

      Dim y = Math.Min(Console.WindowHeight - 1, info.Y)

      If info.Y > Console.WindowHeight - 1 Then
        Console.MoveBufferArea(0, 1, Console.WindowWidth, Console.WindowHeight - 1, 0, 0)
      End If

      Console.SetCursorPosition(info.X, y)

      Console.Write(line)
      info.Y += 1
    End Sub


    Private Sub WriteLinesToConsole(ByVal info As ConsoleTextInfo)

      Dim result = ConsoleTextFunctions.Instance.GetFormattedTextLines(info).ToList
      result.ForEach(Sub(x) WriteLineToConsole(info, x))
    End Sub
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Sub Write(ByVal value As String)
      Write(New ConsoleTextInfo With {.Value = value})
    End Sub

    Public Sub Write(ByVal value As String, ByVal x As Int32, ByVal y As Int32)
      Write(New ConsoleTextInfo With {.Value = value, .X = x, .Y = y})
    End Sub

    Public Sub Write(ByVal info As ConsoleTextInfo)

      If String.IsNullOrEmpty(info.Value) Then Return
      ConsoleTextFunctions.Instance.StoreColors(info)
      WriteLinesToConsole(info)
      ConsoleTextFunctions.Instance.RestoreColors()
    End Sub

    Public Sub WriteError(ByVal value As String)
      WriteError(New ConsoleTextInfo With {.Value = value})
    End Sub

    Public Sub WriteError(ByVal info As ConsoleTextInfo)
      info.ForeColor = Me.ErrorForeColor
      If Me.ErrorBackColor.HasValue Then info.BackColor = Me.ErrorBackColor.Value

      Write(info)
    End Sub
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace