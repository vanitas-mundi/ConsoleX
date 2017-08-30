Option Explicit On
Option Strict On
Option Infer On

#Region " --------------->> Imports/ usings "
#End Region

Namespace ConsoleDrawing

  Public Class DialogBounds

#Region " --------------->> Eigenschaften der Klasse "
#End Region  '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New(ByVal x As Int32, ByVal y As Int32, ByVal x2 As Int32, ByVal y2 As Int32)
      Me.X = x
      Me.Y = y
      Me.X2 = x2
      Me.Y2 = y2
    End Sub
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public ReadOnly Property X() As Int32

    Public ReadOnly Property Y() As Int32

    Public ReadOnly Property X2() As Int32

    Public ReadOnly Property Y2() As Int32

    Public ReadOnly Property Height() As Int32
      Get
        Return Me.Y2 - Me.Y + 1
      End Get
    End Property

    Public ReadOnly Property Width() As Int32
      Get
        Return Me.X2 - Me.X + 1
      End Get
    End Property

    Public ReadOnly Property HorizontalEnd() As Int32
      Get
        Return Me.Width + Me.X - 1
      End Get
    End Property

    Public ReadOnly Property VerticalEnd() As Int32
      Get
        Return Me.Height + Me.Y - 1
      End Get
    End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
