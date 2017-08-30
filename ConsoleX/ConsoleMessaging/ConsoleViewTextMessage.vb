Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.Base.SystemMessaging
Imports SSP.ConsoleX.ConsoleText
#End Region

Namespace ConsoleMessaging

  Public Class ConsoleViewTextMessage

    Inherits SystemMessageBase

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New(ByVal sender As Object, ByVal messageText As String, ByVal data As Object)

      MyBase.New(sender, data)
      Me.MessageText = messageText
    End Sub

    Public Sub New(ByVal sender As Object, ByVal messageText As String, ByVal clearScreenBeforeMessage As Boolean, ByVal data As Object)

      Me.New(sender, messageText, data)
      Me.ClearScreenBeforeMessage = clearScreenBeforeMessage
    End Sub


    Public Sub New(ByVal sender As Object, ByVal messageText As String)

      MyBase.New(sender)
      Me.MessageText = messageText
    End Sub

    Public Sub New(ByVal sender As Object, ByVal messageText As String, ByVal clearScreenBeforeMessage As Boolean)

      Me.New(sender, messageText)
      Me.ClearScreenBeforeMessage = clearScreenBeforeMessage
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public ReadOnly Property MessageText As String = String.Empty

    Public ReadOnly ClearScreenBeforeMessage As Boolean = False
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace