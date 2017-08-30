Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.ConsoleX.ConsoleDrawing.Enums
#End Region

Namespace ConsoleDrawing

  Public Class TableSettings

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
    Private _colorSet As New ColorSet
    Private _backColor As ConsoleColor = Console.BackgroundColor
    Private _foreColor As ConsoleColor = Console.ForegroundColor
    Private _borderStyleType As BorderStyleTypes = BorderStyleTypes.Single
    Private _borderStyle As BorderStyles = BorderStylesSingle.Instance
#End Region  '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public ReadOnly Property ColWidths As New List(Of Int32)

    Public ReadOnly Property RowHeights() As New List(Of Int32)

    Public ReadOnly Property TableWidth As Int32
      Get
        Return (Aggregate col In _ColWidths Into Sum(col)) + _ColWidths.Count + 1
      End Get
    End Property

    Public ReadOnly Property TableHeight As Int32
      Get
        Return (Aggregate row In _RowHeights Into Sum(row)) + _RowHeights.Count + 1
      End Get
    End Property

    Public Property X As Int32

    Public Property Y As Int32

    Public Property Values() As New List(Of String)

    Public Property ColPadding As Int32 = 1

    Public Property RowPadding As Int32 = 0

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
        With _colorSet
          _colorSet = New ColorSet(.BorderColor, .ForeColor, value, .SelectionForeColor, .SelectionBackColor)
        End With
      End Set
    End Property

    Public Property ForeColor As ConsoleColor
      Get
        Return _foreColor
      End Get
      Set(value As ConsoleColor)
        _foreColor = value
        With _colorSet
          _colorSet = New ColorSet(.BorderColor, value, .BackColor, .SelectionForeColor, .SelectionBackColor)
        End With
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

    Public ReadOnly Property BorderStyle As BorderStyles
      Get
        Return _borderStyle
      End Get
    End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region 'Öffentliche Methoden der Klasse}

  End Class

End Namespace
