Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace CommandLineParameters.Enums

  <Flags>
  Public Enum CommandLineParameterTypes
    Argument = 1
    OpionalArgument = 2
    [Option] = 4
  End Enum

End Namespace