Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports ConsoleListening.NativeMethods
#End Region

Namespace Helper.EventArgs

  Public Class ConsoleMouseEventArgs

    Inherits System.EventArgs

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Friend Sub New(ByVal args As MOUSE_EVENT_RECORD)
      Me.MouseEventRecord = args
      Me.IsLeftMouseButtionPressed = args.dwButtonState = 1
      Me.IsRightMouseButtionPressed = args.dwButtonState = 2
      Me.IsMiddleMouseButtionPressed = args.dwButtonState = 4
      Me.IsMouseMoving = args.dwButtonState = 0 AndAlso args.dwEventFlags = 1
      Me.IsLeftControlPressed = args.dwControlKeyState = 8
      Me.IsRightControlPressed = args.dwControlKeyState = 4
      Me.IsLeftAltPressed = args.dwControlKeyState = 2
      Me.IsRightAltPressed = args.dwControlKeyState = 9
      Me.IsShiftPressed = args.dwControlKeyState = 16
      Me.IsWheelUp = args.dwButtonState = 7864320 AndAlso args.dwEventFlags = 4
      Me.IsWheelDown = args.dwButtonState = 4287102976 AndAlso args.dwEventFlags = 4
      Me.X = args.dwMousePosition.X
      Me.Y = args.dwMousePosition.Y
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public ReadOnly Property MouseEventRecord As MOUSE_EVENT_RECORD
    Public ReadOnly Property IsLeftMouseButtionPressed As Boolean
    Public ReadOnly Property IsRightMouseButtionPressed As Boolean
    Public ReadOnly Property IsMiddleMouseButtionPressed As Boolean
    Public ReadOnly Property IsMouseMoving As Boolean
    Public ReadOnly Property IsLeftControlPressed As Boolean
    Public ReadOnly Property IsRightControlPressed As Boolean
    Public ReadOnly Property IsLeftAltPressed As Boolean
    Public ReadOnly Property IsRightAltPressed As Boolean
    Public ReadOnly Property IsShiftPressed As Boolean
    Public ReadOnly Property IsWheelUp As Boolean
    Public ReadOnly Property IsWheelDown As Boolean
    Public ReadOnly Property X As Int32
    Public ReadOnly Property Y As Int32
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace