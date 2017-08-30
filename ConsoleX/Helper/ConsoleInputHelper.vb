Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.ConsoleX.Helper.EventArgs
Imports ConsoleListening
Imports ConsoleListening.NativeMethods
#End Region

Namespace Helper

  Public Class ConsoleInputHelper

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
    Public Event MouseClick(ByVal e As ConsoleMouseEventArgs)
    Public Event MouseMove(ByVal e As ConsoleMouseEventArgs)
    Public Event MouseWheelMove(ByVal e As ConsoleMouseEventArgs)
    Public Event MouseEvent(ByVal e As ConsoleMouseEventArgs)
    Public Event KeyDown(ByVal e As ConsoleKeyEventArgs)
    Public Event KeyUp(ByVal e As ConsoleKeyEventArgs)
    Public Event KeyPressed(ByVal e As ConsoleKeyEventArgs)
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Friend Sub New()
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Private Property StandardInHandle As IntPtr
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
    Private Sub OnMouseEvent(ByVal e As MOUSE_EVENT_RECORD)

      Dim args = New ConsoleMouseEventArgs(e)

      If args.IsLeftMouseButtionPressed OrElse args.IsMiddleMouseButtionPressed OrElse args.IsRightMouseButtionPressed Then
        RaiseEvent MouseClick(args)
      End If

      If args.IsWheelDown OrElse args.IsWheelUp Then RaiseEvent MouseWheelMove(args)

      If args.IsMouseMoving Then RaiseEvent MouseMove(args)

      RaiseEvent MouseEvent(args)
    End Sub

    Private Sub OnKeyEvent(ByVal e As KEY_EVENT_RECORD)

      Dim args = New ConsoleKeyEventArgs(e)

      If e.bKeyDown Then
        RaiseEvent KeyDown(args)
        RaiseEvent KeyPressed(args)
      Else
        RaiseEvent KeyUp(args)
      End If
    End Sub
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
    Private Function GetMode() As UInteger

      Me.StandardInHandle = NativeMethods.GetStdHandle(NativeMethods.STD_INPUT_HANDLE)
      Dim mode As UInteger = 0
      NativeMethods.GetConsoleMode(Me.StandardInHandle, mode)
      Return mode
    End Function

    Private Sub SetMode(ByVal mode As UInteger)
      NativeMethods.SetConsoleMode(Me.StandardInHandle, mode)
    End Sub

    Private Sub ActivateInputBase(ByRef modeConst As UInteger)

      SetMode(GetMode() And Not NativeMethods.ENABLE_QUICK_EDIT_MODE Or modeConst)
    End Sub

    Private Sub DeactivateInputBase(ByRef inputConst As UInteger)

      SetMode(GetMode() And Not NativeMethods.ENABLE_QUICK_EDIT_MODE And Not inputConst)
    End Sub
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Sub ActivateMouseListening()
      DeactivateMouseListening()
      AddHandler ConsoleListener.MouseEvent, AddressOf OnMouseEvent
      ActivateInputBase(NativeMethods.ENABLE_MOUSE_INPUT)
    End Sub

    Public Sub ActiveKeyboardListening()
      DeactiveKeyboardListening()
      AddHandler ConsoleListener.KeyEvent, AddressOf OnKeyEvent
      ActivateInputBase(NativeMethods.ENABLE_WINDOW_INPUT)
    End Sub

    Public Sub DeactivateMouseListening()
      StopListening()
      DeactivateInputBase(NativeMethods.ENABLE_MOUSE_INPUT)
      RemoveHandler ConsoleListener.MouseEvent, AddressOf OnMouseEvent
    End Sub

    Public Sub DeactiveKeyboardListening()
      StopListening()
      DeactivateInputBase(NativeMethods.ENABLE_WINDOW_INPUT)
      RemoveHandler ConsoleListener.KeyEvent, AddressOf OnKeyEvent
    End Sub

    Public Sub StartListening()
      ConsoleListener.Start()
    End Sub

    Public Sub StopListening()
      ConsoleListener.Stop()
    End Sub
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace