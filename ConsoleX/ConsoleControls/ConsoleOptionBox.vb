Option Explicit On
Option Strict On
Option Infer On

#Region " --------------->> Imports/ usings "
Imports SSP.ConsoleX.ConsoleControls.Enums
Imports SSP.ConsoleX.ConsoleDrawing
Imports SSP.ConsoleX.Core
#End Region

Namespace ConsoleControls

  Public Class ConsoleOptionBox

#Region " --------------->> Eigenschaften der Klasse "
    Private _title As String
    Private _optionStrings As String()
    Private _x As Int32
    Private _y As Int32
    Private _x2 As Int32
    Private _colorSet As ColorSet
#End Region  '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New(ByVal title As String, ByVal optionStrings() As String _
    , ByVal x As Int32, ByVal y As Int32, ByVal width As Int32)

      Initialize(title, optionStrings, x, y, width, DefaultColorSet.Instance)
    End Sub

    Public Sub New(ByVal title As String, ByVal optionStrings() As String _
    , ByVal x As Int32, ByVal y As Int32, ByVal width As Int32, ByVal colorSet As ColorSet)

      Initialize(title, optionStrings, x, y, width, colorSet)
    End Sub

    Private Sub Initialize(ByVal title As String, ByVal optionStrings() As String _
    , ByVal x As Int32, ByVal y As Int32 _
    , ByVal width As Int32, ByVal colorSet As ColorSet)

      _title = title
      _optionStrings = optionStrings
      _x = x
      _y = y
      _x2 = width
      _colorSet = colorSet
    End Sub
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region  '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region  '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Function ShowOptions() As OptionBoxResults

      Dim visible = Console.CursorVisible
      Console.CursorVisible = False

      Dim windowHeight = 7 + _optionStrings.Count

      Try
        Dim settings = New HeaderBorderSettings With {
          .HeaderText = _title,
          .X = _x,
          .Y = _y,
          .X2 = _x2,
          .Y2 = _y + windowHeight,
          .ColorSet = _colorSet
        }

        Tools.DrawHeaderBorder(settings)

        For i = 0 To _optionStrings.Count - 1
          Tools.WriteXY($"<{i + 1}> {_optionStrings(i)}", _x + 2, _y + 4 + i, _colorSet)
        Next i

        Dim x = _x + 2
        Dim y = _y + 7 + _optionStrings.Count - 1

        Tools.WriteXY($"Bitte wählen (1 - {_optionStrings.Count}):", x, y, _colorSet)

        Dim key As ConsoleKey
        Dim ok = False

        Do
          key = Console.ReadKey(True).Key
          Select Case key
            Case ConsoleKey.D1 To ConsoleKey.D9
              Dim optionResult = CType(key, Int32) - 48
              Select Case optionResult
                Case 1 To _optionStrings.Count
                  ok = True
                  Return CType(System.Enum.Parse(GetType(OptionBoxResults), $"Option{optionResult}"), OptionBoxResults)
              End Select
            Case ConsoleKey.Escape
              ok = True
              Return OptionBoxResults.Cancel
          End Select
        Loop Until ok

      Catch ex As Exception
      Finally
        Tools.ClearWindow(_x, _y, _x2, _y + windowHeight, _colorSet.BackColor)
        Console.CursorVisible = visible
      End Try

      Return OptionBoxResults.Cancel
    End Function
#End Region 'Öffentliche Methoden der Klasse}

  End Class

End Namespace
