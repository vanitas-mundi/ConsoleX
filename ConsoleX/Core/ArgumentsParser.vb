Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace Core

	Public Class ArgumentsParser

#Region " --------------->> Eigenschaften der Klasse "
		Private _options As Dictionary(Of String, String)
		Private _parameters As List(Of String)
		Private _allowedOptions() As String
		Private _parameterCount As Int32
		Private _optionalParameters As Boolean = False

    Public Event ShowHelpPage(ByVal sender As Object, ByVal e As System.EventArgs)
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New(ByVal allowedOptions() As String, ByVal parameterCount As Int32)
			Initialize(allowedOptions, parameterCount, False)
		End Sub

		Public Sub New(ByVal allowedOptions() As String, ByVal parameterCount As Int32, ByVal optionalParameters As Boolean)

			Initialize(allowedOptions, parameterCount, optionalParameters)
		End Sub

		Private Sub Initialize(ByVal allowedOptions() As String, ByVal parameterCount As Int32, ByVal optionalParameters As Boolean)

			_allowedOptions = allowedOptions
			For i = 0 To _allowedOptions.Count - 1
				_allowedOptions(i) = _allowedOptions(i).ToLower.Replace("/", "").Replace("-", "")
			Next i

			_parameterCount = parameterCount
			_optionalParameters = optionalParameters
		End Sub
#End Region	'{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		Public ReadOnly Property OptionValue(ByVal optionName As String) As String
		Get
			Return _options.Item(optionName.ToLower)
		End Get
		End Property

		Public ReadOnly Property OptionExists(ByVal optionName As String) As Boolean
		Get
			Return _options.Keys.Contains(optionName.ToLower)
		End Get
		End Property

		Public ReadOnly Property Options() As Dictionary(Of String, String)
		Get
			Return _options
		End Get
		End Property

		Public ReadOnly Property Parameters() As List(Of String)
		Get
			Return _parameters
		End Get
		End Property
#End Region	'{Zugriffsmethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
		Private Sub AddToOptions(ByVal arg As String, ByVal delimiter As Char)

			Dim pos = arg.IndexOf(delimiter)
			Dim key = ""
			Dim value = ""

			If pos = -1 Then
				key = arg.Substring(1).ToLower
			Else
				key = arg.Substring(1, pos - 1)
				value = arg.Substring(pos + 1)
			End If

			If Not _allowedOptions.Contains(key) Then
				Console.WriteLine("Ungültige Option - """ & key & """.")
				Environment.Exit(0)
			End If

			If key = "?" Then
        RaiseEvent ShowHelpPage(Me, New System.EventArgs)
        Environment.Exit(0)
			Else
					_options.Add(key, value)
			End If
		End Sub
#End Region	'{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
		Public Sub Parse(ByVal commandLineArgs() As String)

      _options = New Dictionary(Of String, String)
      _parameters = New List(Of String)

      For Each arg In commandLineArgs
				Select Case arg.Substring(0, 1)
				Case "/"
					AddToOptions(arg, ":"c)
				Case "-"
					AddToOptions(arg, "="c)
				Case Else
					_parameters.Add(arg)
				End Select
			Next arg

			If _optionalParameters Then Return

			If _parameters.Count <> _parameterCount Then
        Console.WriteLine(My.Settings.WrongNumberParametersMessage)
        Environment.Exit(0)
      End If
		End Sub
#End Region	'Öffentliche Methoden der Klasse}

	End Class

End Namespace