Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace ConsoleText.Interfaces

  Public Interface ITextAlignmentFormatter
    Function FormatText(ByVal s As String, ByVal maxWidth As Int32) As String
  End Interface

End Namespace