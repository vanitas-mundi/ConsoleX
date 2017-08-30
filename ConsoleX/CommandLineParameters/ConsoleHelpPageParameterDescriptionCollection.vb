Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Text
#End Region

Namespace CommandLineParameters

  Public Class ConsoleHelpPageParameterDescriptionCollection

    Inherits List(Of ConsoleHelpPageParameterDescription)

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    '''<summary>Liefert die Länge des Paddings.</summary>
    Public ReadOnly Property NamePadding As Int32
      Get
        Return Me.Max(Function(x) x.NameLength + vbTab.Length)
      End Get
    End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
    Private Function GetDescriptionLines(ByVal description As String, ByVal nameLenght As Int32) As String()

      Dim info = New ConsoleText.ConsoleTextInfo With {
        .MaxWidth = Console.WindowWidth - nameLenght,
        .Value = description,
        .AppendNewLine = False
        }

      '.TextAlignment = ConsoleText.Enums.ConsoleTextAlignments.Block,

      Dim result = ConsoleText.ConsoleTextFunctions.Instance.GetFormattedTextLines(info)
      Return result
    End Function
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Overrides Function ToString() As String

      Dim sb = New StringBuilder
      Dim padding = Me.NamePadding

      For Each descriptionItem In Me.OrderBy(Function(x) x.Type)

        ' Beschreibungsnamen zwischenspeichern.
        Dim name = $"{New String(" "c, 4)}{descriptionItem.Name.PadRight(padding)}"

        Dim lines = GetDescriptionLines(descriptionItem.Description, name.Length)

        ' Erste Zeile einfügen.
        sb.Append($"{name}{lines.First}")

        ' Falls vorhanden jede weitere Zeile einfügen.
        For i = 1 To lines.Count - 1
          sb.Append(lines(i).PadLeft(Console.WindowWidth))
        Next i

      Next descriptionItem

      Return sb.ToString
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace