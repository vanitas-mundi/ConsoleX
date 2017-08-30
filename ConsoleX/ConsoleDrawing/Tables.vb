Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Text.RegularExpressions
Imports SSP.ConsoleX.Core
#End Region

Namespace ConsoleDrawing

  Public Class Tables

#Region " --------------->> Enumerationen der Klasse "
#End Region  '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region  '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region  '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region  '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
    Private Shared Function InitializeTable(ByVal width As Int32, ByVal height As Int32) As List(Of Char())

      Dim table = New List(Of Char())

      For currentHeight = 1 To height
        Dim line(width - 1) As Char
        For currentWidth = 0 To line.Count - 1
          line(currentWidth) = " "c
        Next currentWidth
        table.Add(line)
      Next currentHeight
      Return table
    End Function

    Private Shared Function InitializeTable(ByVal tableSettings As TableSettings) As List(Of Char())

      Return InitializeTable(tableSettings.TableWidth, tableSettings.TableHeight)
    End Function

    Private Shared Sub BuildMainBorder(ByRef table As List(Of Char()) _
    , ByVal width As Int32, ByVal height As Int32, ByVal borderStyle As BorderStyles)

      With borderStyle
        'Hauptrahmen zeichnen
        For currentWidth = 0 To width - 1
          table(0)(currentWidth) = .HorizontalLine
          table(table.Count - 1)(currentWidth) = .HorizontalLine
        Next currentWidth

        For currentHeight = 0 To height - 1
          table.Item(currentHeight)(0) = .VerticalLine
          table.Item(currentHeight)(width - 1) = .VerticalLine
        Next currentHeight

        'Ecken zeichnen
        table(0)(0) = .LeftTopCorner
        table(0)(width - 1) = .RightTopCorner
        table(height - 1)(0) = .LeftBottomCorner
        table(height - 1)(width - 1) = .RightBottomCorner
      End With
    End Sub

    Private Shared Sub DrawMainBorder(ByRef table As List(Of Char()), ByVal tableSettings As TableSettings)

      BuildMainBorder(table, tableSettings.TableWidth, tableSettings.TableHeight, tableSettings.BorderStyle)
    End Sub

    Private Shared Sub DrawRowsAndColumns(ByVal table As List(Of Char()), ByVal tableSettings As TableSettings)

      With tableSettings.BorderStyle

        Dim crossingRow = New List(Of Int32)

        'Rows zeichnen
        Dim rowTop = 0
        For row = 0 To tableSettings.RowHeights.Count - 2
          rowTop += tableSettings.RowHeights(row) + 1
          crossingRow.Add(rowTop)
          For currentWidth = 0 To tableSettings.TableWidth - 1
            table(rowTop)(currentWidth) = .HorizontalLine
          Next currentWidth
          table(rowTop)(0) = .LeftCrossing
          table(rowTop)(tableSettings.TableWidth - 1) = .RightCrossing
        Next row

        'Columns zeichnen
        Dim colWidth = 0
        For col = 0 To tableSettings.ColWidths.Count - 2
          colWidth += tableSettings.ColWidths(col) + 1

          For currentHeight = 0 To tableSettings.TableHeight - 1
            table(currentHeight)(colWidth) = .VerticalLine
          Next currentHeight
          table(0)(colWidth) = .TopCrossing
          table(tableSettings.TableHeight - 1)(colWidth) = .BottomCrossing
          For Each row In crossingRow
            table(row)(colWidth) = .MiddleCrossing
          Next row
        Next col
      End With

    End Sub

    Private Shared Sub InsertValues(ByRef table As List(Of Char()), ByVal tableSettings As TableSettings)

      With tableSettings

        If (.Values Is Nothing) OrElse (.Values.Count = 0) Then Return

        Dim currentRowHeight = 1 + .RowPadding
        Dim currentColWidth = 1 + .ColPadding
        Dim valueIndex = 0

        For Each row In .RowHeights
          For Each col In .ColWidths
            Dim valueLines = Regex.Split(.Values(valueIndex), vbCrLf)

            For valuePartIndex = 0 To valueLines.Count - 1
              Dim value = valueLines(valuePartIndex)
              For i = 0 To value.Length - 1
                table(currentRowHeight + valuePartIndex)(currentColWidth + i) = value.Chars(i)
              Next i
            Next valuePartIndex

            valueIndex += 1
            If valueIndex > .Values.Count - 1 Then Return

            currentColWidth += col + 1
          Next col

          currentRowHeight += row + 1
          currentColWidth = 1 + .ColPadding
        Next row
      End With

    End Sub

    Private Shared Sub DrawTable _
    (ByRef table As List(Of Char()), ByVal x As Int32, ByVal y As Int32 _
    , ByVal foreColor As ConsoleColor, ByVal backColor As ConsoleColor)

      Dim border = String.Join(vbCrLf, table.Select(Function(line) String.Join("", line)).ToArray)
      Tools.WriteXY(border, x, y, foreColor, backColor)
    End Sub

    Private Shared Sub DrawTable(ByRef table As List(Of Char()), ByVal tableSettings As TableSettings)

      DrawTable(table, tableSettings.X, tableSettings.Y _
      , tableSettings.ForeColor, tableSettings.BackColor)
    End Sub
#End Region  '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Shared Sub DrawBorder(ByVal bordersettings As BorderSettings)

      With bordersettings
        Dim table = InitializeTable(.Bounds.Width, .Bounds.Height)
        BuildMainBorder(table, .Bounds.Width, .Bounds.Height, .BorderStyle)
        DrawTable(table, .X, .Y, .ForeColor, .BackColor)
      End With
    End Sub

    Public Shared Sub ShowTable(ByVal tableSettings As TableSettings)

      Dim table = InitializeTable(tableSettings)
      DrawMainBorder(table, tableSettings)

      DrawRowsAndColumns(table, tableSettings)

      InsertValues(table, tableSettings)
      DrawTable(table, tableSettings)
    End Sub

#End Region  'Öffentliche Methoden der Klasse}

  End Class

End Namespace
