Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace ConsoleText

  Public Class ConsoleTextColorSet

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New()
    End Sub

    Public Sub New(foreColor As ConsoleColor, backColor As ConsoleColor)
      Me.ForeColor = foreColor
      Me.BackColor = backColor
    End Sub

    Public Sub New(foreColor As ConsoleColor)
      Me.ForeColor = foreColor
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    '''<summary>Liefert oder legt fest die Schriftfarbe.</summary>  
    Public Property ForeColor() As ConsoleColor = Console.ForegroundColor

    '''<summary>Liefert oder legt fest die Hintergrundfarbe.</summary>   
    Public Property BackColor() As ConsoleColor = Console.BackgroundColor
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
