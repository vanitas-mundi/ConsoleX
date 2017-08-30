	Option Explicit On
Option Strict On
Option Infer On

#Region " --------------->> Imports/ usings "
#End Region

Namespace ConsoleControls.BarMenus

	Public Class BarMenuHotKeyWrapperItems(Of T)

		Implements IEnumerable(Of BarMenuHotKeyWrapperItem(Of T))

#Region " --------------->> Eigenschaften der Klasse "
		Private _items As New List(Of BarMenuHotKeyWrapperItem(Of T))
#End Region	'{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Public Sub New(ByVal values As T(), ByVal hotKeys As ConsoleKey())
			For i = 0 To values.Count - 1
				_items.Add(New BarMenuHotKeyWrapperItem(Of T)(values(i), If(i < hotKeys.Count, hotKeys(i), Nothing)))
			Next i
		End Sub
#End Region	'{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region	'{Zugriffsmethoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
		Public Function GetEnumerator() As IEnumerator(Of BarMenuHotKeyWrapperItem(Of T)) _
		Implements IEnumerable(Of BarMenuHotKeyWrapperItem(Of T)).GetEnumerator

			Return _items.GetEnumerator
		End Function

		Public Function GetEnumerator1() As IEnumerator Implements IEnumerable.GetEnumerator

			Return _items.GetEnumerator
		End Function

		Public Function Item(ByVal index As Int32) As BarMenuHotKeyWrapperItem(Of T)
			Return _items.Item(index)
		End Function

		Public Function Item(ByVal hotKey As ConsoleKey) As BarMenuHotKeyWrapperItem(Of T)
			Return _items.Where(Function(x) x.HotKey = hotKey).FirstOrDefault
		End Function
#End Region	'{Öffentliche Methoden der Klasse}

	 End Class

End Namespace
