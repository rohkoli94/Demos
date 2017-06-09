Imports Greeting

Module Program

	Sub Main()
		Dim objGreeter As New Greeter(True)
		Dim strName As String = InputBox("Enter your name")
		
		MsgBox(objGreeter.Greet(strName))
	End Sub	

End Module