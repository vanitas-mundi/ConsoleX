Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.ConsoleX.Core.Enums
#End Region

Namespace Core

  Public Class ConsoleMessageInfo

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New(ByVal message As String)

      Me.Message = message
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "

    '''<summary>Liefert den Typ der Nachricht oder legt diesen fest.</summary>
    Public Property ConsoleMessageType As ConsoleMessageTypes = ConsoleMessageTypes.CommonMessage

    '''<summary>Liefert das Nachrichten-Präfix.</summary>
    Public ReadOnly Property ConsoleMessageTypePrefix As String
      Get
        Select Case Me.ConsoleMessageType
          Case ConsoleMessageTypes.CommonMessage
            Return String.Empty
          Case Else
            Dim value = Me.ConsoleMessageType.ToString.Replace("Message", String.Empty)
            Return $"[{value}] "
        End Select
      End Get
    End Property

    '''<summary>
    '''Liefert einen Wert, welcher angibt, ob das Nachrichten-Präfix 
    '''angezeigt werden soll, oder legt diesen fest.
    '''</summary>
    Public Property DisplayConsoleMessageType As Boolean = False

    '''<summary>Liefert die auszugebende Nachricht oder legt diese fest.</summary>
    Public Property Message As String

    '''<summary>Liefert die verwendete X-Ausgabeposition oder legt diese fest.</summary>
    Public Property X As Int32 = Console.CursorLeft

    '''<summary>Liefert die verwendete Y-Ausgabeposition oder legt diese fest.</summary>
    Public Property Y As Int32 = Console.CursorTop

    '''<summary>Liefert die verwendete Schriftfarbe oder legt diese fest.</summary>
    Public Property ForeColor As ConsoleColor = Console.ForegroundColor

    '''<summary>Liefert die verwendete Hintergrundfarbe oder legt diese fest.</summary>
    Public Property BackColor As ConsoleColor = Console.BackgroundColor

    '''<summary>Liefert die verwendete Ausgabequelle oder legt diese fest.</summary>
    Public Property MessageOutput As ConsoleMessageOutputTypes = ConsoleMessageOutputTypes.Console

    Private Property PreservedConsoleInfo As ConsoleMessageInfo
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
    Private Sub PreserveConsoleInfo()

      Me.PreservedConsoleInfo = New ConsoleMessageInfo _
      (Me.Message) With
      {
        .BackColor = Console.BackgroundColor _
        , .ForeColor = Console.ForegroundColor _
        , .X = Console.CursorLeft _
        , .Y = Console.CursorTop
      }
    End Sub

    Private Sub RestoreConsoleInfo(ByVal info As ConsoleMessageInfo)
      Console.BackgroundColor = info.BackColor
      Console.ForegroundColor = info.ForeColor

      If Me.X <> Me.PreservedConsoleInfo.X Then Console.CursorLeft = info.X
      If Me.Y <> Me.PreservedConsoleInfo.Y Then Console.CursorTop = info.Y
      If Me.Message <> Me.PreservedConsoleInfo.Message Then Me.Message = info.Message
    End Sub

    Private Function GetDisplayMessage() As String
      Dim prefix = If(Me.DisplayConsoleMessageType, $"{Me.ConsoleMessageTypePrefix}", String.Empty)
      Return $"{prefix}{Me.Message}"
    End Function

    Private Sub WriteMessageBase()
      Select Case Me.MessageOutput
        Case ConsoleMessageOutputTypes.Title
          Console.Title = GetDisplayMessage.Trim
        Case ConsoleMessageOutputTypes.TitleWithAppName
          Console.Title = $"{My.Application.Info.AssemblyName} - {Me.GetDisplayMessage.Trim}"
        Case Else
          RestoreConsoleInfo(Me)
          Console.Write(Me.GetDisplayMessage)
          RestoreConsoleInfo(PreservedConsoleInfo)
      End Select
    End Sub
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary>Liefert den Inhalt der Message-Eigenschaft.</summary>
    Public Overrides Function ToString() As String
      Return Me.Message
    End Function

    '''<summary>Kopiert das Ergebnis der ToString-Funktion in die Zwischenablage.</summary>
    Public Sub ToClipboard()
      My.Computer.Clipboard.SetText(Me.Message)
    End Sub

    '''<summary>Gibt die Nachricht unter Verwendung der ConsoleMessageInfo aus.</summary>
    Public Sub WriteMessage()
      PreserveConsoleInfo()
      WriteMessageBase()
    End Sub

    '''<summary>Gibt die Nachricht unter Verwendung der ConsoleMessageInfo aus.</summary>
    Public Sub WriteLineMessage()
      PreserveConsoleInfo()
      Me.Message &= vbCrLf
      WriteMessageBase()
    End Sub

    '''<summary>Liefert ein Standard-ConsoleMessageInfo-Objekt.</summary>
    Public Shared Function DefaultObject(ByVal message As String) As ConsoleMessageInfo

      Return New ConsoleMessageInfo(message)
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace