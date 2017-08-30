Option Explicit On
Option Strict On
Option Infer On

#Region " --------------->> Imports/ usings "
Imports System.Text
Imports SSP.ConsoleX.ConsoleControls.Enums
Imports SSP.ConsoleX.ConsoleDrawing
Imports SSP.ConsoleX.ConsoleControls.BarMenus.EventArgs
Imports SSP.ConsoleX.Core
Imports SSP.ConsoleX.ConsoleText

#End Region

Namespace ConsoleControls.BarMenus

  Public Class BarMenu(Of T)

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
    Protected _barMenuInfos As BarMenuInfos
    Protected _firstItemIndex As Int32
    Protected _largestItem As Int32
    Protected _border As Boolean = True
    Protected _value As T
    Protected _positionY As Int32
    Protected _exitArgs As New BarMenuKeyPressedEventArgs(Nothing)
    Protected _bounds As DialogBounds
    Protected _minimumWith As Int32 = 5
    Protected _maximumWith As Int32 = 40
    Protected _currentWith As Int32
    Protected _selectedItem As T
    Protected _selectedIndex As Int32
    Protected _infoLineLength As Int32 = 0

    Public Event KeyPressed(ByVal sender As Object, ByVal e As BarMenuKeyPressedEventArgs)
    Public Event ItemChanged(ByVal sender As Object, ByVal e As BarMenuItemChangedEventArgs(Of T))
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New(ByVal barMenuInfos As BarMenuInfos)
      _barMenuInfos = barMenuInfos
      GetLargestItem()
    End Sub
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public ReadOnly Property Items As T()
      Get
        Return _barMenuInfos.Items.OfType(Of T).ToArray
      End Get
    End Property

    Public ReadOnly Property SelectedItem() As T
      Get
        Return _selectedItem
      End Get
    End Property

    Public ReadOnly Property SelectedIndex As Int32
      Get
        Return _selectedIndex
      End Get
    End Property

    Public Property Border() As Boolean
      Get
        Return _border
      End Get
      Set(ByVal value As Boolean)
        _border = value
      End Set
    End Property

    Public ReadOnly Property Value() As T
      Get
        Return _value
      End Get
    End Property

    Public Property MinimumWith() As Int32
      Get
        Return _minimumWith
      End Get
      Set(ByVal value As Int32)
        _minimumWith = value
      End Set
    End Property

    Public Property MaximumWith() As Int32
      Get
        Return _maximumWith
      End Get
      Set(ByVal value As Int32)
        _maximumWith = value
      End Set
    End Property

    Protected Overridable ReadOnly Property LargestItem() As Int32
      Get
        Return _largestItem
      End Get
    End Property

    Public ReadOnly Property Bounds() As DialogBounds
      Get
        If _bounds Is Nothing Then SetCurrentWithAndBounds()
        Return _bounds
      End Get
    End Property

    Public ReadOnly Property Width() As Int32
      Get
        Return _currentWith
      End Get
    End Property

    Public ReadOnly Property Count As Int32
      Get
        Return _barMenuInfos.Items.Count
      End Get
    End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
    Protected Overridable Sub DrawMenu()
      With _barMenuInfos

        Dim currentY = .Y + 1

        For i = _firstItemIndex To (_firstItemIndex + .VisibleItems) - 1
          If i > .Items.Count - 1 Then Exit For

          If i = .SelectedIndex Then
            DrawSelectedItem(i, .X, currentY)
          Else
            DrawItem(i, .X, currentY)
          End If

          currentY += 1
        Next i

        _selectedItem = DirectCast(.Items(.SelectedIndex), T)
        _selectedIndex = .SelectedIndex
        RaiseEvent ItemChanged(Me, New BarMenuItemChangedEventArgs(Of T)(_selectedItem))
      End With
    End Sub

    Private Sub SetCurrentWithAndBounds()
      With _barMenuInfos
        _currentWith = If(Me.LargestItem + 4 > _maximumWith, _maximumWith, Me.LargestItem + 4)
        _currentWith = If(_currentWith < _minimumWith, _minimumWith, _currentWith)

        Dim x2 = _currentWith + .X - 1
        _bounds = New DialogBounds(.X, .Y, x2, .Y + .VisibleItems + 1)
      End With
    End Sub

    Protected Overridable Sub MenuAction(ByVal keyInfo As ConsoleKeyInfo)

      With _barMenuInfos
        Select Case keyInfo.Key
          Case ConsoleKey.Home
            .SelectedIndex = 0
            _firstItemIndex = 0
            DrawMenu()
          Case ConsoleKey.End
            .SelectedIndex = .Items.Count - 1
            _firstItemIndex = .SelectedIndex - (.VisibleItems - 1)
            If _firstItemIndex < 0 Then _firstItemIndex = 0
            DrawMenu()
          Case ConsoleKey.PageUp
            .SelectedIndex -= .VisibleItems
            If .SelectedIndex < 0 Then .SelectedIndex = 0
            _firstItemIndex = .SelectedIndex
            DrawMenu()
          Case ConsoleKey.PageDown
            .SelectedIndex += .VisibleItems
            If .SelectedIndex > .Items.Count - 1 Then .SelectedIndex = .Items.Count - 1
            _firstItemIndex = .SelectedIndex - (.VisibleItems - 1)
            If _firstItemIndex < 0 Then _firstItemIndex = 0
            DrawMenu()
          Case ConsoleKey.A To ConsoleKey.Z
            For i = 0 To .Items.Count - 1
              If .Items(i).ToString.ToUpper.StartsWith(ChrW(keyInfo.Key)) Then
                .SelectedIndex = i
                Select Case True
                  Case .SelectedIndex >= .VisibleItems
                    If i + .VisibleItems > .Items.Count - 1 Then
                      _firstItemIndex = .Items.Count - (.VisibleItems)
                    Else
                      _firstItemIndex = i
                    End If
                  Case Else
                    _firstItemIndex = 0
                End Select
                DrawMenu()
                Exit For
              End If
            Next i
          Case ConsoleKey.UpArrow
            MoveBarUp()
          Case ConsoleKey.DownArrow
            MoveBarDown()
          Case ConsoleKey.Enter
            _value = CType(.SelectedItem, T)
        End Select
      End With

      _exitArgs = New BarMenuKeyPressedEventArgs(Nothing)

      Dim args = New BarMenuKeyPressedEventArgs(keyInfo)
      RaiseEvent KeyPressed(Me, args)

      If args.ExitBarMenu Then
        _exitArgs.ExitBarMenu = args.ExitBarMenu
        _exitArgs.ReturnDialogResult = args.ReturnDialogResult
        _value = DirectCast(args.ReturnValue, T)
      End If
    End Sub

    Protected Sub MoveBarDown()
      With _barMenuInfos

        Select Case .SelectedIndex + 1
          Case Is > .Items.Count - 1
            Return
          Case Is >= (.VisibleItems + _firstItemIndex)
            .SelectedIndex += 1
            _firstItemIndex = (.SelectedIndex + 1) - .VisibleItems
            DrawMenu()
          Case Else
            DrawItem(.SelectedIndex, .X, _positionY)
            .SelectedIndex += 1
            DrawSelectedItem(.SelectedIndex, .X, _positionY + 1)

            _selectedItem = DirectCast(.Items(.SelectedIndex), T)
            _selectedIndex = .SelectedIndex
            RaiseEvent ItemChanged(Me, New BarMenuItemChangedEventArgs(Of T)(_selectedItem))
        End Select
      End With
    End Sub

    Protected Sub MoveBarUp()
      With _barMenuInfos
        Select Case .SelectedIndex - 1
          Case Is < 0
            Return
          Case Is < _firstItemIndex
            .SelectedIndex -= 1
            _firstItemIndex = .SelectedIndex
            DrawMenu()
          Case Else
            .SelectedIndex -= 1
            DrawMenu()
        End Select

        _selectedItem = DirectCast(.Items(.SelectedIndex), T)
        _selectedIndex = .SelectedIndex
        RaiseEvent ItemChanged(Me, New BarMenuItemChangedEventArgs(Of T)(_selectedItem))
      End With
    End Sub

    Protected Sub DrawItem(ByVal itemIndex As Int32, ByVal x As Int32, ByVal y As Int32)

      With _barMenuInfos
        Tools.WriteXY(GetFormatedItem(itemIndex, False), x + 1, y, .ColorSet)
      End With
    End Sub

    Protected Sub DrawSelectedItem(ByVal itemIndex As Int32, ByVal x As Int32, ByVal y As Int32)

      With _barMenuInfos
        _positionY = y
        Tools.WriteXY(GetFormatedItem(itemIndex, True), x + 1, y, .ColorSet.SelectionForeColor, .ColorSet.SelectionBackColor)
      End With
    End Sub

    Protected Overridable Function GetFormatedItem(ByVal itemIndex As Int32, ByVal isSelected As Boolean) As String

      With _barMenuInfos
        Dim max = _currentWith - 2
        Dim firstChar = IIf(isSelected, "►", " ").ToString
        Dim sb = New StringBuilder(firstChar & .Items(itemIndex).ToString & " ")

        If sb.Length <= max Then
          sb.Append(Space(max - sb.Length))
          Return sb.ToString
        Else
          Return ConsoleTextFunctions.Instance.StringShorten(sb.ToString, max - 1) & " "
        End If
      End With
    End Function

    Protected Sub GetLargestItem()
      With _barMenuInfos
        _largestItem = 0

        For Each item In .Items
          Dim len = item.ToString.Length
          If len > _largestItem Then _largestItem = len
        Next item

        If _largestItem > _maximumWith Then _largestItem = _maximumWith
      End With
    End Sub

    Protected Overridable Sub PrintInfoLine(ByVal info As String)
      With _barMenuInfos
        Dim x = .X + 1
        Dim y = .Y + .VisibleItems + 2

        ClearInfoLine()
        Tools.WriteXY(info, x, y, .ColorSet)
        _infoLineLength = info.Length
      End With
    End Sub
#End Region  '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Sub ClearInfoLine()
      With _barMenuInfos
        Tools.ClearLine(.Y + .VisibleItems + 2, .X + 1, .X + 1 + _infoLineLength, .ColorSet.BackColor)
      End With
    End Sub

    Public Sub ClearBox()
      Tools.ClearWindow(_bounds.X, _bounds.Y, _bounds.X2, _bounds.Y2, _barMenuInfos.ColorSet.BackColor)
    End Sub

    Public Sub ClearMenu()
      ClearBox()
      ClearInfoLine()
    End Sub

    Public Sub Add(ByVal item As T)
      Add(item, False)
    End Sub

    Public Sub Add(ByVal item As T, ByVal redraw As Boolean)
      With _barMenuInfos
        Dim list = .Items.ToList
        list.Add(item)
        .Items = list.ToArray

        If .SelectedIndex < 0 Then
          .SelectedIndex = 0
        End If

        If Not redraw Then Return

        GetLargestItem()
        ShowMenu()
      End With
    End Sub

    Public Sub Remove(ByVal item As T)
      Remove(item, False)
    End Sub

    Public Sub Remove(ByVal item As T, ByVal redraw As Boolean)
      RemoveAt(_barMenuInfos.Items.ToList.IndexOf(item), redraw)
    End Sub

    Public Sub RemoveAt(ByVal index As Int32)
      RemoveAt(index, False)
    End Sub

    Public Sub RemoveAt(ByVal index As Int32, ByVal redraw As Boolean)
      With _barMenuInfos
        Dim list = .Items.ToList

        If list.Count > 0 Then
          list.RemoveAt(index)
          .Items = list.ToArray

          If .SelectedIndex > .Items.Count - 1 Then
            .SelectedIndex = .Items.Count - 1
          End If
        End If

        If Not redraw Then Return

        Me.ClearMenu()
        GetLargestItem()
        ShowMenu()
      End With
    End Sub

    Public Sub Clear()
      Clear(False)
    End Sub

    Public Sub Clear(ByVal redraw As Boolean)
      With _barMenuInfos
        Dim list = .Items.ToList
        list.Clear()
        .Items = list.ToArray
        .SelectedIndex = -1

        If Not redraw Then Return

        Me.ClearMenu()
        GetLargestItem()
        ShowMenu()
      End With
    End Sub

    Public Overridable Function ShowMenu() As DialogResults

      With _barMenuInfos
        Dim visible = Console.CursorVisible
        Console.CursorVisible = False

        SetCurrentWithAndBounds()

        If _border Then
          Dim borderSettings = New BorderSettings With {.Bounds = _bounds, .ColorSet = .ColorSet}
          Tools.DrawBorder(borderSettings)
        End If

        _firstItemIndex = If(.SelectedIndex > .VisibleItems - 1, .SelectedIndex - (.VisibleItems - 1), 0)

        If .Items.Any Then DrawMenu()

        Dim infoLineString = String.Empty

        Dim key As ConsoleKeyInfo
        Do
          infoLineString = If(.Items.Count = 0, "0/0", $"{(.SelectedIndex + 1).ToString}/{ .Items.Count.ToString}")
          PrintInfoLine(infoLineString)

          key = Console.ReadKey(True)
          MenuAction(key)
        Loop Until (key.Key = ConsoleKey.Enter) _
        OrElse (key.Key = ConsoleKey.Escape) _
        OrElse (_exitArgs.ExitBarMenu)

        Console.CursorVisible = visible

        ClearMenu()

        Select Case True
          Case _exitArgs.ExitBarMenu
            Return _exitArgs.ReturnDialogResult
          Case key.Key = ConsoleKey.Enter
            Return DialogResults.OK
          Case key.Key = ConsoleKey.Escape
            Return DialogResults.Cancel
          Case Else
            Return DialogResults.Cancel
        End Select
      End With
    End Function
#End Region 'Öffentliche Methoden der Klasse}

  End Class

End Namespace


