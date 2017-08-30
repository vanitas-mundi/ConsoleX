Option Explicit On
Option Strict On
Option Infer On


#Region " --------------->> Imports/ usings "
Imports SSP.ConsoleX.ConsoleText
#End Region

Namespace ConsoleControls.BarMenus

  Public Class CheckBarMenu(Of T)

    Inherits BarMenu(Of T)

#Region " --------------->> Eigenschaften der Klasse "
    Private _selectedItems As New Generic.List(Of Int32)
    Private _values As T()
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New(ByVal barMenuInfos As BarMenuInfos)
      MyBase.New(barMenuInfos)
    End Sub
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public Property Checked(ByVal itemIndex As Int32) As Boolean
      Get
        Return _selectedItems.Contains(itemIndex)
      End Get
      Set(ByVal value As Boolean)
        If value Then
          If Not _selectedItems.Contains(itemIndex) Then _selectedItems.Add(itemIndex)
        Else
          If _selectedItems.Contains(itemIndex) Then _selectedItems.Remove(itemIndex)
        End If
      End Set
    End Property

    Public Property Checked(ByVal item As T) As Boolean
      Get
        Dim itemIndex = Array.IndexOf(_barMenuInfos.Items, item)
        Return _selectedItems.Contains(itemIndex)
      End Get
      Set(ByVal value As Boolean)
        Dim itemIndex = Array.IndexOf(_barMenuInfos.Items, item)

        If value Then
          If Not _selectedItems.Contains(itemIndex) Then _selectedItems.Add(itemIndex)
        Else
          If _selectedItems.Contains(itemIndex) Then _selectedItems.Remove(itemIndex)
        End If
      End Set
    End Property

    Public ReadOnly Property Values() As T()
      Get
        Return _values
      End Get
    End Property

    Protected Overrides ReadOnly Property LargestItem() As Integer
      Get
        Return MyBase.LargestItem + 4
      End Get
    End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
    Protected Overrides Function GetFormatedItem(ByVal itemIndex As Integer, ByVal isSelected As Boolean) As String

      Dim max = _currentWith - 2

      Dim selected = If(_selectedItems.Contains(itemIndex), "x", ConsoleTextFunctions.Instance.SpaceChar)
      Dim formatedItem = MyBase.GetFormatedItem(itemIndex, isSelected)
      Dim item = $" [{selected}]{formatedItem}"

      Dim result = String.Empty

      If item.Length > max Then
        If item.TrimEnd.Length > max Then
          result = $"{ConsoleTextFunctions.Instance.StringShorten(item, max - 1)} "
        Else
          result = item.Substring(1, max)
        End If
      Else
        result = item
      End If

      Return result
    End Function

    Protected Overrides Sub MenuAction(ByVal keyInfo As ConsoleKeyInfo)

      MyBase.MenuAction(keyInfo)

      With _barMenuInfos
        Select Case keyInfo.Key
          Case ConsoleKey.Enter
            Dim list = New List(Of T)
            _selectedItems.ForEach(Sub(x) list.Add(DirectCast(.Items(x), T)))
            _values = list.ToArray
          Case ConsoleKey.Spacebar
            If _selectedItems.Contains(.SelectedIndex) Then
              _selectedItems.Remove(.SelectedIndex)
            Else
              _selectedItems.Add(.SelectedIndex)
            End If
            DrawSelectedItem(.SelectedIndex, .X, _positionY)
          Case ConsoleKey.Delete
            _selectedItems.Clear()
            DrawMenu()
          Case ConsoleKey.Insert
            _selectedItems.Clear()
            For i As Int32 = 0 To _barMenuInfos.Items.Count - 1
              _selectedItems.Add(i)
            Next i
            DrawMenu()
        End Select
      End With
    End Sub
#End Region  '{Private Methoden der Klasse}

  End Class

End Namespace
