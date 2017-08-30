Option Explicit On
Option Strict On
Option Infer On

#Region " --------------->> Imports/ usings "
#End Region

Namespace ConsoleDrawing

  Public Class ColorSet

#Region " --------------->> Eigenschaften der Klasse "
#End Region  '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New()
      Initialize(Console.ForegroundColor _
      , Console.ForegroundColor _
      , Console.BackgroundColor _
      , Console.BackgroundColor _
      , Console.ForegroundColor)
    End Sub

    Public Sub New _
    (ByVal borderColor As ConsoleColor _
    , ByVal foreColor As ConsoleColor _
    , ByVal backColor As ConsoleColor _
    , ByVal selectionForeColor As ConsoleColor _
    , ByVal selectionBackColor As ConsoleColor)

      Initialize(borderColor, foreColor, backColor _
      , selectionForeColor, selectionBackColor)
    End Sub

    Private Sub Initialize _
    (ByVal borderColor As ConsoleColor _
    , ByVal foreColor As ConsoleColor _
    , ByVal backColor As ConsoleColor _
    , ByVal selectionForeColor As ConsoleColor _
    , ByVal selectionBackColor As ConsoleColor)

      _BorderColor = borderColor
      _ForeColor = foreColor
      _BackColor = backColor
      _SelectionForeColor = selectionForeColor
      _SelectionBackColor = selectionBackColor
    End Sub
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public Property BorderColor() As ConsoleColor

    Public Property ForeColor() As ConsoleColor

    Public Property BackColor() As ConsoleColor

    Public Property SelectionForeColor() As ConsoleColor

    Public Property SelectionBackColor() As ConsoleColor
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
