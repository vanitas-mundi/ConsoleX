Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.ConsoleX.CommandLineParameters.Enums
#End Region

Namespace CommandLineParameters.Attributes

  Public Class RefersToCommandLineParameterAttribute

    Inherits Attribute

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New(ByVal argumentIndex As Int32, ByVal type As CommandLineParameterTypes)
      Me.ArgumentIndex = argumentIndex
      Me.Type = type
    End Sub

    Public Sub New(ByVal name As String, ByVal type As CommandLineParameterTypes)
      Me.Name = name
      Me.Type = type
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public ReadOnly Property ArgumentIndex As Int32

    Public ReadOnly Property Name As String

    Public ReadOnly Property Type As CommandLineParameterTypes
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
