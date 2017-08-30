Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace Core.EventArgs

  Public Class MessageArrivedEventArgs

    Inherits System.EventArgs
#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New(ByVal message As String)
      Me.New(ConsoleMessageInfo.DefaultObject(message))
    End Sub

    Public Sub New(ByVal info As ConsoleMessageInfo)
      Me.Info = info
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    '''<summary>Liefert die auszugebende Nachricht.</summary>
    Public ReadOnly Property Message As String
      Get
        Return Info.Message
      End Get
    End Property

    '''<summary>Liefert die Ausgabeinformationen der Nachricht</summary>
    Public ReadOnly Property Info As ConsoleMessageInfo
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Overrides Function ToString() As String
      Return Me.Message
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace


