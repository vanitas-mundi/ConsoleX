Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.Base.StringHandling
Imports SSP.ConsoleX.Helper.EventArgs
#End Region

Namespace Helper

  Public Class ConsoleFunctionsHelper

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
    Public Event KeyPressedWhileLooping(ByVal e As LoopUntilCustomerKeyPressedEventArgs)
    Public Event SendMessage(ByVal message As String)
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Friend Sub New()
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "

#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary>
    '''Nimmt Tastatureingaben entgegen und ruft die übergebene CallBack-Funktion auf,
    '''bis Escape eingegeben wurde.
    '''</summary>
    Public Sub LoopUntilEscapePressed(ByVal callback As Action(Of LoopUntilCustomerKeyPressedEventArgs))

      LoopUntilCustomerKeysPressed(New ConsoleKey() {ConsoleKey.Escape}, callback)
    End Sub

    Public Sub LoopUntilCustomerKeyPressed(ByVal customerKey As ConsoleKey, ByVal callback As Action(Of LoopUntilCustomerKeyPressedEventArgs))

      LoopUntilCustomerKeysPressed(New ConsoleKey() {customerKey}, callback)
    End Sub

    Public Sub LoopUntilCustomerKeysPressed(ByVal customerKeys As ConsoleKey(), ByVal callback As Action(Of LoopUntilCustomerKeyPressedEventArgs))

      Dim result As LoopUntilCustomerKeyPressedEventArgs

      Do
        result = New LoopUntilCustomerKeyPressedEventArgs(Console.ReadKey(True))
        callback.Invoke(result)
      Loop Until customerKeys.Contains(result.Key)
    End Sub

#Region "-->  IfDebugModeWaitUntilKeyPressed"
    Public Sub IfDebugModeWaitUntilKeyPressed()
      IfDebugModeWaitUntilKeyPressed(True, CultureCodes.a_Default)
    End Sub

    Public Sub IfDebugModeWaitUntilKeyPressed(ByVal showMessage As Boolean)

      IfDebugModeWaitUntilKeyPressed(showMessage, CultureCodes.a_Default)
    End Sub

    Public Sub IfDebugModeWaitUntilKeyPressed(ByVal language As CultureCodes)

      IfDebugModeWaitUntilKeyPressed(True, language)
    End Sub

    Public Sub IfDebugModeWaitUntilKeyPressed(ByVal showMessage As Boolean, ByVal language As CultureCodes)

      If Not Debugger.IsAttached Then Return
      WaitUntilKeyPressed(showMessage, language)
    End Sub
#End Region

#Region "-->  WaitUntilKeyPressed"
    Public Sub WaitUntilKeyPressed()
      WaitUntilKeyPressed(True, CultureCodes.a_Default)
    End Sub

    Public Sub WaitUntilKeyPressed(ByVal showMessage As Boolean)

      WaitUntilKeyPressed(showMessage, CultureCodes.a_Default)
    End Sub

    Public Sub WaitUntilKeyPressed(ByVal language As CultureCodes)

      WaitUntilKeyPressed(True, language)
    End Sub

    Public Sub WaitUntilKeyPressed(ByVal showMessage As Boolean, ByVal language As CultureCodes)

      Console.WriteLine()
      Dim cursorVisible = Console.CursorVisible
      Console.CursorVisible = False

      If showMessage Then
        Dim settingName = $"PressAnyKeyMessage_{language.ToString}"
        Try
          Console.WriteLine($"<{My.Settings.Item(settingName)}>")
        Catch
          Console.WriteLine($"<{My.Settings.PressAnyKeyMessage_a_Default}>")
        End Try
      End If
      Console.ReadKey(True)

      Console.CursorVisible = cursorVisible
    End Sub
#End Region

    '''<summary>Setzt BufferHeight und -Width auf WindowHeigt und -Width.</summary>
    Public Sub SetBufferToWindowSize()
      Console.BufferHeight = Console.WindowHeight
      Console.BufferWidth = Console.WindowWidth
    End Sub
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace