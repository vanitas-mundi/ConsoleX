Option Explicit On
Option Strict On
Option Infer On

#Region " --------------->> Imports/ usings "
Imports SSP.ConsoleX.ConsoleControls.Enums
#End Region

Namespace ConsoleControls.BarMenus.EventArgs

	Public Class BarMenuKeyPressedEventArgs

		Inherits System.EventArgs

#Region " --------------->> Enumerationen der Klasse "
#End Region	'{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private _keyInfo As ConsoleKeyInfo
		Private _exitBarMenu As Boolean = False
		Private _returnValue As Object = Nothing
		Private _returnDialogResult As DialogResults = DialogResults.OK
#End Region	'{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Public Sub New(ByVal keyInfo As ConsoleKeyInfo)
			_keyInfo = keyInfo
		End Sub
#End Region	'{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		Public ReadOnly Property KeyInfo() As ConsoleKeyInfo
		Get
			Return _keyInfo
		End Get
		End Property

		Public Property ExitBarMenu() As Boolean
		Get
			Return _exitBarMenu
		End Get
		Set(ByVal value As Boolean)
			_exitBarMenu = value
		End Set
		End Property

		Public Property ReturnValue() As Object
		Get
			Return _returnValue
		End Get
		Set(ByVal value As Object)
			_returnValue = value
		End Set
		End Property

		Public Property ReturnDialogResult() As DialogResults
		Get
			Return _returnDialogResult
		End Get
		Set(ByVal value As DialogResults)
			_returnDialogResult = value
		End Set
		End Property
#End Region	'{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region	'{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region	'{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region	'{Öffentliche Methoden der Klasse}

	End Class

End Namespace

