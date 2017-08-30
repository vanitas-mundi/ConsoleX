Option Explicit On
Option Strict On
Option Infer On

#Region " --------------->> Imports/ usings "
Imports System.ComponentModel
Imports SSP.ConsoleX.ConsoleDrawing

#End Region

Namespace ConsoleControls.BarMenus

  <DefaultProperty("SelectedItem")>
  Public Class BarMenuInfos

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New(ByVal x As Int32, ByVal y As Int32, ByVal visibleItems As Int32)

      Initialize(Nothing, 0, x, y, DefaultColorSet.Instance, visibleItems)
    End Sub

    Public Sub New(ByVal items() As Object, ByVal selectedIndex As Int32 _
    , ByVal x As Int32, ByVal y As Int32, ByVal visibleItems As Int32)

      Initialize(items, selectedIndex, x, y, DefaultColorSet.Instance, visibleItems)
    End Sub

    Public Sub New(ByVal x As Int32, ByVal y As Int32 _
    , ByVal colorSet As ColorSet, ByVal visibleItems As Int32)

      Initialize(Nothing, 0, x, y, colorSet, visibleItems)
    End Sub

    Public Sub New(ByVal items() As Object _
    , ByVal x As Int32, ByVal y As Int32, ByVal colorSet As ColorSet, ByVal visibleItems As Int32)

      Initialize(items, 0, x, y, colorSet, visibleItems)
    End Sub

    Public Sub New(ByVal items() As Object _
    , ByVal selectedIndex As Int32 _
    , ByVal x As Int32, ByVal y As Int32 _
    , ByVal colorSet As ColorSet, ByVal visibleItems As Int32)

      Initialize(items, selectedIndex, x, y, colorSet, visibleItems)
    End Sub

    Private Sub Initialize(ByVal items() As Object _
    , ByVal selectedIndex As Int32 _
    , ByVal x As Int32, ByVal y As Int32 _
    , ByVal colorSet As ColorSet, ByVal visibleItems As Int32)

      Me.Items = items
      Me.SelectedIndex = selectedIndex
      _X = x
      _Y = y
      _ColorSet = colorSet
      _VisibleItems = visibleItems
    End Sub

#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public Property Items() As Object()

    Public Property SelectedIndex() As Int32

    Public ReadOnly Property X() As Int32

    Public ReadOnly Property Y() As Int32

    Public ReadOnly Property ColorSet() As ColorSet

    Public ReadOnly Property VisibleItems() As Int32

    Public ReadOnly Property SelectedItem() As Object
      Get
        Return Me.Items(Me.SelectedIndex)
      End Get
    End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
