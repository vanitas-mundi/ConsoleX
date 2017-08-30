Option Explicit On
Option Strict On
Option Infer On

#Region " --------------->> Imports/ usings "
#End Region

Namespace ConsoleControls.BarMenus

  Public Class FilePicker

    Inherits PathPicker

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New(ByVal barMenuInfos As BarMenuInfos)
      MyBase.New(barMenuInfos)
      Initialize(New String() {})
    End Sub

    Public Sub New(ByVal barMenuInfos As BarMenuInfos, ByVal shortenPathAfter As Int32)
      MyBase.New(barMenuInfos, shortenPathAfter)
      Initialize(New String() {})
    End Sub

    Public Sub New(ByVal barMenuInfos As BarMenuInfos, ByVal wildCards() As String)
      MyBase.New(barMenuInfos)
      Initialize(wildCards)
    End Sub

    Public Sub New(ByVal barMenuInfos As BarMenuInfos, ByVal wildCards() As String, ByVal shortenPathAfter As Int32)

      MyBase.New(barMenuInfos, shortenPathAfter)
      Initialize(wildCards)
    End Sub

    Private Sub Initialize(ByVal wildCards() As String)

      _listFiles = True
      _wildcards = wildCards
    End Sub
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public ReadOnly Property FileName() As String
      Get
        Return _fileName
      End Get
    End Property
#End Region '{Zugriffsmethoden der Klasse}

  End Class

End Namespace
