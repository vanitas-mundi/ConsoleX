Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.ConsoleX.CommandLineParameters.Enums
#End Region

Namespace CommandLineParameters

  Public Class OptionDefinitionInfo

    Inherits OptionalArgumentDefinitionInfo

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    '''<summary>
    '''Optionaler langer Name der Option.
    '''Bsp.: -v (Name), --verbose (LongName)
    '''</summary>
    Public Property LongName As String = String.Empty

    '''<summary>
    '''Optionaler langer Name der Option.
    '''Bsp.: -v (Name), --verbose (LongName)
    '''</summary>

    Public Property ValueType As CommandLineParameterValueTypes = CommandLineParameterValueTypes.NoValue
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
