Option Explicit On
Option Strict On
Option Infer On

#Region " --------------->> Imports/ usings "
Imports SSP.ConsoleX.ConsoleControls.BarMenus
Imports SSP.ConsoleX.ConsoleDrawing
Imports SSP.ConsoleX.ConsoleControls.Enums
Imports SSP.ConsoleX.Core

#End Region

Namespace ConsoleControls

  Public Class ColorPicker

#Region " --------------->> Eigenschaften der Klasse "
    Private _x As Int32
    Private _y As Int32
    Private _border As Boolean = True
    Private _colorSet As ColorSet
    Private _visibleItems As Int32
    Private _selectedColor As ConsoleColor
    Private _colorNames As String() = New String() _
      {"Schwarz" _
      , "Dunkelblau" _
      , "Dunkelgrün" _
      , "Dunkelzyan" _
      , "Dunkelrot" _
      , "Dunkelmagenta" _
      , "Dunkelgelb" _
      , "Grau" _
      , "Dunkelgrau" _
      , "Blau" _
      , "Grün" _
      , "Zyan" _
      , "Rot" _
      , "Magenta" _
      , "Gelb" _
      , "Weiß"}
#End Region  '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New(ByVal x As Int32, ByVal y As Int32 _
    , ByVal colorSet As ColorSet, ByVal visibleItems As Int32)

      Initialize(x, y, colorSet, visibleItems)
    End Sub

    Public Sub New(ByVal x As Int32, ByVal y As Int32, ByVal colorSet As ColorSet)

      Initialize(x, y, colorSet, 16)
    End Sub

    Public Sub New(ByVal x As Int32, ByVal y As Int32, ByVal visibleItems As Int32)

      Initialize(x, y, DefaultColorSet.Instance, visibleItems)
    End Sub

    Public Sub New(ByVal x As Int32, ByVal y As Int32)
      Initialize(x, y, DefaultColorSet.Instance, 16)
    End Sub

    Private Sub Initialize(ByVal x As Int32, ByVal y As Int32 _
    , ByVal colorSet As ColorSet, ByVal visibleItems As Int32)

      _x = x
      _y = y
      _colorSet = colorSet
      _visibleItems = visibleItems
    End Sub
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public ReadOnly Property SelectedColor() As ConsoleColor
      Get
        Return _selectedColor
      End Get
    End Property

    Public Property Border() As Boolean
      Get
        Return _border
      End Get
      Set(ByVal value As Boolean)
        _border = value
      End Set
    End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Function SelectColor() As DialogResults

      Dim bmi = New BarMenuInfos(_colorNames, _x, _y, _colorSet, _visibleItems)

      If _border Then
        Dim borderSettings = New BorderSettings With {
        .Y = _y,
        .X = _y + _visibleItems + 1,
        .ForeColor = _colorSet.ForeColor,
        .BackColor = _colorSet.BackColor
        }

        Tools.DrawBorder(borderSettings)
      End If

      Dim bm = New BarMenu(Of String)(bmi)

      For i = 0 To 15
        Dim color = CType(System.Enum.Parse(GetType(ConsoleColor), i.ToString), ConsoleColor)
        Tools.WriteXY("■", _x, _y + i + 1, color, _colorSet.BackColor)
      Next i

      bm.Border = False
      Select Case bm.ShowMenu()
        Case DialogResults.OK
          Select Case bm.Value
            Case "Schwarz"
              _selectedColor = ConsoleColor.Black
            Case "Dunkelblau"
              _selectedColor = ConsoleColor.DarkBlue
            Case "Dunkelgrün"
              _selectedColor = ConsoleColor.DarkGreen
            Case "Dunkelzyan"
              _selectedColor = ConsoleColor.DarkCyan
            Case "Dunkelrot"
              _selectedColor = ConsoleColor.DarkRed
            Case "Dunkelmagenta"
              _selectedColor = ConsoleColor.DarkMagenta
            Case "Dunkelgelb"
              _selectedColor = ConsoleColor.DarkYellow
            Case "Grau"
              _selectedColor = ConsoleColor.Gray
            Case "Dunkelgrau"
              _selectedColor = ConsoleColor.DarkGray
            Case "Blau"
              _selectedColor = ConsoleColor.Blue
            Case "Grün"
              _selectedColor = ConsoleColor.Green
            Case "Zyan"
              _selectedColor = ConsoleColor.Cyan
            Case "Rot"
              _selectedColor = ConsoleColor.Red
            Case "Magenta"
              _selectedColor = ConsoleColor.Magenta
            Case "Gelb"
              _selectedColor = ConsoleColor.Yellow
            Case "Weiß"
              _selectedColor = ConsoleColor.White
          End Select
          Tools.ClearWindow(_x - 1, _y, 18, _y + _visibleItems + 1, _colorSet.BackColor)
          Return DialogResults.OK
        Case Else
          Tools.ClearWindow(_x - 1, _y, 18, _y + _visibleItems + 1, _colorSet.BackColor)
          Return DialogResults.Cancel
      End Select
    End Function
#End Region 'Öffentliche Methoden der Klasse}

  End Class

End Namespace
