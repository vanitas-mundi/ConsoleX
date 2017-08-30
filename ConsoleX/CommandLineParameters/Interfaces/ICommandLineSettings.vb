Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace CommandLineParameters.Interfaces

  Public Interface ICommandLineSettings

    Function GetParameterInfo(ByVal propertyName As String) As CommandLineParameterInfo

    ReadOnly Property ParametersDictionary As Dictionary(Of String, CommandLineParameterInfo)

    Function ExistOption(ByVal name As String) As Boolean
  End Interface

End Namespace