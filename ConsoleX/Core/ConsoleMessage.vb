Option Explicit On
Option Infer On
Option Strict On
Imports SSP.ConsoleX.Core.Enums

#Region " --------------->> Imports/ usings "
Imports SSP.ConsoleX.Core.EventArgs
#End Region

Namespace Core

  Public NotInheritable Class ConsoleMessage

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
    Public Shared Event MessageArrived(ByVal sender As Object, ByVal e As MessageArrivedEventArgs)
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Private Sub New()
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public Shared ReadOnly Property Instance As New ConsoleMessage
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary>Sendet eine Konsolenmeldung</summary>
    Public Sub SendMessage(ByVal sender As Object, ByVal info As ConsoleMessageInfo)
      RaiseEvent MessageArrived(sender, New MessageArrivedEventArgs(info))
    End Sub

    '''<summary>Sendet eine Konsolenmeldung</summary>
    Public Sub SendMessage(sender As Object, ByVal message As String)
      RaiseEvent MessageArrived(sender, New MessageArrivedEventArgs(message))
    End Sub

    Public Sub SendMessage _
    (sender As Object, ByVal message As String, ByVal messageOutput As ConsoleMessageOutputTypes)

      Dim info = New ConsoleMessageInfo(message) With {.MessageOutput = messageOutput}
      Dim args = New MessageArrivedEventArgs(info)
      RaiseEvent MessageArrived(sender, args)
    End Sub
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace