Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.ConsoleX.ConsoleText
Imports ConsoleListening.NativeMethods
#End Region

Namespace Helper.EventArgs

  Public Class ConsoleKeyEventArgs

    Inherits System.EventArgs

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Friend Sub New(ByVal args As KEY_EVENT_RECORD)
      Me.KeyEventRecord = args

      Dim keyChar = If(args.UnicodeChar = vbNullChar, ConsoleTextFunctions.Instance.SpaceChar, args.UnicodeChar)
      Dim key = CType(args.wVirtualKeyCode, ConsoleKey)

      Me.KeyInfo = New ConsoleKeyInfo(keyChar, key, IsShift(args), IsAlt(args), IsControl(args))
    End Sub

#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public ReadOnly Property Key As ConsoleKey
      Get
        Return Me.KeyInfo.Key
      End Get
    End Property
    Public ReadOnly Property KeyInfo As ConsoleKeyInfo

    Public ReadOnly Property KeyEventRecord As KEY_EVENT_RECORD
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
    Private Function IsShift(ByVal args As KEY_EVENT_RECORD) As Boolean
      Return args.dwControlKeyState = 16
    End Function

    Private Function IsAlt(ByVal args As KEY_EVENT_RECORD) As Boolean
      Return (args.dwControlKeyState = 2) OrElse (args.dwControlKeyState = 265)
    End Function

    Private Function IsControl(ByVal args As KEY_EVENT_RECORD) As Boolean
      Return (args.dwControlKeyState = 8) OrElse (args.dwControlKeyState = 260)
    End Function
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
