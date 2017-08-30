Option Explicit On
Option Strict On
Option Infer On

#Region " --------------->> Imports/ usings "
#End Region

Namespace ConsoleControls.BarMenus

	Public Class BarMenuHotKeyWrapperItem(Of T)

#Region " --------------->> Eigenschaften der Klasse "
		Private _value As T
		Private _hotKey As ConsoleKey
#End Region	'{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Public Sub New(ByVal value As T, ByVal hotKey As ConsoleKey)
			_value = value
			_hotKey = hotKey
		End Sub
#End Region	'{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		Public ReadOnly Property Value() As T
		Get
			Return _value
		End Get
		End Property

		Public ReadOnly Property HotKey() As ConsoleKey
		Get
			Return _hotKey
		End Get
		End Property
#End Region	'{Zugriffsmethoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
		Public Overrides Function ToString() As String
			Return String.Format("{0} {1}", Me.Value, If(Me.HotKey = 0, "", "<" & Me.HotKey.ToString & ">")).Trim
		End Function
#End Region	'{Öffentliche Methoden der Klasse}

	End Class

End Namespace
