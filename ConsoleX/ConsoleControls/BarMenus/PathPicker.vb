Option Explicit On
Option Strict On
Option Infer On

#Region " --------------->> Imports/ usings "
Imports SSP.ConsoleX.Core
Imports SSP.ConsoleX.ConsoleControls.Enums
Imports SSP.ConsoleX.ConsoleControls.BarMenus.EventArgs
Imports SSP.ConsoleX.ConsoleText
#End Region

Namespace ConsoleControls.BarMenus

  Public Class PathPicker

#Region " --------------->> Eigenschaften der Klasse "
    Protected _lastSelectedIndex As Int32
    Protected _barMenuInfos As BarMenuInfos
    Protected _shortenPathAfter As Int32
    Protected _listFiles As Boolean = False
    Protected _fileName As String
    Protected _wildcards() As String = New String() {}
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New(ByVal barMenuInfos As BarMenuInfos)

      Initialize(barMenuInfos, 78 - barMenuInfos.X)
    End Sub

    Public Sub New(ByVal barMenuInfos As BarMenuInfos, ByVal shortenPathAfter As Int32)

      Initialize(barMenuInfos, shortenPathAfter)
    End Sub

    Private Sub Initialize(ByVal barMenuInfos As BarMenuInfos, ByVal shortenPathAfter As Int32)

      _barMenuInfos = barMenuInfos
      _shortenPathAfter = shortenPathAfter
    End Sub
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public Property Border() As Boolean = True

    Public Property SelectedPath() As String
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden der Klasse "
    Private Sub OnBarMenuKeyPressed(ByVal sender As Object, ByVal e As BarMenuKeyPressedEventArgs)

      If e.KeyInfo.Key = ConsoleKey.Backspace Then
        e.ExitBarMenu = True
        e.ReturnDialogResult = DialogResults.OK
        e.ReturnValue = "[..]"
      End If
    End Sub
#End Region  '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
    Private Sub ClearSelectedPathDrawing()
      With _barMenuInfos
        Dim x = .X + 1
        Dim y = .Y + .VisibleItems + 3

        Tools.ClearLine(y, x, x + _shortenPathAfter, .ColorSet.BackColor)
      End With
    End Sub

    Private Function DrawSelectedPath(ByVal path As String, ByVal showDrives As Boolean) As String

      With _barMenuInfos
        Dim x = .X + 1
        Dim y = .Y + .VisibleItems + 3

        Tools.ClearLine(y, x, x + _shortenPathAfter, .ColorSet.BackColor)

        If showDrives Then
          Tools.WriteXY("\", x, y, .ColorSet)
          Return GetDrive(.X, .Y)
        Else
          Tools.WriteXY(ConsoleTextFunctions.Instance.PathShorten(path, _shortenPathAfter), x, y, .ColorSet)
          Return GetSubFolders(path, .X, .Y)
        End If
      End With
    End Function

    Private Function GetDrive(ByVal x As Int32, ByVal y As Int32) As String

      With _barMenuInfos

        Dim barMenuInfos = New BarMenuInfos(My.Computer.FileSystem.Drives.ToArray, 0, x, y, .ColorSet, .VisibleItems)

        Dim bm = New BarMenu(Of IO.DriveInfo)(barMenuInfos) With {.Border = Me.Border}
        Return If(bm.ShowMenu() = DialogResults.Cancel, "", bm.Value.Name)
      End With
    End Function

    Private Function GetSubFolders(ByVal path As String, ByVal x As Int32, ByVal y As Int32) As String

      With _barMenuInfos
        Try
          Dim temp = My.Computer.FileSystem.GetDirectories(path).ToList
          Dim foldersItems = New List(Of String)
          If Not _listFiles Then foldersItems.Add("[auswählen]")
          foldersItems.Add("[\..]")
          foldersItems.Add("[..]")

          For Each folder In temp
            foldersItems.Add(String.Format("{0}{1}", My.Computer.FileSystem.GetName(folder), If(_listFiles, " <DIR>", String.Empty)))
          Next folder

          If _listFiles Then
            If _wildcards.Any Then
              temp = My.Computer.FileSystem.FindInFiles _
              (path, String.Empty, True, FileIO.SearchOption.SearchTopLevelOnly, _wildcards).ToList
            Else
              temp = My.Computer.FileSystem.GetFiles(path).ToList
            End If

            temp.ForEach(Sub(file) foldersItems.Add(My.Computer.FileSystem.GetName(file)))
          End If

          Dim barMenuInfos = New BarMenuInfos(foldersItems.ToArray, _lastSelectedIndex, x, y, .ColorSet, .VisibleItems)

          Dim bm = New BarMenu(Of String)(barMenuInfos)
          AddHandler bm.KeyPressed, AddressOf OnBarMenuKeyPressed

          bm.Border = Me.Border
          If bm.ShowMenu() = DialogResults.Cancel Then Return String.Empty

          _lastSelectedIndex = bm.SelectedIndex

          If _listFiles Then
            Select Case True
              Case bm.Value.StartsWith("[")
                Return bm.Value
              Case bm.Value.IndexOf(" <DIR>", StringComparison.CurrentCulture) = -1
                _fileName = My.Computer.FileSystem.CombinePath(path, bm.Value)
                Return "[auswählen]"
              Case Else
                _lastSelectedIndex = 0
                Return bm.Value.Replace(" <DIR>", String.Empty)
            End Select
          Else
            _lastSelectedIndex = 0
            Return bm.Value
          End If

        Catch ex As Exception
          Return "\error\"
        End Try
      End With
    End Function
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Function ShowPathPicker() As DialogResults
      Dim path = "\"
      Dim value = ""
      Dim ok = False
      Dim showDrives = True

      If (Not String.IsNullOrEmpty(_SelectedPath)) AndAlso (My.Computer.FileSystem.DirectoryExists(_SelectedPath)) Then
        showDrives = False
        path = _SelectedPath
      End If

      With _barMenuInfos
        Do
          value = DrawSelectedPath(path, showDrives)
          showDrives = False
          Select Case value
            Case String.Empty
              ClearSelectedPathDrawing()
              Return DialogResults.Cancel
            Case "[\..]"
              path = path.Split("\"c)(0) & "\"
            Case "\error\", "[..]"
              Try
                path = My.Computer.FileSystem.GetParentPath(path)
              Catch ex As Exception
                showDrives = True
              End Try
            Case "[auswählen]"
              _SelectedPath = path
              ClearSelectedPathDrawing()
              Return DialogResults.OK
            Case Else
              path = My.Computer.FileSystem.CombinePath(path, value)
          End Select
        Loop Until ok
      End With
    End Function
#End Region 'Öffentliche Methoden der Klasse}

  End Class

End Namespace
