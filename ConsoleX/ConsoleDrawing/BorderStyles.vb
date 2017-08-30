Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.ConsoleX.ConsoleDrawing.Enums
Imports SSP.ConsoleX.ConsoleText
#End Region

Namespace ConsoleDrawing

  Public Class BorderStyles

    '┌───┬───┐
    '│   │   │
    '├───┼───┤
    '│   │   │
    '└───┴───┘
    '╔════╦════╗
    '║    ║    ║
    '╠════╬════╣
    '║    ║    ║
    '╚════╩════╝
#Region " --------------->> Enumerationen der Klasse "
#End Region  '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New(ByVal borderType As BorderStyleTypes)
      Select Case borderType
        Case BorderStyleTypes.None
          Me.LeftTopCorner = ConsoleTextFunctions.Instance.SpaceChar
          Me.RightTopCorner = ConsoleTextFunctions.Instance.SpaceChar
          Me.LeftBottomCorner = ConsoleTextFunctions.Instance.SpaceChar
          Me.RightBottomCorner = ConsoleTextFunctions.Instance.SpaceChar
          Me.LeftCrossing = ConsoleTextFunctions.Instance.SpaceChar
          Me.TopCrossing = ConsoleTextFunctions.Instance.SpaceChar
          Me.MiddleCrossing = ConsoleTextFunctions.Instance.SpaceChar
          Me.RightCrossing = ConsoleTextFunctions.Instance.SpaceChar
          Me.BottomCrossing = ConsoleTextFunctions.Instance.SpaceChar
          Me.HorizontalLine = ConsoleTextFunctions.Instance.SpaceChar
          Me.VerticalLine = ConsoleTextFunctions.Instance.SpaceChar
        Case BorderStyleTypes.Single
          Me.LeftTopCorner = "┌"c
          Me.RightTopCorner = "┐"c
          Me.LeftBottomCorner = "└"c
          Me.RightBottomCorner = "┘"c
          Me.LeftCrossing = "├"c
          Me.TopCrossing = "┬"c
          Me.MiddleCrossing = "┼"c
          Me.RightCrossing = "┤"c
          Me.BottomCrossing = "┴"c
          Me.HorizontalLine = "─"c
          Me.VerticalLine = "│"c
        Case BorderStyleTypes.Double
          Me.LeftTopCorner = "╔"c
          Me.RightTopCorner = "╗"c
          Me.LeftBottomCorner = "╚"c
          Me.RightBottomCorner = "╝"c
          Me.LeftCrossing = "╠"c
          Me.TopCrossing = "╦"c
          Me.MiddleCrossing = "╬"c
          Me.RightCrossing = "╣"c
          Me.BottomCrossing = "╩"c
          Me.HorizontalLine = "═"c
          Me.VerticalLine = "║"c
      End Select
    End Sub
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public ReadOnly Property LeftTopCorner As Char

    Public ReadOnly Property RightTopCorner As Char

    Public ReadOnly Property LeftBottomCorner As Char

    Public ReadOnly Property RightBottomCorner As Char

    Public ReadOnly Property LeftCrossing As Char

    Public ReadOnly Property TopCrossing As Char

    Public ReadOnly Property MiddleCrossing As Char

    Public ReadOnly Property RightCrossing As Char

    Public ReadOnly Property BottomCrossing As Char

    Public ReadOnly Property HorizontalLine As Char

    Public ReadOnly Property VerticalLine As Char
#End Region  '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region  '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region  '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region  'Öffentliche Methoden der Klasse}

  End Class

End Namespace
