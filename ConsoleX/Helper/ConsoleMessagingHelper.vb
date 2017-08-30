Option Explicit On
Option Infer On
Option Strict On


#Region " --------------->> Imports/ usings "
Imports SSP.ConsoleX.ConsoleMessaging
Imports SSP.Base.SystemMessaging
Imports SSP.Base.SystemMessaging.Interfaces
#End Region

Namespace Helper

  Public Class ConsoleMessagingHelper

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Friend Sub New()
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public ReadOnly Property Registrations As New Dictionary(Of Object, Action(Of ConsoleViewTextMessage))
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}


    Public Sub Register(ByVal subscriber As Object, messageAction As Action(Of ISystemMessage))

      SystemMessageQueue.Instance.AddSubscriber(Of ConsoleViewTextMessage)(subscriber, messageAction)
    End Sub

    Public Sub UnRegister(ByVal subscriber As Object)

      SystemMessageQueue.Instance.RemoveSubscriber(Of ConsoleViewTextMessage)(subscriber)
    End Sub

    Public Sub SendConsoleViewTextMessage(ByVal sender As Object, ByVal messageText As String)

      SendConsoleViewTextMessage(New ConsoleViewTextMessage(sender, messageText))
    End Sub

    Public Sub SendConsoleViewTextMessage(ByVal sender As Object, ByVal messageText As String, ByVal data As Object)

      SendConsoleViewTextMessage(New ConsoleViewTextMessage(sender, messageText, data))
    End Sub

    Public Sub SendConsoleViewTextMessage(ByVal message As ConsoleViewTextMessage)

      SystemMessageQueue.Instance.SendSystemMessage(message)
    End Sub

    Public Sub SendConsoleViewTextMessage _
    (ByVal sender As Object, ByVal messageText As String, ByVal clearScreenBeforeMessage As Boolean)

      SendConsoleViewTextMessage(New ConsoleViewTextMessage(sender, messageText, clearScreenBeforeMessage))
    End Sub

    Public Sub SendConsoleViewTextMessage _
    (ByVal sender As Object, ByVal messageText As String, ByVal data As Object, ByVal clearScreenBeforeMessage As Boolean)

      SendConsoleViewTextMessage(New ConsoleViewTextMessage(sender, messageText, clearScreenBeforeMessage, data))
    End Sub

  End Class

End Namespace