Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.ConsoleX.ConsoleText.Enums
#End Region

Namespace ConsoleText

  Public Class ConsoleTextInfo

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    '''<summary>Liefert oder setzt den auszugebenen Text.</summary>
    Public Property Value As String = String.Empty

    '''<summary>Liefert oder legt fest die maximalen Zeichen pro Zeile. 0 bedeutet kein Limit.</summary>   
    Public Property MaxWidth As Int32 = 0

    '''<summary>Liefert oder legt die Textausrichtung fest.</summary>   
    Public Property TextAlignment As ConsoleTextAlignments = ConsoleTextAlignments.Left

    '''<summary>
    '''Liefert oder legt fest, ob Text umgebrochen werden darf, wenn MaxWidth erreicht wird.
    '''Ansonsten wird der Text verkürzt dargestellt.
    '''</summary>   
    Public Property AllowTextWrap As Boolean = True

    '''<summary>Liefert oder legt fest die X-Koordinaten, an welcher der Text ausgegeben wird.</summary>   
    Public Property X As Int32 = Console.CursorLeft

    '''<summary>Liefert oder legt fest die Y-Koordinaten, an welcher der Text ausgegeben wird.</summary>   
    Public Property Y As Int32 = Console.CursorTop

    '''<summary>Liefert oder legt fest die Hintergrundfarbe.</summary>   
    Public Property TextColorSet As New ConsoleTextColorSet

    '''<summary>Liefert oder legt fest die Schriftfarbe.</summary>   
    Public Property ForeColor As ConsoleColor
      Get
        Return Me.TextColorSet.ForeColor
      End Get
      Set(value As ConsoleColor)
        Me.TextColorSet.ForeColor = value
      End Set
    End Property

    '''<summary>Liefert oder legt fest die Hintergrundfarbe.</summary>   
    Public Property BackColor As ConsoleColor
      Get
        Return Me.TextColorSet.BackColor
      End Get
      Set(value As ConsoleColor)
        Me.TextColorSet.BackColor = value
      End Set
    End Property

    '''<summary>Liefert oder legt fest, ob nach der Textausgabe in die nächste Zeile gesprungen wird.</summary>   
    Public Property AppendNewLine As Boolean = False

    '''<summary>Liefert oder legt fest, ob nach der Textausgabe WhiteSpace eingefügt wird.</summary>   
    Public Property AppendWhiteSpace As Boolean = False

    '''<summary>
    '''Liefert oder legt fest, welche Zeicehnfolge nach Textausgabe eingefügt wird, 
    '''wenn AppenWhiteSpace den Wert True besitzt.
    '''</summary>   
    Public Property WhiteSpace As String = New String(" "c, 1)

#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace