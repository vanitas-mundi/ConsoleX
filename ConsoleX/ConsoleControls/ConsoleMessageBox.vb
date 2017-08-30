Option Explicit On
Option Strict On
Option Infer On

#Region " --------------->> Imports/ usings "
Imports SSP.ConsoleX.ConsoleControls.Enums
Imports SSP.ConsoleX.ConsoleDrawing
Imports SSP.ConsoleX.Core

#End Region

Namespace ConsoleControls

  Public Class ConsoleMessageBox

#Region " --------------->> Eigenschaften der Klasse "
    Private _title As String
    Private _message() As String
    Private _x As Int32
    Private _y As Int32
    Private _x2 As Int32
    Private _colorSet As ColorSet
    Private _windowHeight As Integer

    Private Shared _continueMessage As String = "Taste, um fortzufahren ..."
    Private Shared _yesMessage As String = "Ja"
    Private Shared _noMessage As String = "Nein"
    Private Shared _okMessage As String = "OK"
    Private Shared _cancelMessage As String = "Abbrechen"

    Private Shared _yesKey As ConsoleKey = ConsoleKey.J
    Private Shared _noKey As ConsoleKey = ConsoleKey.N
    Private Shared _okKey As ConsoleKey = ConsoleKey.Enter
    Private Shared _cancelKey As ConsoleKey = ConsoleKey.Escape
#End Region  '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New(ByVal title As String, ByVal message() As String _
    , ByVal x As Int32, ByVal y As Int32, ByVal width As Int32)

      Initialize(title, message, x, y, width, DefaultColorSet.Instance)
    End Sub

    Public Sub New(ByVal title As String, ByVal message() As String _
    , ByVal x As Int32, ByVal y As Int32 _
    , ByVal width As Int32, ByVal colorSet As ColorSet)

      Initialize(title, message, x, y, width, colorSet)
    End Sub

    Private Sub Initialize(ByVal title As String, ByVal message() As String _
    , ByVal x As Int32, ByVal y As Int32 _
    , ByVal width As Int32, ByVal colorSet As ColorSet)

      _title = title
      _message = message
      _x = x
      _y = y
      _x2 = width
      _colorSet = colorSet
    End Sub
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public Property Message() As String()
      Get
        Return _message
      End Get
      Set(ByVal value As String())
        _message = value
      End Set
    End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Shared Sub SetMessages(ByVal continueMessage As String _
    , ByVal yesMessage As String, ByVal noMessage As String, ByVal okMessage As String, ByVal cancelMessage As String _
    , ByVal yesKey As ConsoleKey, ByVal noKey As ConsoleKey, ByVal okKey As ConsoleKey, ByVal cancelKey As ConsoleKey)

      _continueMessage = continueMessage
      _yesMessage = yesMessage
      _noMessage = noMessage
      _okMessage = okMessage
      _cancelMessage = cancelMessage

      _yesKey = yesKey
      _noKey = noKey
      _okKey = okKey
      _cancelKey = cancelKey
    End Sub

    Public Function ShowMessage(ByVal messageBoxType As MessageBoxTypes) As MessageBoxResults

      Dim visible = Console.CursorVisible
      Console.CursorVisible = False

      _windowHeight = If(messageBoxType = MessageBoxTypes.InfoBox, 5, 7) + +_message.Count

      Try
        Dim settings = New HeaderBorderSettings With {
        .HeaderText = _title,
        .X = _x,
        .Y = _y,
        .X2 = _x2,
        .Y2 = _y + _windowHeight,
        .ColorSet = _colorSet
        }

        Tools.DrawHeaderBorder(settings)

        For i = 0 To _message.Count - 1
          Tools.WriteXY(_message(i), _x + 2, _y + 4 + i, _colorSet)
        Next i

        Dim x = _x + 2
        Dim y = _y + 7 + _message.Count - 1

        Select Case messageBoxType
          Case MessageBoxTypes.InfoBox
            Return MessageBoxResults.OK
          Case MessageBoxTypes.Message
            Tools.WriteXY(String.Format("<{0}>", _continueMessage), x, y, _colorSet)
            Console.ReadKey()
            Return MessageBoxResults.OK
          Case MessageBoxTypes.CancelOK
            Tools.WriteXY(String.Format("<{0}>={1}    <{2}>={3}" _
          , _okMessage, _okKey.ToString, _cancelMessage, _cancelKey.ToString), x, y, _colorSet)
            Dim key As ConsoleKey
            Do
              key = Console.ReadKey(True).Key
              Select Case key
                Case _okKey
                  Return MessageBoxResults.OK
                Case _cancelKey
                  Return MessageBoxResults.Cancel
              End Select
            Loop Until (key = _okKey) OrElse (key = _cancelKey)
          Case MessageBoxTypes.Question
            Tools.WriteXY(String.Format("<{0}>={1}    <{2}>={3}" _
          , _yesMessage, _yesKey.ToString, _noMessage, _noKey.ToString), x, y, _colorSet)
            Dim key As ConsoleKey
            Do
              key = Console.ReadKey(True).Key
              Select Case key
                Case _yesKey
                  Return MessageBoxResults.Yes
                Case _noKey
                  Return MessageBoxResults.No
              End Select
            Loop Until (key = _yesKey) OrElse (key = _noKey)
          Case MessageBoxTypes.YesNoCancel
            Tools.WriteXY(String.Format("<{0}>={1}    <{2}>={3}    <{4}>={5}" _
          , _yesMessage, _yesKey.ToString, _noMessage, _noKey.ToString, _cancelMessage, _cancelKey.ToString), x, y, _colorSet)
            Dim key As ConsoleKey
            Do
              key = Console.ReadKey(True).Key
              Select Case key
                Case _yesKey
                  Return MessageBoxResults.Yes
                Case _noKey
                  Return MessageBoxResults.No
                Case _cancelKey
                  Return MessageBoxResults.Cancel
              End Select
            Loop Until (key = _yesKey) OrElse (key = _noKey) OrElse (key = _cancelKey)
        End Select
      Catch ex As Exception
      Finally
        If Not messageBoxType = MessageBoxTypes.InfoBox Then
          ClearMessageBox()
        End If
        Console.CursorVisible = visible
      End Try

      Return MessageBoxResults.Cancel
    End Function

    Public Sub ClearMessageBox()
      Tools.ClearWindow(_x, _y, _x2, _y + _windowHeight, _colorSet.BackColor)
    End Sub
#End Region  'Öffentliche Methoden der Klasse}

  End Class

End Namespace
