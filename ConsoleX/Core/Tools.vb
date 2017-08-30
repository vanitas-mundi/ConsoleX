Option Explicit On
Option Strict On
Option Infer On

#Region " --------------->> Imports/ usings "
Imports System.Text
Imports SSP.ConsoleX.ConsoleDrawing
Imports System.Text.RegularExpressions
Imports SSP.Base.StringHandling
Imports SSP.ConsoleX.ConsoleText

#End Region

Namespace Core

  Public NotInheritable Class Tools
    'http://www.i8086.de/zeichensatz/code-page-850.html
    '█▄▀‗▬■×«»►◄▒▓©↕

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Shared Sub WriteXY _
    (ByVal s As String, ByVal x As Int32, ByVal y As Int32 _
    , ByVal foreColor As ConsoleColor, ByVal backColor As ConsoleColor)

      Console.ForegroundColor = foreColor
      Console.BackgroundColor = backColor

      Dim ar = Regex.Split(s, vbCrLf)

      For i = 0 To ar.Count - 1
        Console.SetCursorPosition(x, y + i)
        Console.Write(ar(i))
      Next

      Console.ResetColor()
    End Sub

    Public Shared Sub WriteXY(ByVal s As String, ByVal x As Int32, ByVal y As Int32)

      WriteXY(s, x, y, Console.ForegroundColor, Console.BackgroundColor)
    End Sub

    Public Shared Sub WriteXY _
    (ByVal s As String, ByVal x As Int32, ByVal y As Int32, ByVal colorSet As ColorSet)

      WriteXY(s, x, y, colorSet.ForeColor, colorSet.BackColor)
    End Sub

    Public Shared Sub WriteLineXY _
    (ByVal s As String, ByVal x As Int32, ByVal y As Int32 _
    , ByVal foreColor As ConsoleColor, ByVal backColor As ConsoleColor)

      WriteXY(s, x, y, foreColor, backColor)
      Console.WriteLine("")
    End Sub

    Public Shared Sub WriteLineXY _
    (ByVal s As String, ByVal x As Int32, ByVal y As Int32, ByVal colorSet As ColorSet)

      WriteLineXY(s, x, y, colorSet.ForeColor, colorSet.BackColor)
    End Sub

    Public Shared Sub WriteLineXY _
    (ByVal s As String, ByVal x As Int32, ByVal y As Int32)

      WriteXY(s, x, y)
      Console.WriteLine("")
    End Sub

    Public Shared Sub WriteLine _
    (ByVal s As String, ByVal foreColor As ConsoleColor, ByVal backColor As ConsoleColor)

      WriteXY(s, Console.CursorLeft, Console.CursorTop, foreColor, backColor)
      Console.WriteLine("")
    End Sub

    Public Shared Sub WriteLine(ByVal s As String, ByVal colorSet As ColorSet)

      WriteLine(s, colorSet.ForeColor, colorSet.BackColor)
    End Sub

    Public Shared Sub Write _
    (ByVal s As String, ByVal foreColor As ConsoleColor, ByVal backColor As ConsoleColor)

      WriteXY(s, Console.CursorLeft, Console.CursorTop, foreColor, backColor)
    End Sub

    Public Shared Sub Write(ByVal s As String, ByVal colorSet As ColorSet)

      Write(s, colorSet.ForeColor, colorSet.BackColor)
    End Sub

    Public Shared Sub ClearWindow(ByVal x As Int32, ByVal y As Int32 _
    , ByVal x2 As Int32, ByVal y2 As Int32)

      ClearWindow(x, y, x2, y2, Console.BackgroundColor)
    End Sub

    Public Shared Sub ClearWindow(ByVal x As Int32, ByVal y As Int32 _
    , ByVal x2 As Int32, ByVal y2 As Int32, ByVal color As ConsoleColor)

      For posY = y To y2
        WriteXY(Space(x2 - x + 1), x, posY, color, color)
      Next posY
    End Sub

    Public Shared Sub ClearWindow(ByVal bounds As DialogBounds)

      ClearWindow(bounds.X, bounds.Y, bounds.X2, bounds.Y2, Console.BackgroundColor)
    End Sub

    Public Shared Sub ClearWindow(ByVal bounds As DialogBounds, ByVal color As ConsoleColor)

      ClearWindow(bounds.X, bounds.Y, bounds.X2, bounds.Y2, color)
    End Sub

    Public Shared Sub ClearLine(ByVal y As Int32, ByVal x As Int32 _
    , ByVal x2 As Int32, ByVal color As ConsoleColor)

      WriteRepeater(" "c, (x2 - x) + 1, x, y, color, color)
    End Sub

    Public Shared Sub ClearLine(ByVal y As Int32, ByVal x As Int32, ByVal x2 As Int32)

      ClearLine(y, x, x2, Console.BackgroundColor)
    End Sub

    Public Shared Sub ClearLine(ByVal y As Int32, ByVal color As ConsoleColor)

      ClearLine(y, 0, Console.WindowWidth - 1, color)
    End Sub

    Public Shared Sub ClearLine(ByVal y As Int32)

      ClearLine(y, 0, Console.WindowWidth - 1, Console.BackgroundColor)
    End Sub

    Public Shared Sub WriteRepeater(ByVal c As Char, ByVal loops As Int32 _
    , ByVal x As Int32, ByVal y As Int32 _
    , ByVal backGroundColor As ConsoleColor _
    , ByVal foreGroundColor As ConsoleColor)

      WriteXY(Space(loops).Replace(" ", c), x, y, foreGroundColor, backGroundColor)
    End Sub

    Public Shared Sub WriteRepeater(ByVal c As Char, ByVal loops As Int32, ByVal x As Int32, ByVal y As Int32)

      WriteRepeater(c, loops, x, y, Console.BackgroundColor, Console.ForegroundColor)
    End Sub

    Public Shared Sub DrawBorder(ByVal settings As BorderSettings)

      Tables.DrawBorder(settings)
    End Sub

    Public Shared Sub DrawHeaderBorder(ByVal settings As HeaderBorderSettings)

      With settings
        Dim tableSettings = New TableSettings
        tableSettings.ColWidths.Add((.X2 - .X) - 1)
        tableSettings.RowHeights.Add(.HeaderHeight)
        tableSettings.RowHeights.Add((.Y2 - .Y) - (.HeaderHeight + 2))
        tableSettings.BorderStyleType = .BorderStyleType
        tableSettings.X = .X
        tableSettings.Y = .Y
        tableSettings.ColorSet = .ColorSet
        tableSettings.Values.Add(.HeaderText)
        tableSettings.Values.Add(.BodyText)
        Tables.ShowTable(tableSettings)
        Console.SetCursorPosition(.X + 2, .Y + .HeaderHeight + 2)
      End With
    End Sub

    ''' <summary>
    ''' Zeichnet ein horizontales Lineal
    ''' </summary>
    Public Shared Sub DrawRulerHorizontal(ByVal x As Int32, ByVal y As Int32, ByVal len As Int32)

      Dim sb = New StringBuilder

      For i = 0 To len - 1
        Select Case True
          Case (i + 1) Mod 10 = 0
            sb.Append(((i + 1) \ 10).ToString)
          Case (i + 1) Mod 5 = 0
            sb.Append("|")
          Case Else
            sb.Append(".")
        End Select
      Next i

      WriteXY(sb.ToString, x, y)
    End Sub

    ''' <summary>
    ''' Zeichnet ein vertikales Lineal
    ''' </summary>
    Public Shared Sub DrawRulerVertical(ByVal x As Int32, ByVal y As Int32, ByVal len As Int32)

      For i = 0 To len - 1
        Select Case True
          Case (i + 1) Mod 10 = 0
            WriteXY(((i + 1) \ 10).ToString, x, y + i)
          Case (i + 1) Mod 5 = 0
            WriteXY("-", x, y + i)
          Case Else
            WriteXY(".", x, y + i)
        End Select
      Next i
    End Sub

    '''<summary>Kürzt den übergebenen String auf auf die angegebene Länge.</summary>
    Public shared Function StringShorten(ByVal s As String, ByVal len As Integer) As String

      Return ConsoleTextFunctions.Instance.StringShorten(s, len)
    End Function
#End Region  'Öffentliche Methoden der Klasse}

    ''' <summary>
    ''' Kürzt den übergebenen Pfad auf auf die angegebene Länge.
    ''' </summary>
    Public Shared Function PathShorten(ByVal path As String, ByVal len As Integer) As String

      Dim pathParts() = Split(path, "\")
      Dim pathBuild = New StringBuilder(path.Length)
      Dim lastPart = pathParts(pathParts.Length - 1)
      Dim prevPath = ""

      'Erst prüfen ob der komplette String evtl. bereits kürzer als die Maximallänge ist
      If path.Length < len Then Return path

      For i As Integer = 0 To pathParts.Length - 1
        pathBuild.Append(pathParts(i) & "\")
        If (pathBuild.ToString & "...\" & lastPart).Length >= len Then
          Return prevPath
        Else
          prevPath = pathBuild.ToString & "...\" & lastPart
        End If
      Next i
      Return prevPath
    End Function

  End Class

End Namespace
