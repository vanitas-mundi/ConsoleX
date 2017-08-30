Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace Helper

  Public NotInheritable Class ConsoleHelper

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Private Sub New()
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    '''<summary>Stellt ConsoleText-Funktionen zur Verfügung.</summary>
    Public Shared ReadOnly Property Text As New ConsoleTextHelper

    '''<summary>Stellt allgemeine Console-Funktionen zur Verfügung.</summary>
    Public Shared ReadOnly Property Functions As New ConsoleFunctionsHelper

    '''<summary>Stellt Funktionen für den Zugriff auf Kommandozeilen-Argumente zur Verfügung.</summary>
    Public Shared ReadOnly Property Arguments As New ConsoleArgumentsHelper

    '''<summary>Stellt Funktionen zum Abfragen der Maus und Tastatur zur Verfügung.</summary>
    Public Shared ReadOnly Property Input As New ConsoleInputHelper

    '''<summary>Stellt Funktionen zum Senden von Konsolen-Nachrichten zur Verfügung.</summary>
    Public Shared ReadOnly Property Messaging As New ConsoleMessagingHelper
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace