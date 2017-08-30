Option Explicit On
Option Strict On
Option Infer On

#Region " --------------->> Imports/ usings "
Imports SSP.ConsoleX.ConsoleControls.Enums
Imports System.Text
Imports SSP.ConsoleX.ConsoleDrawing
Imports SSP.ConsoleX.Core

#End Region

Namespace ConsoleControls

  Public Class ConsoleInputBox(Of T)

#Region " --------------->> Eigenschaften der Klasse "
    Private _title As String
    Private _prompt As String
    Private _x As Int32
    Private _y As Int32
    Private _x2 As Int32
    Private _colorSet As ColorSet
    Private _allowNull As Boolean = False
    Private _value As T
#End Region  '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New(ByVal title As String, ByVal prompt As String _
    , ByVal [default] As T, ByVal x As Int32, ByVal y As Int32 _
    , ByVal width As Int32)

      Initialize(title, prompt, [default], x, y, width, DefaultColorSet.Instance)
    End Sub

    Public Sub New(ByVal title As String, ByVal prompt As String _
    , ByVal [default] As T, ByVal x As Int32, ByVal y As Int32 _
    , ByVal width As Int32, ByVal colorSet As ColorSet)

      Initialize(title, prompt, [default], x, y, width, colorSet)
    End Sub

    Public Sub New(ByVal title As String, ByVal prompt As String _
    , ByVal x As Int32, ByVal y As Int32, ByVal width As Int32)

      Initialize(title, prompt, Nothing, x, y, width, DefaultColorSet.Instance)
    End Sub

    Public Sub New(ByVal title As String, ByVal prompt As String _
    , ByVal x As Int32, ByVal y As Int32, ByVal width As Int32 _
    , ByVal colorSet As ColorSet)

      Initialize(title, prompt, Nothing, x, y, width, colorSet)
    End Sub

    Private Sub Initialize(ByVal title As String, ByVal prompt As String _
    , ByVal [default] As T, ByVal x As Int32, ByVal y As Int32 _
    , ByVal width As Int32, ByVal colorSet As ColorSet)

      _title = title
      _prompt = prompt
      _x = x
      _y = y
      _x2 = width
      _value = [default]
      _colorSet = colorSet
    End Sub
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public ReadOnly Property Value() As T
      Get
        Return _value
      End Get
    End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
    Private Function GetInput() As DialogResults
      Dim key As ConsoleKeyInfo
      Dim sb = New StringBuilder()
      If _value IsNot Nothing Then sb.Append(_value.ToString)

      Do
        Tools.WriteRepeater("█"c, _x2 - (_x + 5), _x + 2, _y + 5, _colorSet.BackColor, _colorSet.ForeColor)

        Console.SetCursorPosition(_x + 2, _y + 5)
        Tools.WriteXY(sb.ToString, _x + 2, _y + 5, _colorSet)

        key = Console.ReadKey(True)

        Select Case True
          Case key.Key = ConsoleKey.Backspace
            If sb.Length > 0 Then sb.Remove(sb.Length - 1, 1)
          Case key.Key = 222 AndAlso key.Modifiers = ConsoleModifiers.Shift 'Ä
            sb.Append("Ä")
          Case key.Key = 222 AndAlso key.Modifiers = 0  'ä
            sb.Append("ä")
          Case key.Key = 192 AndAlso key.Modifiers = ConsoleModifiers.Shift 'Ö
            sb.Append("Ö")
          Case key.Key = 192 AndAlso key.Modifiers = 0  'ö
            sb.Append("ö")
          Case key.Key = 186 AndAlso key.Modifiers = ConsoleModifiers.Shift 'Ü
            sb.Append("Ü")
          Case key.Key = 186 AndAlso key.Modifiers = 0  'ü
            sb.Append("ü")
          Case key.Key = 219 AndAlso key.Modifiers = 0 'ß
            sb.Append("ß")
          Case (Char.IsLetterOrDigit(key.KeyChar)) _
        OrElse (Char.IsWhiteSpace(key.KeyChar)) _
        OrElse (Char.IsPunctuation(key.KeyChar))
            If (key.Key <> ConsoleKey.Enter) _
          AndAlso (sb.Length + 1 < _x2 - (_x + 2)) Then
              sb.Append(key.KeyChar)
            End If
        End Select

      Loop Until (key.Key = ConsoleKey.Escape) _
      OrElse ((key.Key = ConsoleKey.Enter) AndAlso (sb.Length > 0)) _
      OrElse ((key.Key = ConsoleKey.Enter) AndAlso ((sb.Length = 0) AndAlso (_allowNull)))

      Select Case key.Key
        Case ConsoleKey.Escape
          _value = Nothing
          Return DialogResults.Cancel
        Case Else
          Try
            _value = CType(CType(sb.ToString, Object), T)
            Return DialogResults.OK
          Catch ex As Exception
            Return ShowDialog()
          End Try
      End Select

    End Function
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Function ShowDialog() As DialogResults
      Dim visible = Console.CursorVisible
      Console.CursorVisible = True

      Dim settings = New HeaderBorderSettings With {
      .HeaderText = _title,
      .X = _x,
      .Y = _y,
      .X2 = _x2,
      .Y2 = _y + 8,
      .ColorSet = _colorSet
      }

      Tools.DrawHeaderBorder(settings)

      Tools.WriteXY(_prompt, _x + 2, _y + 3, _colorSet)
      Dim ret = GetInput()
      Tools.ClearWindow(_x, _y, _x2, _y + 8, _colorSet.BackColor)
      Console.CursorVisible = visible
      Return ret
    End Function
#End Region 'Öffentliche Methoden der Klasse}

  End Class

End Namespace
