Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace CommandLineParameters

  Public Class ArgumentDefinitionInfo

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    '''<summary>
    '''Optionaler Name des Arguments.
    '''Bsp.: path:c:\test.txt (ohne Name - c:\test.txt)
    '''</summary>
    Public Property Name As String = String.Empty

    '''<summary>
    '''Optionale Argumentbeschreibung für Hilfe-Anzeige.
    '''</summary>
    Public Property HelpDescription As String = String.Empty

    '''<summary>
    '''Name für den Parameterwert in der Hilfe.
    '''</summary>
    Public Property ValueName As String = "Value"
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
