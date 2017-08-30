Option Explicit On
Option Strict On
Option Infer On

#Region " --------------->> Imports/ usings "
#End Region

Namespace ConsoleControls.BarMenus.EventArgs

	Public Class BarMenuDefaultItem(Of T)

		Inherits System.EventArgs

#Region " --------------->> Enumerationen der Klasse "
#End Region	'{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private _displayName As String
		Private _index As Int32
		Private _object As T
#End Region	'{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Public Sub New()
		End Sub

		Public Sub New _
		(ByVal displayName As String _
		, ByVal index As Int32 _
		, ByVal [object] As T)

			_displayName = displayName
			_index = index
			_object = [object]
		End Sub
#End Region	'{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		Public Property DisplayName() As String
		Get
			Return _displayName
		End Get
		Set(ByVal value As String)
			_displayName = value
		End Set
		End Property

		Public Property Index() As Int32
		Get
			Return _index
		End Get
		Set(ByVal value As Int32)
			_index = value
		End Set
		End Property

		Public Property [Object]() As T
		Get
			Return _object
		End Get
		Set(ByVal value As T)
			_object = value
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

