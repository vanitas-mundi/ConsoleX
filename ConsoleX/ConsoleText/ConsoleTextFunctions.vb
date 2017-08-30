Option Explicit On
Option Infer On
Option Strict On
Imports System.Text

#Region " --------------->> Imports/ usings "
#End Region

Namespace ConsoleText

  Public NotInheritable Class ConsoleTextFunctions

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Private Sub New()
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public Shared ReadOnly Property Instance As New ConsoleTextFunctions

    Public ReadOnly Property SpaceChar As Char
      Get
        Return " "c
      End Get
    End Property

    Private Property CurrentForeColor As ConsoleColor

    Private Property CurrentBackColor As ConsoleColor
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
    Private Function TextWrapWords(ByVal words As String(), ByVal len As Int32) As String()

      Dim result = New List(Of String)

      For Each word In words
        If word.Length <= len Then
          result.Add(word)
        Else
          Dim temp = word

          Do
            Dim tempLen = Math.Min(len, temp.Length)
            result.Add(temp.Substring(0, tempLen))
            temp = temp.Substring(tempLen)
          Loop Until temp.Length = 0
        End If
      Next word

      Return result.ToArray
    End Function

    Private Function GetTextLines(ByVal info As ConsoleTextInfo) As List(Of String)

      Dim value = If(info.AppendWhiteSpace, $"{info.Value}{info.WhiteSpace}", info.Value)
      Dim result = New List(Of String)

      If info.MaxWidth = 0 Then
        result = Base.Helper.String.Functions.Split(value, vbCrLf).ToList
      Else
        For Each line In Base.Helper.String.Functions.Split(value, vbCrLf).ToList
          Select Case True
            Case line.Length <= info.MaxWidth
              result.Add(line)
            Case info.AllowTextWrap
              result.AddRange(StringShortenWithTextWrap(line, info.MaxWidth))
            Case Else
              result.Add(StringShorten(line, info.MaxWidth))
          End Select
        Next line
      End If

      If info.AppendNewLine Then result.Add(String.Empty)

      Return result
    End Function

    Private Function GetFormattedTextLine(ByVal info As ConsoleTextInfo, ByVal line As String) As String

      Return (New TextAlignmentFormatter(info.TextAlignment)).FormatText(line, info.MaxWidth)
    End Function
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary>Speichert das in Console hinterlegte Farbprofil.</summary>
    Public Sub StoreColors(ByVal info As ConsoleTextInfo)
      Me.CurrentForeColor = Console.ForegroundColor
      Me.CurrentBackColor = Console.BackgroundColor
      Console.ForegroundColor = info.ForeColor
      Console.BackgroundColor = info.BackColor
    End Sub

    '''<summary>Stellt das gesicherte Farbprofil wieder her.</summary>
    Public Sub RestoreColors()
      Console.ForegroundColor = Me.CurrentForeColor
      Console.BackgroundColor = Me.CurrentBackColor
    End Sub

    '''<summary>Liefert die einzelnen Wörter des angegebenen Strings als Array.</summary>
    Public Function DivideStringIntoWords(ByVal s As String) As String()

      Return s.Split(Me.SpaceChar)
    End Function

    '''<summary>Kürzt den übergebenen String auf auf die angegebene Länge.</summary>
    Public Function StringShorten(ByVal s As String, ByVal len As Integer) As String

      Return If(s.Length <= len, s, $"{s.Substring(0, len - 3)}...")
    End Function

    '''<summary>Kürzt den übergebenen String auf auf die angegebene Länge und bricht den Text ggf. um.</summary>
    Public Function StringShortenWithTextWrap(ByVal s As String, ByVal len As Int32) As String()

      Dim result = New List(Of String)

      If s.Length <= len Then
        result.Add(s)
      Else
        Dim words = TextWrapWords(DivideStringIntoWords(s), len)
        Dim temp = New StringBuilder

        For Each word In words
          If temp.Length + word.Length > len Then
            result.Add(temp.ToString.Trim)
            temp = New StringBuilder($"{word}{Me.SpaceChar}")
          Else
            temp.Append($"{word}{Me.SpaceChar}")
          End If
        Next word

        If temp.ToString.Trim.Length > 0 Then result.Add(temp.ToString.Trim)
      End If

      Return result.ToArray
    End Function

    '''<summary>Kürzt den übergebenen Pfad auf auf die angegebene Länge.</summary>
    Public Function PathShorten(ByVal path As String, ByVal len As Int32) As String

      Dim pathParts = Split(path, "\")
      Dim sb = New StringBuilder(path.Length)
      Dim lastPart = pathParts(pathParts.Length - 1)
      Dim currentPath = String.Empty

      ' Erst prüfen ob der komplette String evtl. bereits kürzer als die Maximallänge ist
      If path.Length < len Then Return path

      For i = 0 To pathParts.Length - 1
        sb.Append($"{pathParts(i)}\")

        Dim value = $"{sb.ToString}...\{lastPart}"
        If value.Length >= len Then
          Return currentPath
        Else
          currentPath = $"{sb.ToString}...\{lastPart}"
        End If
      Next i

      Return currentPath
    End Function

    '''<summary>Liefert die anhand von info formatierte Zeichenfolge als String-Array.</summary>
    Public Function GetFormattedTextLines(ByVal info As ConsoleTextInfo) As String()

      Dim result = New List(Of String)
      GetTextLines(info).ToList.ForEach(Sub(x) result.Add(GetFormattedTextLine(info, x)))

      Return result.ToArray
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace