Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.ConsoleX.ConsoleDrawing.Enums
#End Region

Namespace ConsoleDrawing

  Public Class BorderSettings

#Region " --------------->> Enumerationen der Klasse "
#End Region  '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
    Private _x As Int32 = 0
    Private _y As Int32 = 0
    Private _x2 As Int32 = 0
    Private _y2 As Int32 = 0
    Private _bounds As New DialogBounds(0, 0, 0, 0)
    Private _colorSet As New ColorSet
    Private _backColor As ConsoleColor = Console.BackgroundColor
    Private _foreColor As ConsoleColor = Console.ForegroundColor
    Private _borderStyleType As BorderStyleTypes = BorderStyleTypes.Single
#End Region  '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public Property Bounds As DialogBounds
      Get
        Return _bounds
      End Get
      Set(value As DialogBounds)
        _bounds = value
        _x = value.X
        _y = value.Y
        _x2 = value.X2
        _y2 = value.Y2
      End Set
    End Property

    Public Property X As Int32
      Get
        Return _x
      End Get
      Set(value As Int32)
        _x = value
        _bounds = New DialogBounds(value, Me.Y, Me.X2, Me.Y2)
      End Set
    End Property

    Public Property Y As Int32
      Get
        Return _y
      End Get
      Set(value As Int32)
        _y = value
        _bounds = New DialogBounds(Me.X, value, Me.X2, Me.Y2)
      End Set
    End Property

    Public Property X2 As Int32
      Get
        Return _x2
      End Get
      Set(value As Int32)
        _x2 = value
        _bounds = New DialogBounds(Me.X, Me.Y, value, Me.Y2)
      End Set
    End Property

    Public Property Y2 As Int32
      Get
        Return _y2
      End Get
      Set(value As Int32)
        _y2 = value
        _bounds = New DialogBounds(Me.X, Me.Y, Me.X2, value)
      End Set
    End Property

    Public Property ColorSet As ColorSet
      Get
        Return _colorSet
      End Get
      Set(value As ColorSet)
        _colorSet = value
        _backColor = value.BackColor
        _foreColor = value.ForeColor
      End Set
    End Property

    Public Property BackColor As ConsoleColor
      Get
        Return _backColor
      End Get
      Set(value As ConsoleColor)
        _backColor = value
        _colorSet = New ColorSet(_colorSet.BorderColor, _colorSet.ForeColor, value _
      , _colorSet.SelectionForeColor, _colorSet.SelectionBackColor)
      End Set
    End Property

    Public Property ForeColor As ConsoleColor
      Get
        Return _foreColor
      End Get
      Set(value As ConsoleColor)
        _foreColor = value
        _colorSet = New ColorSet(_colorSet.BorderColor, value, _colorSet.BackColor _
      , _colorSet.SelectionForeColor, _colorSet.SelectionBackColor)
      End Set
    End Property

    Public Property BorderStyleType As BorderStyleTypes
      Get
        Return _borderStyleType
      End Get
      Set(value As BorderStyleTypes)
        _borderStyleType = value
        Select Case value
          Case BorderStyleTypes.None
            _borderStyle = BorderStylesNone.Instance
          Case BorderStyleTypes.Single
            _borderStyle = BorderStylesSingle.Instance
          Case BorderStyleTypes.Double
            _borderStyle = BorderStylesDouble.Instance
        End Select
      End Set
    End Property

    Public ReadOnly Property BorderStyle As BorderStyles = BorderStylesSingle.Instance
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region 'Öffentliche Methoden der Klasse}

  End Class

End Namespace
