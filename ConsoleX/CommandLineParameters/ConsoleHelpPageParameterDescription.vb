Option Explicit On
Option Infer On
Option Strict On
Imports SSP.ConsoleX.CommandLineParameters.Enums

#Region " --------------->> Imports/ usings "
#End Region

Namespace CommandLineParameters

  Public Class ConsoleHelpPageParameterDescription

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    '''<summary>Liefert den Namen oder legt diesen fest.</summary>
    Public Property Name As String

    '''<summary>Liefert die Beschreibung oder legt diese fest.</summary>
    Public Property Description As String

    '''<summary>Liefert den Typ oder legt diese fest.</summary>
    Public Property Type As CommandLineParameterTypes = CommandLineParameterTypes.Argument

    '''<summary>Liefert die Namenslänge.</summary>
    Public ReadOnly Property NameLength As Int32
      Get
        Return Me.Name.Length
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